using CloudMining.Models.Base;
using System.Collections.Generic;

namespace CloudMining.Models
{
	public class Role : NamedEntity
	{
		private double _Fee;
		public double Fee
		{
			get => _Fee;
			set => Set(ref _Fee, value);
		}

		private List<Member> _Members;
		public List<Member> Members
		{
			get => _Members;
			set => Set(ref _Members, value);
		}
	}
}
