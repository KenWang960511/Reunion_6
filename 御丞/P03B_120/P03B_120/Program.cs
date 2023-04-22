using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_120
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 120 設計一個類別來表示一個學生，擁有姓名、生日、成績、聯絡人等屬性，以及計算年齡的方法，並且支援按姓名排序和按成績排序的方法。
			/// 
			var classRoom = new ClassRoom();
			classRoom.AddStudentInfo("Cool", new DateTime(1999, 02, 3), 76, "Wandy", "09987654321");
			classRoom.AddStudentInfo("Frank", new DateTime(1993, 09, 24), 85, "Jenny", "09456987123");
			classRoom.AddStudentInfo("Alan", new DateTime(1997, 11, 11), 80, "Fibi", "09123456789");
			classRoom.AddStudentInfo("Ryan", new DateTime(1991, 5, 8), 69, "Ash", "09654789321");
			foreach	(var item in classRoom.Students)
			{
                Console.WriteLine(item);
            }
			classRoom.SortByName();
            Console.WriteLine(new string('=',10));
            foreach (var item in classRoom.Students)
			{
				Console.WriteLine(item);
			}
			Console.ReadKey();
		}
	}


}
