using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_120
{
	public class Student : IComparable<Student>
	{
		public string Name { get; set; }
		public DateTime DateOfBirthday { get; set; }
		public int Score { get; set; }
		public ContactPerson ContactPersonInfo { get; set; }
		public int SortModeSelect = 0;
		public Student(string name, DateTime date, int score, string contactPersonName, string contactPersonNumber)
		{
			Name = name;
			DateOfBirthday = date;
			Score = score;
			ContactPersonInfo = new ContactPerson(contactPersonName, contactPersonNumber);
		}

		public int GetAge()
		{
			return DateTime.Today.Year - DateOfBirthday.Year;
		}

		public int CompareTo(Student comparePart)
		{
			// A null value means that this object is greater.
			if (comparePart == null)
				return 1;

			else if (SortModeSelect == (int)SortMode.SortByName)
				return this.Name.CompareTo(comparePart.Name);
			else
				return this.Score.CompareTo(comparePart.Score);
		}
		public override string ToString()
		{
			return $"My name is {Name}. My birthday is {DateOfBirthday:yyyy/MM/dd}. I'm {GetAge()} years old. My score is {Score}. My contact person is {ContactPersonInfo.Name} and cellphone is {ContactPersonInfo.CellphoneNumber}.";
		}
	}
}
