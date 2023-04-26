using System.Text;

namespace P02_100_計算n的正因數總和
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//目前測試1000,2000,3000是正確的
			//3000的
			//因數為1, 2, 3, 4, 5, 6, 8, 10, 12, 15, 20, 24, 25, 30, 40, 50, 60, 75, 100, 120, 125, 150, 200, 250, 300, 375, 500, 600, 750, 1000, 1500, 3000
			//因數有32個
			//因數總和為9360
			Console.Write("請輸入一正整數n：");
			int number = getInput();

			List<int> factors = getFactors(number);
			Console.WriteLine("因數為:" + factorsToString(factors));
            Console.WriteLine("因數個數為:" + countFactors(factors));
            Console.WriteLine("總和為:" + Sum(factors));

        }


		static int getInput() //持續輸入直至正確,正整數為1.2.3...(0不是)
		{
			int input;

			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out input) && input > 0)
				{
					return input;
				}

				else
					Console.Write("輸入錯誤,請重新輸入:");
			}
		}
		static List<int> getFactors(int n) //回傳放入所有因數的list
		{
			List<int> fctr = new List<int>();

			for(int i = 1; i <= n / 2; i++)
			{
				if (n % i == 0)
				{
					fctr.Add(i);
				}
			}
			fctr.Add(n); //n本身也是因數
			return fctr;
			
		}

		static int Sum(List<int>ft) //回傳list裡所有數之和
		{
			int sum = 0;
			foreach(int num in ft)
				sum += num;
			return sum;
		}

		static string factorsToString(List<int> ft) //回傳包含所有因數的字串
		{
			////不好的寫法
			//string result=string.Empty;
			//foreach (int num in ft)
			//	result += num + " ";
			//return result;

			var sb = new StringBuilder();
			foreach (int num in ft)
				sb.Append(num + "、");

			sb.Remove(sb.Length-1, 1);   //將字串最後的一個"、"去掉
			return sb.ToString();
        }

		static int countFactors(List<int> ft) //
		{
			return ft.Count;
		}
	}
}