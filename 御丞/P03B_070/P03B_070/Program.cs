using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_070
{
	internal class Program
	{
		static void Main(string[] args)
		{
			///設計一個類別來表示一個汽車，擁有品牌、車牌號碼、年份三個屬性，以及加速和煞車的方法。
			///
			var RV4 = new Car("TOYOTA", "ABC-1111", 2002);
            Console.WriteLine($"Speed= {RV4.CarSpeed}");
			for (int i = 0; i < 50; i++)
			{
				RV4.Accelerate();
			}
            Console.WriteLine($"Speed= {RV4.CarSpeed}");
			Console.ReadLine();
		}
	}

	public class Car
	{
        public string Logo { get;}
        public string licensePlateNumber { get; set; }
        public int yearOfManufacture { get;}
		private int _carSpeed { get; set; }
		public int CarSpeed 
		{
			get { return _carSpeed; } 
		}
		public Car(string logo, string id, int year) 
		{
			Logo = logo;
			licensePlateNumber = id;
			yearOfManufacture = year;
		}
		public void Accelerate()
		{
			_carSpeed += 1;
		}

		public void Decelerate()
		{
			_carSpeed -= 1;
		}

	}
}
