using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheaterSystem
{
	/// <summary>
	/// 訂單
	/// 
	/// 屬性: 訂單編號、電影票
	/// 
	/// 方法: 新增電影票
	/// 
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
		/// <summary>
		/// 新增電影票
		/// </summary>
		/// <param name="name">電影名稱</param>
		/// <param name="date">放映時間</param>
		/// <param name="seat">座位</param>
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
		public string RemoveTicket(int index)
		{
			if (Tickets.Keys.Contains(index))
			{
				Tickets.Remove(index);
				return $"刪除成功，@{DateTime.Now}";
			}
			else
			{
				return "刪除失敗";
			}
		}

	}
	/// <summary>
	/// 電影票
	/// 
	/// 屬性: 電影名稱、放映時間、第幾排、幾號
	/// 
	/// </summary>
	public class Ticket
	{
		public string MovieName { get; }
		public DateTime ShowTime { get; }
        public Seat Seats { get; set; }
        public Ticket(string name, DateTime date, Seat seat)
		{
			MovieName = name;
			ShowTime = date;
			Seats = seat;
		}

		public override string ToString()
		{
			return $@"電影名稱: {MovieName}
放映時間: {ShowTime:MM/dd HH:mm}
座位為: 第{Seats.Rows}排 {Seats.Columns}號";
		}
	}
}
