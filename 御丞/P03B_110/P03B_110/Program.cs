using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_110
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 110 設計一個類別來表示一個日期時間範圍，擁有起始時間和結束時間兩個屬性，以及計算持續時間的方法，並且支援比較兩個日期時間範圍是否重疊的方法。
			/// 
			var firstDateRange = new DateRange(new DateTime(2020, 12, 13), DateTime.Today);
			var timesp = firstDateRange.GetDuration();
            Console.WriteLine($"從 {firstDateRange.StartDate:yyyy/MM/dd} 開始到 今天 {firstDateRange.EndDate:yyyy/MM/dd} {timesp.TotalDays} 天");
			var secondDateRange = new DateRange(new DateTime(2023, 03, 24), new DateTime(2023, 09, 04));
            Console.WriteLine(firstDateRange.IsDateRangeOverlap(secondDateRange));
			Console.ReadKey();
        }
	}

	public class DateRange
	{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
		public DateRange(DateTime start, DateTime end)
		{
			StartDate = start;
			EndDate = end;
		}
		public TimeSpan GetDuration()
		{
			return EndDate - StartDate;
		}

		public bool IsDateRangeOverlap(DateRange otherDateRange)
			=> this.StartDate < otherDateRange.EndDate && this.EndDate > otherDateRange.StartDate;

	}
}
