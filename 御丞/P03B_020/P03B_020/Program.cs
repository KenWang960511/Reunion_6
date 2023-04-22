using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace P03B_020
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 020 設計一個類別來表示一個線段，擁有起點和終點兩個屬性，以及計算線段長度的方法。
			/// 
			Coordinate startPoint = new Coordinate (0,0);
			Coordinate endPoint = new Coordinate (3, 4);

			LineSegment lineSeg = new LineSegment(startPoint, endPoint);
			Console.WriteLine(lineSeg.GetLength());
			Console.ReadKey();
		}
	}

	public class Coordinate
	{
		public double XCoordinate { get; set; }
		public double YCoordinate { get; set; }
		public Coordinate(double xCoordinate, double yCoordinate)
		{
			XCoordinate = xCoordinate;
			YCoordinate = yCoordinate;
		}

    }

	public class LineSegment
	{
        public Coordinate StartPoint { get; set; }
        public Coordinate EndPoint { get; set; }
        public LineSegment(Coordinate startPoint, Coordinate endPoint) 
		{
			StartPoint = startPoint;
			EndPoint = endPoint;
		}
		public double GetLength()
		{
			double xLength = Math.Abs(StartPoint.XCoordinate - EndPoint.XCoordinate);
			double yLength = Math.Abs(StartPoint.YCoordinate - EndPoint.YCoordinate);

			return Math.Sqrt(Math.Pow(xLength, 2) + Math.Pow(yLength, 2));
		}
	}
}
