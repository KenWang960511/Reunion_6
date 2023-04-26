using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_170
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 170 設計一個類別來表示一個學生，擁有姓名、年齡、學號、成績等屬性，以及顯示學生資訊的方法，並且支援不同的排序方法，例如按照姓名、年齡、學號、成績等排序。
			/// 
			SortBy sortOption = SortBy.StudentId;
			List<Student> students = new List<Student>();
			var stu1 = new Student("Jenny", 24, 1111, sortOption);
			stu1.AddScore("國文", 50);
			stu1.AddScore("數學", 30);
			stu1.AddScore("英文", 100);
			var stu2 = new Student("Alan", 23, 1112, sortOption);
			stu2.AddScore("國文", 90);
			stu2.AddScore("數學", 60);
			stu2.AddScore("英文", 80);
			var stu3 = new Student("Zou", 25, 1113, sortOption);
			stu3.AddScore("國文", 80);
			stu3.AddScore("數學", 50);
			stu3.AddScore("英文", 70);
			students.Add(stu1);
			students.Add(stu2);
			students.Add(stu3);
			students.Sort();
			foreach (var item in students)
			{
                Console.WriteLine(item.DisplayStudentInfo());
            }

            Console.ReadKey();
		}

		public enum SortBy
		{
			Name,
			Age,
			StudentId,
			Chinese,
			Math,
			English
		}

		public class Student : IComparable<Student>
		{
            public string Name { get; private set; }
            public int Age { get; private set; }
            public int StudentId { get; private set; }

			private SortBy _sortOption;

            public Dictionary<string, Score> ScoreList { get; private set; }

			public Student(string name, int age, int studentId, SortBy sortOption) 
			{
				this.Name = name;
				this.Age = age;
				this.StudentId = studentId;
				this.ScoreList = new Dictionary<string, Score>();
				this._sortOption = sortOption;
			}

			public string AddScore(string subject, int points)
			{
				if (ScoreList.Keys.Contains(subject))
				{
					return $"{subject}已存在，新增失敗。";
				}
				else
				{
					ScoreList.Add(subject, new Score(subject, points));
					return $"新增{subject} {points}分，成功!!!";
				}
			}

			public string RemoveScore(string subject)
			{
				if (ScoreList.Keys.Contains(subject))
				{
					ScoreList.Remove(subject);
					return $"移除{subject}，成功!!!";
				}
				else
				{
					return $"{subject}不存在，移除失敗。";
				}
			}

			public string DisplayStudentInfo()
			{
				string scoreInfo = "";
				foreach (var score in ScoreList.Values)
				{
					scoreInfo += score.ToString() + ",\t";
				}

				return $"姓名: {Name}\t年齡: {Age}\t學號: {StudentId}\t成績: {scoreInfo}";
			}

			public int compareto(object obj)
			{
				Student student = obj as Student;
				if (student == null)
					throw new ArgumentException("對象不是學生物件無法比較");
				// return this.age.compareto(student.age);
				int thisscoresum = this.ScoreList.Values.Sum(x => x.Points);
				int otherscoresum = student.ScoreList.Values.Sum(x => x.Points);
				return thisscoresum.CompareTo(otherscoresum);
			}

			public int CompareTo(Student other)
			{
				switch (_sortOption)
				{
					case SortBy.Name:
						return this.Name.CompareTo(other.Name);
					case SortBy.Age:
						return this.Age.CompareTo(other.Age);
					case SortBy.StudentId:
						return this.StudentId.CompareTo(other.StudentId);
					case SortBy.Chinese:
						return this.ScoreList["國文"].Points.CompareTo(other.ScoreList["國文"].Points);
					case SortBy.Math:
						return this.ScoreList["數學"].Points.CompareTo(other.ScoreList["數學"].Points);
					case SortBy.English:
						return this.ScoreList["英文"].Points.CompareTo(other.ScoreList["英文"].Points);
					default:
						return this.StudentId.CompareTo(other.StudentId);
				}
			}


		}

		public class Score
		{
			public string Subject { get; private set; }
            public int Points { get; private set; }

			public Score(string subject, int points)
			{
				this.Subject = subject;
				this.Points = points;
			}

			public override string ToString()
			{
				return $"{Subject} {Points}分";
			}

		}
	}
}
