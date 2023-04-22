using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_150
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 150 設計一個類別來表示一個多邊形，擁有邊數、邊長、周長、面積等屬性，以及計算周長和面積的方法，並且支援多種不同的多邊形，例如正方形、長方形、三角形等。
			/// 
			var tri = new Triangle(3,8,7);
			var rec = new Rectangle(5, 8);
			var squ = new Square(6);

            Console.WriteLine($"三角形面積{tri.GetArea():0.00}，周長{tri.GetPerameter()}");
            Console.WriteLine($"長方形面積{rec.GetArea():0.00}，周長{rec.GetPerameter()}");
            Console.WriteLine($"正方形面積{squ.GetArea():0.00}，周長{squ.GetPerameter()}");
			
			Console.ReadKey();
		}
	}


	public abstract class Polygon
	{
        public int Side { get; }
        public int SideLength { get; }

        public Polygon(int side, int sideLength)
        {
			Side = side;
			SideLength = sideLength;
        }
        public abstract double GetArea();
		public abstract int GetPerameter();

	}
	public class Triangle : Polygon
	{
        public int[] SideLengthArr { get;}
        public Triangle(params int[] sideLength) : base(3 , sideLength[0])
		{
			SideLengthArr = sideLength;
		}

		public override double GetArea()
		{
			double s = GetPerameter() / 2.0;
			return Math.Sqrt(s * (s - SideLengthArr[0]) * (s - SideLengthArr[1]) * (s - SideLengthArr[2]));
			
		}

		public override int GetPerameter()
			=> SideLengthArr.Sum();
		
	}
	public class Rectangle : Polygon
	{
        public int SideHight { get;}
        public int SideWidth { get;}
        public Rectangle(int sideHight, int sideWidth) : base(4, sideWidth)
		{
			SideHight = sideHight;
			SideWidth = sideWidth;
		}

		public override double GetArea()
			=> SideHight * SideWidth;

		public override int GetPerameter()
			=> (SideHight + SideWidth) * 2;

	}
	public class Square : Polygon
	{
		public Square(int sideLength) : base(4, sideLength)
		{
		}

		public override double GetArea()
			=> SideLength * SideLength;

		public override int GetPerameter()
			=> SideLength * Side;
	}
}
