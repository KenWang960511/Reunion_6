using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P03B_010
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 設計一個類別來表示一個矩形，擁有長和寬兩個屬性，以及計算面積和周長的方法。
			/// 
			Rectangle newRec = new Rectangle(15, 16);
			var newRecArea = newRec.GetArea();
			var newRecPerimeter = newRec.GetPerimeter();
			Console.WriteLine($"面積為:{newRecArea}\n周長為:{newRecPerimeter}");
			Console.ReadKey();
		}
	}

	public class Rectangle
	{
        public double Length { get; set; }
        public double Width { get; set; }
		
		public Rectangle(double length, double width)
		{
			Length = length;
			Width = width;
		}

		public double GetArea()
		{
			return Length * Width;
		}

		public double GetPerimeter()
		{
			return (Length + Width) * 2;
		}
	}




}
