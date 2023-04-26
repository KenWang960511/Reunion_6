using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_160
{
	/// <summary>
	/// 訂單
	/// </summary>
	public class Order
	{
		public string Id { get; }
		public Dictionary<int, Ticket> Tickets { get; private set; }
		public Order(string id, string name, DateTime date, Seat seat)
		{
			Id = id;
			Tickets = new Dictionary<int, Ticket> { { 1, new Ticket(name, date, seat) } };
		}

		public string NewTicket(string name, DateTime date, Seat seat)
		{
			var index = Tickets.Count + 1;
			if (Tickets.Keys.Contains(index))
			{
				return "訂票失敗";
			}
			else
			{
				Tickets.Add(index, new Ticket(name, date, seat));
				return $"訂票成功，@{DateTime.Now}";
			}
		}

		public void RemoveTicket()
		{

		}

	}

	public class Ticket
	{
		public string MovieName { get; }
		public DateTime ShowTime { get; }
		public int Rows { get; }
		public int Columns { get; }

		public Ticket(string name, DateTime date, Seat seat)
		{
			MovieName = name;
			ShowTime = date;
			Rows = seat.Rows;
			Columns = seat.Columns;
		}

		public override string ToString()
		{
			return $@"電影名稱: {MovieName}
放映時間: {ShowTime:MM/dd HH:mm}
座位為: 第{Rows}排 {Columns}號";
		}
	}
}
