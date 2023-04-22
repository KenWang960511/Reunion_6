using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_120
{
	public class ContactPerson
	{
		public string Name { get; set; }
		public string CellphoneNumber { get; set; }

		public ContactPerson(string name, string phoneNumber)
		{
			Name = name;
			CellphoneNumber = phoneNumber;
		}
	}
}
