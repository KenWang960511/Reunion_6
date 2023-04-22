using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_060
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 060 設計一個類別來表示一個員工，擁有姓名、薪水、編號三個屬性，以及調薪的方法。
			/// 
			Employee ep = new Employee("Ken", 100, "A001");
            Console.WriteLine(ep.Salary);
            ep.AdjustSalary(100);
            Console.WriteLine(ep.Salary);
			Console.ReadKey();
        }
	}
	class Employee
	{
        public string Name { get; set; }
        public int Salary { get; set; }
        public string EmployeeId { get; set; }

		public Employee(string name, int salary, string id) 
		{ 
			Name = name;
			Salary = salary;
			EmployeeId = id;
		}

		public void AdjustSalary(double magnification)
		{
			double newSalary = Math.Round((double)Salary * magnification, MidpointRounding.AwayFromZero);
			Salary = Convert.ToInt32(newSalary);
		}


    }
}
