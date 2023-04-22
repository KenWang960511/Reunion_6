using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_030
{
	internal class Program
	{
		static void Main(string[] args)
		{
			///030 設計一個類別來表示一個圓形，擁有半徑屬性，以及計算面積和周長的方法。
			///
			Circle cl = new Circle(9);
            Console.WriteLine($"圓半徑為{cl.Radius}，周長為{cl.GetPerimeter():0.00}，面積為{cl.GetArea():0.00}");
			Console.ReadLine();
        }

		class Circle
		{
            public double Radius { get; set; }
			public Circle(double radius)
			{
				Radius = radius;
			}
			public double GetPerimeter()
			{
				return Radius * 2 * Math.PI;
			}
			public double GetArea()
			{
				return Radius * Radius * Math.PI;
			}

        }
	}
}
