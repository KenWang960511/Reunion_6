using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_120
{
	public class ClassRoom
	{
		public List<Student> Students { get; set; }

		public ClassRoom()
		{
			Students = new List<Student>();
		}
		public void AddStudentInfo(string name, DateTime date, int score, string contactPersonName, string contactPersonNumber)
		{
			Students.Add(new Student(name, date, score, contactPersonName, contactPersonNumber));
		}
		public List<Student> SortByName()
		{
			var newStudents = Students;
			Students[0].SortModeSelect = (int)SortMode.SortByName;
			newStudents.Sort();
			return newStudents;
		}
		public List<Student> SortByScore()
		{
			var newStudents = Students;
			Students[0].SortModeSelect = (int)SortMode.SortByScore;
			newStudents.Sort();
			return newStudents;
		}
	}
}
