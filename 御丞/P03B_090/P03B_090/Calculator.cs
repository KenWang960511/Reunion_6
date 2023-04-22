using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_090
{
	/// <summary>
	/// 簡易計算機，具有加、減、乘、除與記憶結果的功能
	/// </summary>
	internal class Calculator
	{
		public List<double> Results = new List<double>();
		/// <summary>
		/// 回傳兩數相加的總和
		/// </summary>
		/// <param name="num1">第一個數</param>
		/// <param name="num2">第二個數</param>
		/// <returns></returns>
		public double Add(double num1, double num2)
		{
			double result = num1 + num2;
			Results.Add(result);
			return result;
		}
		/// <summary>
		/// 回傳兩數相減
		/// </summary>
		/// <param name="num1">第一個數</param>
		/// <param name="num2">第二個數</param>
		/// <returns></returns>
		public double Subtraction(double num1, double num2)
		{
			double result = num1 - num2;
			Results.Add(result);
			return result;
		}
		/// <summary>
		/// 回傳兩數相乘
		/// </summary>
		/// <param name="num1">第一個數</param>
		/// <param name="num2">第二個數</param>
		/// <returns></returns>
		public double Multiplication(double num1, double num2)
		{
			double result = num1 * num2;
			Results.Add(result);
			return result;

		}
		/// <summary>
		/// 回傳兩數相除
		/// </summary>
		/// <param name="num1">第一個數</param>
		/// <param name="num2">第二個數</param>
		/// <returns></returns>
		public double Division(double num1, double num2)
		{
			double result = num1 / num2;
			Results.Add(result);
			return result;
		}

	}
}
