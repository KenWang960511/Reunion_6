using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInformation
{
	/// <summary>
	/// 120 設計一個類別來表示一個學生，擁有姓名、生日、成績、聯絡人等屬性，以及計算年齡的方法，並且支援按姓名排序和按成績排序的方法。
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
		}
	}


	public class Student
	{
		public string Name { get; set; }
		public DateTime Birthday { get; set; }
		public int Score { get; set; }
		public string ContactPerson { get; set; }


		public int CalculateAge()  //計算年齡
		{
			int age = DateTime.Now.Year - Birthday.Year;
			if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
			{
				age--;
			}
			return age;
		}

		//按照姓名排序的方法，回傳型別是List<Student>，輸入的參數是List<Student>型別的students
		public List<Student> SortByName(List<Student> students)
		{
			return students.OrderBy(s => s.Name).ToList(); //排序完之後再轉換為List集合
		}

		//按照成績排序的方法，回傳型別是List<Student>，輸入的參數是List<Student>型別的students
		public List<Student> SortByScore(List<Student> students)
		{
			return students.OrderBy(s => s.Score).ToList();
		}
	}
}
