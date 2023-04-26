using System.Text;

namespace P01_0070_計算前n個費氏數列的和
{
	internal class Program
	{
		//題意有小瑕疵,其實應該叫做"前n項"之和 因為第0項為0 , 第1項開始才是1,1,2,3,5...
		//這邊提供小小對照表
		//    x = 0,1,2,3,4,5,6, 7, 8, 9,10,11, 12, 13, 14, 15, 16...
		// f(x) = 0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987...
		static void Main(string[] args)
		{
			Console.Write("請輸入一正整數n：");
			int number = getInput();
			List<int> fib = Fibonacci(number);
			print_Fibonacci2(fib);
            Console.WriteLine("總和為："+ sum(fib));
		}


		static int getInput() //持續輸入直至正確,正整數為1.2.3...(不含0)
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
		static List<int> Fibonacci(int n) //傳入n, 將f(n)寫進一個list
		{
			List<int> elements = new List<int>();

			elements.Add(0);

			if (n == 1)
			{
				elements.Add(1);
			}

			else if (n >= 2)
			{
				elements.Add(1);
				for (int i = 0; i < n - 2; i++)
				{
					int temp = elements[i] + elements[i + 1];
					elements.Add(temp);
				}
			}

			return elements;
		}

		static void print_Fibonacci(List<int> list) //單純印數字出來
		{
			foreach (int index in list)
				Console.WriteLine(index + " ");
        }

		static void print_Fibonacci2(List<int> list) //稍微加了點敘述,較好參照
		{
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine($"第{i}項為{list[i]}");
			}
		}

		static int sum(List<int>list) //算總和
		{
			int result = 0;
			foreach(int num in list)
				result += num;
			return result;
		}


	}
}