namespace P03B_110_寫日期時間範圍的類別
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DateTime dt1 = new DateTime(1997, 1, 28);
			DateTime dt2 = new DateTime(1998, 2, 2);
			DateTimeRange range = new DateTimeRange(dt1, dt2);

			TimeSpan ts = dt2- dt1;

			Console.WriteLine(range.CalcTimeSpan());
			//其實也就等同於直接用Days(?
			//Console.WriteLine(ts.Days);

			//也可以用Console.WriteLine(ts.TotalDays);
			//差別在於 TotalDays可能會顯數出3.69636(天)			

			DateTime dt3 = new DateTime(1997, 2, 2);
			DateTime dt4 = new DateTime(2000, 2, 2);
			DateTimeRange range2 = new DateTimeRange(dt3, dt4);

			Console.WriteLine(range.isOverlap(range2));


        }
	}

	/// <summary>
	/// 日期時間範圍
	/// </summary>
	public class DateTimeRange
	{
        public DateTime Start { get; set; }
		public DateTime End { get; set; }

		public DateTimeRange(DateTime start, DateTime end)
		{
			this.Start = start;
			this.End = end;
		}

		public int CalcTimeSpan()
			=> (End - Start).Days;

		public bool isOverlap(DateTimeRange after)
			=> this.Start <= after.End && after.Start <= this.End;

    }
}