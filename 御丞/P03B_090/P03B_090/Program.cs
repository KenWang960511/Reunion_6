using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_090
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 090 設計一個類別來表示一個簡單的計算機，擁有加、減、乘、除四個方法，以及記憶功能。
			/// 
			var simpleCalcu = new Calculator();
			simpleCalcu.Add(35, 15);
			simpleCalcu.Division(99, 6);
			simpleCalcu.Subtraction(53, 16);
			simpleCalcu.Multiplication(11, 5);
            foreach (var item in simpleCalcu.Results)
			{
                Console.WriteLine( item);
            }
			Console.ReadKey();
        }
	}
}
