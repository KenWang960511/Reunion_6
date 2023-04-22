using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_040
{
	internal class Program
	{
		static void Main(string[] args)
		{
			///040 設計一個類別來表示一個三角形，擁有三個邊長屬性，以及計算面積和周長的方法。
			///
			Triangle tri = new Triangle(3,4,5);
            Console.WriteLine($"三角形面積為{tri.GetArea()}，周長為{tri.GetPerimeter()}");
			Console.ReadKey();
        }
	}
	/// <summary>
	/// SideC = hypotenuse
	/// </summary>
	class Triangle
	{
        public double SideA { get; set; }  
        public double SideB { get; set; }
        public double SideC { get; set; }  

		public Triangle(double a, double b, double c) 
		{
			if (a<=0 || b<=0 || c<=0)
			{
				throw new ArgumentException("Triangle Side A, B, C can not be smaller than 0.");
			}
			else if (c < b && c < a)
			{
				throw new ArgumentException("Triangle Side C must be the longest side.");
			}
			else if (c > a + b)
			{
				throw new ArgumentException("Triangle Side C can not be longer than Side A add Side B.");
			}
			SideA = a; 
			SideB = b; 
			SideC = c;
		}

		public double GetArea()
		{
			/// Heron's formula
			/// 
			double s = (SideA + SideB + SideC) / 2;
			return Math.Sqrt(s * (s-SideA) * (s-SideB) * (s-SideC));
		}
		public double GetPerimeter()
		{
			return (SideA + SideB + SideC);
		}
	}
}
