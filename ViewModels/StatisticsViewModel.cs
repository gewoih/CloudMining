using CloudMining.DataContext;
using CloudMining.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace CloudMining.ViewModels
{
	public class StatisticsViewModel : BaseViewModel
	{
		#region Constructor
		public StatisticsViewModel()
		{
			this.TotalIncome = BTCRUB;
			this.TotalElectricity = new ElectricityPaymentSharesRepository(new BaseDataContext()).GetAll().Where(p => p.IsDone == true).Sum(p => p.Amount);
			this.TotalExpenses = new PurchaseSharesRepository(new BaseDataContext()).GetAll().Where(p => p.IsDone == true).Sum(p => p.Amount) + TotalElectricity;
			this.TotalProfit = TotalIncome - TotalExpenses;
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

		public double TotalProfitPercentage => TotalProfit / TotalExpenses;

		public double BTCRUB
		{
			get
			{
				WebClient webClient = new WebClient();
				webClient.BaseAddress = $"https://api.binance.com/api/v3/ticker/price?symbol=BTCRUB";

				var json = webClient.DownloadString(webClient.BaseAddress);
				dynamic obj = JsonConvert.DeserializeObject(json);

				return Convert.ToDouble(obj.price);
			}
		}
		#endregion
	}
}
