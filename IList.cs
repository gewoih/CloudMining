using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CloudMining
{
	public interface IList<T>
	{
		public abstract List<T> items { get; set; }

		public abstract void LoadList();
		public abstract void DrawList(StackPanel uIElement);
	}
}
