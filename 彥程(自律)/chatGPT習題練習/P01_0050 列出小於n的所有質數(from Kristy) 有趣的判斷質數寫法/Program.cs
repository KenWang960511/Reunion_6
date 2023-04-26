using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_0050_列出小於n的所有質數_from_Kristy__有趣的判斷質數寫法
{
	internal class Program
	{
		/// <summary>
		/// 讓使用者輸入一個正整數n，然後列出所有小於等於n的質數
		/// </summary>
		/// <param name="args"></param>

		static void Main(string[] args)
		{
			Console.Write("請輸入一個整數：");
			int num = int.Parse(Console.ReadLine());
			ListPrimes(num);
		}
		static void ListPrimes(int num)

		{
			bool[] isPrime = new bool[num + 1];//為了保證可以儲存從2~num是否為質數

			if (num <= 0) { throw new Exception("必須是正整數"); }

			for (int i = 2; i <= num; i++)
			{
				isPrime[i] = true;
			}
			int sqrt = (int)Math.Sqrt(num);
			for (int i = 2; i <= sqrt; i++)
			{
				if (isPrime[i])
				{
					for (int k = i * i; k <= num; k += i)
					{
						isPrime[k] = false; //k為i的倍數
					}
				}
			}
			for (int i = 2; i <= num; i++)
			{
				if (isPrime[i])
				{
					Console.Write(i + " ");
				}
			}
		}
	}
}
//n = 50

//i = 2
//k = 4; k <= 50; k = k + 2

//k = 4.6.8.10.12.14.16.18.20......50

//i = 3
//k = 9,12,15,18,21,24,27,30,33,36,39,42,45,48

//i = 5
//k = 5,10,15,20,25,30,35,40,45,50

//i = 7
//k = 7,49



