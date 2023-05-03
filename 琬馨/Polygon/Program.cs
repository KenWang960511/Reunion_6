using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon
{/// <summary>
 /// 150 設計一個類別來表示一個正多邊形，擁有邊數、邊長、周長、面積等屬性，以及計算周長和面積的方法，並且支援多種不同的多邊形，例如正方形、長方形、三角形等。
 /// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
		}
	}

	public abstract class Polygon
	{
		public int NumberOfSide { get; set; } //有幾邊
		public double SideLength { get; set; } //邊長
		public double Perimeter { get; set; }   //周長
		public double Area { get; set; }        //面積

		//public Polygon(int numberOfSide, double sideLength, double perimeter, double area) //把這個class會用到的共用資訊都放進建構函數
		//{
		//	this.NumberOfSide = numberOfSide;
		//	this.SideLength = sideLength;
		//	this.Perimeter = perimeter;
		//	this.Area = area;

		//}
		public virtual double CalculatePerimeter() //求周長的方法 【最基礎的虛擬方法】
		{
			return NumberOfSide * SideLength;

		}

		public abstract double CalculateArea(double sideLength);  //求面積的方法，因為大家的求法都不同，所以強制要讓子類別去覆寫求面積的方法，而要強制讓子類別覆寫，需要用到抽象方法abstract，然後如果一個class裡面有抽象方法，那個class就必須被宣告成抽象類別。**抽象類別不寫計算式

	}

	public class Triangle : Polygon
	{

		public override double CalculateArea(double sideLength)  //三角形面積，覆寫子類別
		{
			return (Math.Sqrt(3) / 4) * Math.Pow(sideLength, 2);
		}


	}

	public class Rectangle : Polygon
	{
		public override double CalculateArea(double sideLength, double sidewidth)  //長方形面積，覆寫子類別
		{
			return (sideLength * sidewidth);
		}
	}

}
