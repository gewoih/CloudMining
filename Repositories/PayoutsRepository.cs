using CloudMining.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Windows;
using CloudMining.Repositories.Base;
using CloudMining.Models;
using System.Configuration;
using System.Net.Http;

namespace CloudMining.Repositories
{
	public class PayoutsRepository : BaseRepository<Payout>
	{
		public PayoutsRepository(BaseDataContext dbContext) : base(dbContext)
		{
			ApiDataSync();
		}

		public override IQueryable<Payout> GetAll()
		{
			return base.GetAll()
				.Include(item => item.Currency)
				.Include(item => item.Shares);
		}

		private void ApiDataSync()
		{
			var newPayoutsCount = 0;
			var currenciesRepository = new CurrenciesRepository(new BaseDataContext());
			var currencies = currenciesRepository.GetAll().ToList();
			foreach (var c in currencies)
			{
				if (c.ShortName == "ETH")
					continue;

				var apiPayouts = GetApiPayouts(c);
				foreach (var payout in apiPayouts)
				{
					if (GetAll().Any(p => p.TxId == payout.Txid)) 
						continue;
					
					CalculateShares(Create(new Payout 
					{ 
						TxId = payout.Txid, 
						Amount = Math.Round(payout.Amount, c.Precision, MidpointRounding.ToZero), 
						Currency = c, 
						Timestamp = payout.Timestamp 
					}));
					newPayoutsCount++;
				}
			}

			if (!newPayoutsCount.Equals(0))
				MessageBox.Show($"Загружено {newPayoutsCount} новых выплат.");
		}

		private List<ApiPayout> GetApiPayouts(Currency currency)
		{
			var httpClient = new HttpClient();
			var response = httpClient.GetAsync(
				$"https://api.emcd.io/v1/{currency.ShortName}/payouts/{ConfigurationManager.AppSettings["EmcdApi"]}").Result;

			var stringResult = response.Content.ReadAsStringAsync().Result;

			var json = JObject.Parse(stringResult);
			var payouts = json["payouts"];

			return payouts.ToObject<List<ApiPayout>>();
		}

		private void CalculateShares(Payout newPayout)
		{
			var members = new MembersRepository(new BaseDataContext()).GetAll().ToList();
			var payoutSharesRepository = new PayoutSharesRepository(new BaseDataContext());

			foreach (var member in members)
			{
				payoutSharesRepository.Create(
				new PayoutShare
				{
					Member = member,
					Percent = member.Share,
					Amount = Math.Round(newPayout.Amount * member.Role.Fee / 100 + (newPayout.Amount - (newPayout.Amount * members.Sum(m => m.Role.Fee) / 100)) * member.Share / 100, newPayout.Currency.Precision, MidpointRounding.ToZero),
					BaseEntity = newPayout,
					IsDone = false
				});
			}
		}
	}
}