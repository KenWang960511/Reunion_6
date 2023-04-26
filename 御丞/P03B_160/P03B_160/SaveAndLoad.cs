using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_160
{
	public class SaveAndLoad
	{
		public void Save(string path, Order data)
		{
			using (StreamWriter sw = new StreamWriter(path))
			{
				foreach (var info in data.Tickets.Values)
				{
					sw.WriteLine($"{data.Id}, {info.MovieName}, {info.ShowTime}, {info.Rows}, {info.Columns}");
				}
			}
		}
		public Order Read(string path)
		{
			Order data = null;
			string line;
			using (StreamReader sr = new StreamReader(path))
			{
				while ((line = sr.ReadLine()) != null)
				{
					string[] parts = line.Split(',');
					if (!DateTime.TryParse(parts[2], out DateTime dt1)) continue;
					if (!int.TryParse(parts[3], out int rows)) continue;
					if (!int.TryParse(parts[4], out int columns)) continue;
					var seat = new Seat(rows, columns);
					if (data == null || data.Id != parts[0])
					{
						data = new Order(parts[0], parts[1], dt1, seat);
					}
					else
					{
						data.NewTicket(parts[1], dt1, seat);
					}
				}
			}
			return data;
		}
	}
}
