using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_110
{
	internal class Program
	{
		/// <summary>
		/// 110 設計一個類別來表示一個日期時間範圍，擁有起始時間和結束時間兩個屬性，以及計算持續時間的方法，並且支援比較兩個日期時間範圍是否重疊的方法。
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			DateTime dtStart = new DateTime();
		}
		class PeriodOfTime //一個日期時間範圍
		{
			private DateTime _dtSrarTime;
			private DateTime _dtEndTime;

			public DateTime dtSrar //2屬性 起始時間、結束時間
			{
				get
				{
					return _dtSrarTime;
				}
				set
				{
					_dtSrarTime = value;
				}
			}

			//1method 計算時間持續?
			//比較兩個日期時間是否重疊

			//比較日期 
			//如果 日期 相等 

		}
	}
}
