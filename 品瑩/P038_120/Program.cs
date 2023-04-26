using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P038_120
{
	internal class Program
	{
		/// <summary>
		/// 120 設計一個類別來表示一個學生，擁有姓名、生日、成績、聯絡人等屬性，以及計算年齡的方法，並且支援按姓名排序和按成績排序的方法。
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			List<Student> students = new List<Student> {
			new Student("Amy", Student.GetAge(new DateTime(1996, 4, 12)) ,50,"小明"),
			new Student("Cindy", Student.GetAge(new DateTime(1992, 3, 1)),40,"小華"),
			new Student("Eva", Student.GetAge(new DateTime(1986, 12, 15)),30,"小呆"),
			new Student("Jacky", Student.GetAge(new DateTime(1977, 1, 1)),20,"小七"),
			};

			IEnumerable<Student> quary1 = students.OrderBy(s => s.Name); //依照姓名排序
			IEnumerable<Student> quary2 = students.OrderBy(s => s.Scores); //依照成績排序

			Console.WriteLine("依姓名排序:");
			foreach (Student s in quary1)
			{
				Console.WriteLine($"姓名:{s.Name} , 成績:{s.Scores} , 年齡:{s.Age} , 聯絡人:{s.ContactPerson}");
			}

			Console.WriteLine();

			Console.WriteLine("依成績排序:");
			foreach (Student s in quary2)
			{
				Console.WriteLine($"姓名:{s.Name} , 成績:{s.Scores} , 年齡:{s.Age} , 聯絡人:{s.ContactPerson}");
			}

			Console.ReadLine();
		}
		public class Student
		{
			//姓名 生日 成績 聯絡人 -屬性
			public string Name { get; set; }
			public int Age { get; set; }
			public int Scores { get; set; }
			public string ContactPerson { get; set; }

			private int _age;

			public Student(string name, int age, int scores, string contactPersonName)
			{
				this.Name = name;
				this.Age = age;
				this.Scores = scores;
				this.ContactPerson = contactPersonName;
			}

			//計算年齡 -方法
			public static int GetAge(DateTime birthday)
			{
				int age = DateTime.Now.Year - birthday.Year;
				return age;
			}
		}
	}
}
