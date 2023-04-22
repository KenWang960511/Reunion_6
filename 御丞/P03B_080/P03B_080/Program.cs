using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_080
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 080 設計一個類別來表示一個家庭，擁有父母、孩子姓名、年齡等屬性，以及計算平均年齡的方法。
			/// 

			Family wangFamily = new Family("Wang");
			wangFamily.AddFamilier(new Familier("Father", "AA", new DateTime(1981,08,22)));
			wangFamily.AddFamilier(new Familier("Mother", "BB", new DateTime(1987, 07, 12)));
			wangFamily.AddFamilier(new Familier("Daughter", "BA", new DateTime(2009, 10, 27)));
			wangFamily.AddFamilier(new Familier("Son", "AB", new DateTime(2011, 11, 11)));

			foreach (var p in wangFamily.Familiers)
			{
                Console.WriteLine(p);
				p.SayHi("GG");
            }
            Console.WriteLine($"平均年齡為: {wangFamily.GetFamilierAverageAge()}");
            Console.ReadKey();
		}
	}

	interface IFriend
	{
		void SayHi(string name);
	}
	public class Person : IFriend
	{
		private int _age;
		public string Name { get; set; }
		public int Age { get { return _age; } }
		public DateTime DateOfBirthday { get; set; }

		public Person(DateTime date)
		{
			DateOfBirthday = date;
			_age = DateTime.Now.Year - DateOfBirthday.Year;
		}

		public void SayHi(string name)
		{
            Console.WriteLine($"Hello!{name}, I'm {Name}. Nice to meet you.");
        }

    }
	public class Familier : Person
	{
		public string Appellation { get; set; }

		public Familier(string appellation, string name, DateTime date) : base (date)
		{ 
			Appellation = appellation;
			Name = name;
			DateOfBirthday = date;
		}
		public override string ToString()
		{
			return $"我是{Appellation}，名叫{Name}，生日是{DateOfBirthday:yyyy/MM/dd}，今年{Age}歲。";
		}
	}
	public class Family
	{
		public string FamilyName { get; set; }
		public List<Familier> Familiers { get; set; }

		public Family(string name)
		{
			FamilyName = name;
			Familiers = new List<Familier>();
		}
		public void AddFamilier(Familier familier)
		{
			Familiers.Add(familier);
		}
		public double GetFamilierAverageAge()
		{
			return Familiers.Average(x => x.Age);
		}

	}
}
