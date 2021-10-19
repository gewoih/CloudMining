using CloudMining.Models.Base;
using System.Collections.Generic;

namespace CloudMining.Models
{
	public class Currency : NamedEntity
	{
		private string _ShortName;
		public string ShortName
		{
			get => _ShortName;
			set => Set(ref _ShortName, value);
		}

		private int _Precision;
		public int Precision
		{
			get => _Precision;
			set => Set(ref _Precision, value);
		}

		private List<Device> _Devices;
		public List<Device> Devices
		{
			get => _Devices;
			set => Set(ref _Devices, value);
		}
	}
}
