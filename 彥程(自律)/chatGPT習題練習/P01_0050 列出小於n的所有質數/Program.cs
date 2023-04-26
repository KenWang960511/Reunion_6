using System.Security.Cryptography.X509Certificates;

namespace P01_0050_列出小於n的所有質數
{
	internal class Program
	{
		//讓使用者輸入一個正整數n，然後列出所有小於等於n的質數
		//感覺題目有瑕疵，應補 n>=2

		//問chatGPT:
		//C# console
		//如何在程式碼裡面宣告一個list
		//讓多個函數都可以使用
		static List<int> result = new List<int>(); 
		static void Main(string[] args)
		{
            Console.Write("請輸入一正整數n：");
			int number = getInput();

			if (number == 1) { Console.WriteLine("1沒有小於等於自己的質數!"); }

			//可以在迴圈裡確定是質數的時候就印出,但比較好的方法應該是裝進一個list 最後一次印出
			for (int i = 2; i <= number; i++) //可再優化
			{
				if (isPrime(i))
				{
					result.Add(i);
				}
			}
			printResult();

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
		static void printResult()
		{
			foreach (int number in result)
			{
				Console.WriteLine(number);
			}
		}

		static bool isPrime(int n)
		{
			//if (n < 2) return false;
			//else if (n == 2) return true;
			//else if (n % 2 == 0) return false;
			//for (int i = 3; i < Math.Sqrt(n); i = i + 2)
			//{
			//	if (n % i == 0) return false;
			//}
			//return true;
			//123

			if (n < 2)
				return false;
			else if (n == 2 || n == 3)
				return true;
			else if (n % 2 == 0 || n % 3 == 0)
				return false;
			for (int i = 5; i <= (int)Math.Sqrt(n); i += 6)
			{
				if (n % i == 0 || n % (i + 2) == 0)
					return false;
			}

			return true;
		}
		
	}
}