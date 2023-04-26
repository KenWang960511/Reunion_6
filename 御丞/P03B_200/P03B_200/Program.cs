using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_200
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 設計一個類別來表示一個簡單的計算機，擁有加、減、乘、除等計算功能，以及記錄運算紀錄、清除運算紀錄等功能。
			/// 
			var cal = new Calculator();
			cal.Add(5);
			cal.Subtraction(3);
			cal.Multiplication(12);
			cal.Division(6);
			cal.ShowRecords();
			cal.ClearOperationRecord();
			cal.ShowRecords();
			Console.ReadKey();
		}

	}

	public class Calculator
	{
		private double _result;
		public double result { get { return _result; }}
        public List<string> OperationRecords { get; private set; }
        public Calculator()
        {
			OperationRecords = new List<string>();
			_result = 0;
        }

        public void Add(double firstNumber)
		{
			AddOperationRecord(firstNumber, "+");
			_result += firstNumber;
		}
		public void Subtraction(double firstNumber)
		{
			AddOperationRecord(firstNumber, "-");
			_result -= firstNumber;
		}
		public void Multiplication(double firstNumber)
		{
			AddOperationRecord(firstNumber, "*");
			_result *= firstNumber;
		}
		public void Division(double firstNumber)
		{
			if (firstNumber == 0) throw new ArgumentException("除數不可為0");

			AddOperationRecord(firstNumber, "/");
			_result /= firstNumber;
		}
		private void AddOperationRecord(double firstNumber, string operatorSymbol)
		{
			string message = string.Empty;

			switch (operatorSymbol)
			{
				case "+":
					message = $"{_result} + {firstNumber} = {_result + firstNumber}";
					break;
				case "-":
					message = $"{_result} - {firstNumber} = {_result - firstNumber}";
					break;
				case "*":
					message = $"{_result} * {firstNumber} = {_result * firstNumber}";
					break;
				case "/":
					message = $"{_result} / {firstNumber} = {_result / firstNumber}";
					break;
				default:
					break;
			}
			OperationRecords.Add(message);
		}
		public void ClearOperationRecord() 
		{ 
			OperationRecords.Clear(); 
		}
		public void ShowRecords()
		{
            Console.WriteLine("運算紀錄:");
            foreach (string record in OperationRecords)
			{
                Console.WriteLine(record);
            }
		}
	}
}
