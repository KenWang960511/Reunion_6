namespace P03_0003_顯示某一天_格式為yyyy_MM_dd_
{
    internal class Program
    {
        //單純練習如何使用DateTime這個類別 以及其幾個屬性和方法
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;

            int days1 = DateTime.DaysInMonth(dt.Year, 1);
            int days2 = DateTime.DaysInMonth(dt.Year, 3);

            DateTime dt1 = new DateTime(dt.Year, 1, days1);
            DateTime dt2 = new DateTime(dt.Year, 3, days2);
            DateTime dt3 = new DateTime(dt.Year, 12, 28);

            DateTime result1 = dt1.AddMonths(1);
            DateTime result2 = dt2.AddMonths(-1);
            DateTime result3 = dt3.AddDays(4);
            DateTime result4 = dt2.AddMonths(1);

            Console.WriteLine(result1.ToString("yyyy/MM/dd")); //今年一月底的下一個月為?
            Console.WriteLine(result2.ToString("yyyy/MM/dd")); //三月底的上一個月為?
            Console.WriteLine(result3.ToString("yyyy/MM/dd")); //今年12/28的四天之後為?
            Console.WriteLine(result4.ToString("yyyy/MM/dd")); //三月底的下一個月為?
        }
    }
}

