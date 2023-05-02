using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeRange
{/// <summary>
 /// 110 設計一個類別來表示一個日期時間範圍，擁有起始時間和結束時間兩個屬性，以及計算持續時間的方法，並且支援比較兩個日期時間範圍是否重疊的方法。
 /// </summary>
 /// //會有跑不出回傳字的時候
	internal class Program
	{
		static void Main(string[] args)
		{
			DateTimeRange time1 = new DateTimeRange();
			DateTimeRange time2 = new DateTimeRange();

			time1.GetInput();
			Console.WriteLine("現在來設定時間二");
			time2.GetInput();

			
		}
	}

	public class DateTimeRange

	{

        public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public TimeSpan TotalTime { get; private set; } //總持續時間，只能讀

		//public DateTimeRange(DateTime startTime, DateTime endTime)
		//{
		//	this.StartTime = startTime;
		//	this.EndTime = endTime;

		//}



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

		public bool IsOverlapping(DateTime time1_start, DateTime time1_end, DateTime time2_start, DateTime time2_end) //判斷是否有重疊時間，有的話回傳true
		{
			if (time1_start < time2_start && time2_start < time1_end) //time2的開始時間介於time1的開始和結束
			{
				return true;
			}

			if (time1_start < time2_end && time2_end < time1_end)    //time2的結束時間介於time1的開始和結束
			{
				return true;
			}

			if (time2_start < time1_start && time1_start < time2_end)   //time1的開始介於time2的開始和結束
			{
				return true;
			}

			if (time2_start < time1_end && time1_end < time2_end)       //time1的結束介於time2的開始和結束
			{
				return true;
			}
			else return false;            //排除以上情況，就不會有重疊，回傳false
		}


	}
}
