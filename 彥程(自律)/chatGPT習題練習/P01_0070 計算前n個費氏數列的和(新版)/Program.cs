namespace P01_0070_計算前n個費氏數列的和_新版_
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int num = getInput();
			int sum = 0;
			for (int i = 0; i < num; i++)
				sum += Fibonacci(i);
			Console.WriteLine(sum);
		}
		static int getInput()
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

		public static int Fibonacci(int n)
		{
			if (n == 0 || n == 1)
			{
				return n;
			}

			return Fibonacci(n - 1) + Fibonacci(n - 2);
		}
	}
}