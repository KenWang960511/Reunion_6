using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterSystem
{
	/// <summary>
	/// 電影院系統
	/// 
	/// 屬性: 電影、訂單
	/// 
	/// 方法: 新增電影、移除電影、購票、新增訂單、移除訂單
	/// 
	/// </summary>
	public class MovieTheaterSystem
	{
		public Dictionary<string, Movie> Movies { get; set; }
		public Dictionary<string, Order> Orders { get; set; }

		public MovieTheaterSystem()
		{
			Movies = new Dictionary<string, Movie>();
			Orders = new Dictionary<string, Order>();
		}
		/// <summary>
		/// 新增電影
		/// </summary>
		/// <param name="movieName">電影名稱</param>
		public void AddMovies(string movieName)
		{
			if(!Movies.Keys.Contains(movieName))
				Movies.Add(movieName, new Movie(movieName));
		}
		/// <summary>
		/// 移除電影
		/// </summary>
		/// <param name="movieName">電影名稱</param>
		public void RemoveMovie(string movieName)
		{
			if(Movies.Keys.Contains(movieName))
				Movies.Remove(movieName);
		}
		/// <summary>
		/// 購票
		/// </summary>
		/// <param name="orderId">訂單號碼</param>
		/// <param name="name">電影名稱</param>
		/// <param name="showTime">電影時刻</param>
		/// <param name="seat">座位</param>
		public void PurchaseTicket(string orderId, string name, DateTime showTime, Seat seat)
		{
			string showingTime = showTime.ToString("MM/dd HH:mm");
			if (!Orders.Keys.Contains(orderId))
			{
				NewOrder(orderId, name, showTime, seat);
				Movies[name].Showings[showingTime].SetSeat(seat.Rows, seat.Columns);
				return;
			}
			else if (Movies[name].Showings[showingTime].SetSeat(seat.Rows, seat.Columns) == "訂位失敗")
			{
				return;
			}
			else
			{
				Orders[orderId].NewTicket(name, showTime, seat);
				Movies[name].Showings[showingTime].SetSeat(seat.Rows, seat.Columns);
			}
		}
		/// <summary>
		/// 新增訂單
		/// </summary>
		/// <param name="orderId">訂單號碼</param>
		/// <param name="name">電影名稱</param>
		/// <param name="showTime">電影時刻</param>
		/// <param name="seat">座位</param>
		private void NewOrder(string orderId, string name, DateTime showTime, Seat seat)
		{
			Orders.Add(orderId, new Order(orderId, name, showTime, seat));
		}

		public void RemoveTicket(string orderId, int index)
		{
			if (Orders.Count == 0) return;
			if (!Orders.Keys.Contains(orderId)) return;
			
			if (Orders[orderId].Tickets.Count == 0)
			{
				RemoveOrder(orderId);
			}
			else if (Orders[orderId].Tickets.Keys.Contains(index))
			{
				Orders[orderId].RemoveTicket(index);
			}
		}

		/// <summary>
		/// 移除訂單
		/// </summary>
		/// <param name="orderId">訂單號碼</param>
		private void RemoveOrder(string orderId)
		{
			Orders.Remove(orderId);
		}
	}

	/// <summary>
	/// 電影
	/// 
	/// 屬性: 電影名稱、放映時刻
	/// 
	/// 方法: 新增放映時刻、移除放映時刻、展示所有放映時刻
	/// 
	/// </summary>
	public class Movie
	{
		public string MovieName { get; }
		public Dictionary<string, Showing> Showings { get; private set; }

		public Movie(string name)
		{
			MovieName = name;
			Showings = new Dictionary<string, Showing>();
		}
		/// <summary>
		/// 新增放映時刻
		/// </summary>
		/// <param name="date">時間</param>
		public void AddShowTime(DateTime date)
		{
			string showTime = date.ToString("MM/dd HH:mm");
			if(!Showings.Keys.Contains(showTime))
				Showings.Add(showTime, new Showing(date));
		}
		/// <summary>
		/// 移除放映時刻
		/// </summary>
		/// <param name="date">時間</param>
		public void RemoveShowTime(DateTime date)
		{
			string showTime = date.ToString("MM/dd HH:mm");
			if (Showings.Keys.Contains(showTime))
				Showings.Remove(showTime);
		}
		/// <summary>
		/// 展示所有放映時刻
		/// </summary>
		public void DisplayShowingTime()
		{
			foreach (var kvp in Showings.Keys)
			{
				Console.WriteLine(kvp);
			}
		}

	}

	/// <summary>
	/// 場次 (放映時刻)
	/// 
	/// 欄位: 座位  (暫定只有5*5)
	/// 屬性: 放映時刻、座位
	/// 
	/// 方法: 劃位
	/// 
	/// </summary>
	public class Showing
	{
		public DateTime ShowTime { get; set; }
		private bool[,] _Seat;
		public bool[,] Seat { get { return _Seat; } }

		public Showing(DateTime date)
		{
			ShowTime = date;
			_Seat = new bool[5, 5];
		}

		/// <summary>
		/// 訂位方法
		/// </summary>
		/// <param name="rows">輸入1~5</param>
		/// <param name="columns">輸入1 ~ 5</param>
		public string SetSeat(int rows, int columns)
		{
			if (rows < 1 || rows > 5) throw new ArgumentOutOfRangeException(nameof(rows), "請確認訂位位置");
			if (columns < 1 || columns > 5) throw new ArgumentOutOfRangeException(nameof(columns), "請確認訂位位置");

			if (_Seat[rows - 1, columns - 1] != true)
			{
				_Seat[rows - 1, columns - 1] = true;
				return $"訂位成功，您的位置是第{rows}排的{columns}號。";
			}
			return $"訂位失敗";
		}

	}
}
