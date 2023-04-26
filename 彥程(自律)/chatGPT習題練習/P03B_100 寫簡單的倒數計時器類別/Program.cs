using System.Diagnostics;

namespace P03B_100_寫簡單的倒數計時器類別
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Timer timer = new Timer();
			timer.SetTime();
			timer.StartTimer();
		}
	}

	public class Timer
	{
		private int Hours { get; set; } = 0;
		private int Minutes { get; set; } = 0;
		private int Seconds { get; set; } = 0;

		private bool running = false;

		static int GetInput() //持續輸入直至正確
		{
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int input) && input >= 0)
					return input;
				else
					Console.Write("輸入錯誤,請重新輸入:");
			}
		}
		public  void SetTime()
		{
            Console.Write("輸入小時：");
			Hours = GetInput();

            Console.Write("輸入分鐘數：");
			Minutes = GetInput();

			Console.Write("輸入秒數：");
			Seconds = GetInput();
		}

		public void StartTimer()
		{
            Console.WriteLine("開始計時！輸入任一鍵後暫停！");
            running = true;

			while (running)
			{
				Console.WriteLine($"{Hours:D2}:{Minutes:D2}:{Seconds:D2}");
				Thread.Sleep(1000);
				if (Seconds == 0)
				{
					if (Minutes == 0)
					{
						Hours--;
						Minutes = 59;
						Seconds = 59;
					}
					else
					{
						Minutes--;
						Seconds = 59;
					}
				}
				else
				{
					Seconds--;
				}

				if (Console.KeyAvailable)
				{
					StopTimer();
				}						
			}
			Console.WriteLine("計時結束");
		}

		public void StopTimer()
		{
			running = false;
		}
	}
}