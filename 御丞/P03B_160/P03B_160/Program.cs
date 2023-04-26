using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_160
{
	internal class Program
	{
		static void Main(string[] args)
		{
			///160 設計一個類別來表示一個簡單的電影票訂購系統，擁有電影列表、場次列表、座位列表、訂單列表等屬性，以及新增訂單、取消訂單、顯示座位狀態等方法，並且支援儲存到檔案和從檔案讀取的方法。
			///
			var system = new TheaterSystem();
			system.AddMovies("Today");


			system.Movies["Today"].AddShowTime(new DateTime(2023, 04, 21, 15, 00, 00));
			system.Movies["Today"].AddShowTime(new DateTime(2023, 04, 21, 16, 00, 00));
			system.Movies["Today"].AddShowTime(new DateTime(2023, 04, 21, 17, 00, 00));
			system.Movies["Today"].AddShowTime(new DateTime(2023, 04, 21, 18, 00, 00));
			system.Movies["Today"].AddShowTime(new DateTime(2023, 04, 21, 19, 00, 00));
			system.Movies["Today"].AddShowTime(new DateTime(2023, 04, 21, 20, 00, 00));
			system.Movies["Today"].AddShowTime(new DateTime(2023, 04, 21, 21, 00, 00));
			system.Movies["Today"].DisplayShowingTime();
			Console.WriteLine(system.Movies["Today"].Showings["04/21 18:00"].SetSeat(3, 3));

			var seat = new Seat(3, 3);
			var orders = new Order("A001", "Today", new DateTime(2023, 04, 21, 18, 00, 00), seat);
			orders.NewTicket("Today", new DateTime(2023, 04, 21, 19, 00, 00), seat);
			orders.NewTicket("Today", new DateTime(2023, 04, 21, 20, 00, 00), seat);

			var tool = new SaveAndLoad();
			//tool.Save("G:\\C#\\C#_Class\\HW_Exercise\\GPT題目_練習\\P03B_160\\P03B_160\\test.txt", orders);
			//var orders = tool.Read("G:\\C#\\C#_Class\\HW_Exercise\\GPT題目_練習\\P03B_160\\P03B_160\\test.txt");

			//Order orders = null;

			tool.Save("D:\\C#_Learning\\HW_Exercise\\GPT題目_練習\\P03B_160\\P03B_160\\test.txt", orders);
			//var orders = tool.Read("D:\\C#_Learning\\HW_Exercise\\GPT題目_練習\\P03B_160\\P03B_160\\test.txt");

			foreach (var order in orders.Tickets)
			{
				Console.WriteLine(order);
			}

			//Console.WriteLine($"訂單編號: {orders.Id}");
			//foreach(var item in orders.Tickets)
			//{
			//             Console.WriteLine(item);
			//         }

			Console.ReadKey();
		}
	}
}
