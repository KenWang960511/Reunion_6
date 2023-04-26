namespace P03B_120_寫一個學生類別
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Student Amy = new Student("Amy",new DateTime(1997, 1, 28), 0, 0, 0, "hehe");
			Student Tom = new Student("Tom", new DateTime(1997, 5, 28), 0, 0, 0, "hehe");
			Console.WriteLine(Amy.GetAge());
            Console.WriteLine(Tom.GetAge());
        }
	}

	public class Student
	{
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public double ScoreChinese { get; set; }
		public double ScoreEnglish { get; set; }
		public double ScoreMath { get; set; }
        public string ContactName { get; set; }

		public Student( string name, DateTime birth, double chinese, double english, double math, string contact)
		{
			//precondition check
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Name cannot be empty.");
			}
			Name = name;

			if (birth > DateTime.Now)
			{
				throw new ArgumentException("Birth date cannot be in the future.");
			}
			Birth = birth;

			if (chinese < 0 || chinese > 100)
			{
				throw new ArgumentException("chinese","分數需介於0~100");
			}
			ScoreChinese = chinese;
			if (english < 0 || english > 100)
			{
				throw new ArgumentException("english", "分數需介於0~100");
			}
			ScoreEnglish = english;
			if (math < 0 || math > 100)
			{
				throw new ArgumentException("math", "分數需介於0~100");
			}
			ScoreMath = math;

			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Name cannot be empty.");
			}
			ContactName = contact;
		}

		public int GetAge()
		{
			DateTime now = DateTime.Now;
			int age = now.Year - Birth.Year;
			return (Birth.Date > now.AddYears(-age)) ? age - 1 : age;
		}

    }
}