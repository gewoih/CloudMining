﻿using CloudMining.DataContext;
using CloudMining.Models.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;

namespace CloudMining.Models.Repositories
{
	public class PayoutsRepository : BaseRepository<Payout>
	{
		private string ApiKey { get; set; }

		public PayoutsRepository(BaseDataContext dbContext) : base(dbContext)
		{
			this.ApiKey = "b5791b71-80f1-4347-8d6e-4c177bdf5dd9";

			ApiDataSync();
		}

		public override IQueryable<Payout> GetAll()
		{
			return base.GetAll().Include(item => item.Currency).Include(item => item.Shares);
		}

		private void ApiDataSync()
		{
			int newPayoutsCount = 0;
			foreach(var c in new CurrenciesRepository(new BaseDataContext()).GetAll().ToList())
			{
				List<ApiPayout> ApiPayouts = GetApiPayouts(c);
				foreach (var payout in ApiPayouts)
				{
					if (!this.GetAll().ToList().Exists(p => p.TxId == payout.txid))
					{
						CalculateShares(this.Create(new Payout 
														{ 
															TxId = payout.txid, 
															Amount = Math.Round(payout.amount, c.Precision, MidpointRounding.ToZero), 
															Currency = c, 
															Timestamp = payout.timestamp 
														}));
						newPayoutsCount++;
					}
				}
			}
			if (!newPayoutsCount.Equals(0))
				MessageBox.Show($"Загружено {newPayoutsCount} новых выплат.");
		}

		private List<ApiPayout> GetApiPayouts(Currency currency)
		{
			WebClient webClient = new WebClient();
			webClient.BaseAddress = $"https://api.emcd.io/v1/{currency.ShortName}/payouts/{ApiKey}";

			string response = webClient.DownloadString(webClient.BaseAddress);
			JObject json = JObject.Parse(response);
			JToken payouts = json["payouts"];

			return payouts.ToObject<List<ApiPayout>>();
		}

		private void CalculateShares(Payout newPayout)
		{
			List<Member> Members = new MembersRepository(new BaseDataContext()).GetAll().ToList();
			IRepository<PayoutShare> PayoutSharesRepository = new PayoutSharesRepository(new BaseDataContext());

			foreach (var member in Members)
			{
				PayoutSharesRepository.Create(
				new PayoutShare 
				{ 
					Member = member, 
					Percent = member.Share, 
					Amount = Math.Round(newPayout.Amount * member.Role.Fee / 100 + (newPayout.Amount - (newPayout.Amount * Members.Sum(m => m.Role.Fee) / 100)) * member.Share / 100, newPayout.Currency.Precision, MidpointRounding.ToZero),
					Payout = newPayout
				});
			}
		}
	}

	public class ApiPayout
	{
		public double timestamp { get; set; }
		public string gmt_time { get; set; }
		public double amount { get; set; }
		public string txid { get; set; }
	}
}