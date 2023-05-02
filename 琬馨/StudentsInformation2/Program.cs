using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInformation2
{
	/// <summary>
	/// 120 設計一個類別來表示一個學生，擁有姓名、生日、成績、聯絡人等屬性，以及計算年齡的方法，並且支援按姓名排序和按成績排序的方法。
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			Student student1 = new Student("Cindy", new DateTime(1997,12,14), 60, "Lisa");
			Student student2 = new Student("Amy", new DateTime(1997, 10, 15), 80, "Tomy");
			Student student3 = new Student("Cherry", new DateTime(1997, 07, 06), 70, "Honey");

			List<Student> students = new List<Student>();
			students.Add(student1);
			students.Add(student2);	
			students.Add(student3);

			students.Sort(); //排序
			foreach (Student student in students) //排序完之後用foreach印出集合裡面的每筆資料(排序過後的每筆資料)
			{
				Console.WriteLine("姓名是{0}，生日是{1}，成績是{2}",student.Name, student.Birthday, student.Score);
			}

		}
	}

	public class Student:IComparable<Student>
	{
		public string Name { get; set; }
		public DateTime Birthday { get; set; }
		public int Score { get; set; }
		public string ContactPerson { get; set; }

        public Student(string name, DateTime birthday, int score, string contactPerson)
        {
			this.Name = name;
			this.Birthday = birthday;	
			this.Score = score;
			this.ContactPerson = contactPerson;
        }


        public int CalculateAge()  //計算年齡
		{
			int age = DateTime.Now.Year - Birthday.Year;
			if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
			{
				age--;
			}
			return age;
		}


		public int CompareTo(Student other) //按照成績排序的方法，這個方法實作IComparable介面，所以從main呼叫Sort的時候，Sort會自動呼叫這個方法
		{
			if (this.Score < other.Score)
			{
				return 100;
			}
			else if (this.Score > other.Score)
			{
				return -100;
			}
			else return 0;
		}


	}




}

