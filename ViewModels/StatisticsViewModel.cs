using CloudMining.DataContext;
using CloudMining.Models;
using CloudMining.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Windows;

namespace CloudMining.ViewModels
{
	public class StatisticsViewModel : BaseViewModel
	{
		#region Constructor
		public StatisticsViewModel()
		{
			this.TotalIncome = this.CalculateTotalIncome(new CurrenciesRepository(new BaseDataContext()).GetAll().ToList(), new PayoutsRepository(new BaseDataContext()).GetAll().ToList());
			this.TotalElectricity = new ElectricityPaymentsRepository(new BaseDataContext()).GetAll().Sum(p => p.Amount);
			this.TotalExpenses = new DepositsRepository(new BaseDataContext()).GetAll().Sum(p => p.Amount);
			this.TotalProfit = TotalIncome - TotalExpenses - TotalElectricity;
		}
		#endregion

		#region Properties
		private double _TotalIncome;
		public double TotalIncome
		{
			get => _TotalIncome;
			set => Set(ref _TotalIncome, value);
		}

		private double _TotalElectricity;
		public double TotalElectricity
		{
			get => _TotalElectricity;
			set => Set(ref _TotalElectricity, value);
		}

		private double _TotalExpenses;
		public double TotalExpenses
		{
			get => _TotalExpenses;
			set => Set(ref _TotalExpenses, value);
		}

		private double _TotalProfit;
		public double TotalProfit
		{
			get => _TotalProfit;
			set => Set(ref _TotalProfit, value);
		}

		public double TotalProfitPercentage => Math.Abs(Math.Round(TotalIncome / (TotalExpenses + TotalElectricity) * 100, 2));

		public double BTCRUB
		{
			get
			{
				WebClient webClient = new WebClient();
				webClient.BaseAddress = $"https://api.binance.com/api/v3/ticker/price?symbol=BTCRUB";

				var json = webClient.DownloadString(webClient.BaseAddress);
				dynamic obj = JsonConvert.DeserializeObject(json);

				return obj["price"];
			}
		}

		private double CalculateTotalIncome(List<Currency> currencies, List<Payout> payouts)
		{
			double income = 0;
			WebClient webClient = new WebClient();
			webClient.BaseAddress = $"https://api.binance.com/api/v3/ticker/price";

			var json = webClient.DownloadString(webClient.BaseAddress);
			List<dynamic> obj = JsonConvert.DeserializeObject<List<object>>(json);
			foreach (var currency in currencies)
			{
				dynamic curr = obj.Find(o => o["symbol"] == $"{currency.ShortName}RUB");
				income += (double)curr["price"] * payouts.Where(p => p.Currency.Id == currency.Id).Sum(p => p.Amount);
			}

			return Math.Round(income, 0);
		}
		#endregion
	}
}
