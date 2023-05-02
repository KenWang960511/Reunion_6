using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeRange
{/// <summary>
 /// 110 設計一個類別來表示一個日期時間範圍，擁有起始時間和結束時間兩個屬性，以及計算持續時間的方法，並且支援比較兩個日期時間範圍是否重疊的方法。
 /// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			DateTimeRange time1 = new DateTimeRange();
			DateTimeRange time2 = new DateTimeRange();

			time1.GetInput();
			Console.WriteLine("現在來設定時間二");
			time2.GetInput();


			if (time1.IsOverlapping(time2))
			{
				Console.WriteLine("兩個時間有重疊!");
			}
			else
			{
				Console.WriteLine("兩個時間沒有重疊~");
			}
		}
	}

	public class DateTimeRange

	{

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public TimeSpan TotalTime { get; private set; } //總持續時間，只能讀





		public DateTime IsInput()   //檢查輸入的值是否合理
		{
			while (true)
			{
				if (DateTime.TryParse(Console.ReadLine(), out DateTime input))
				{
					return input;
				}
				else
				{
					Console.WriteLine("輸入錯誤，請重新輸入");
				}
			}

		}
		public void GetInput()
		{
			Console.WriteLine("請輸入開始時間： (格式為：yyyy/MM/dd HH:mm:ss");
			StartTime = IsInput();

			Console.WriteLine("請輸入結束時間：  (格式為：yyyy/MM/dd HH:mm:ss");
			EndTime = IsInput();
		}


		public TimeSpan CalculateDuration()  //計算持續的時間
		{
			TotalTime = (EndTime - StartTime).Duration();
			return TotalTime;
		}

		public bool IsOverlapping(DateTimeRange otherRange) //判斷是否有重疊時間，有的話回傳true
		{
			if (this.StartTime < otherRange.EndTime && otherRange.StartTime < this.EndTime)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


	}
}
