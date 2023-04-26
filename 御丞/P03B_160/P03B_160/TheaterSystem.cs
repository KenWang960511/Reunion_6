using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_160
{
	/// <summary>
	/// 電影院系統
	/// </summary>
	public class TheaterSystem
	{
        public Dictionary<string, Movie> Movies { get; set; }
		public Dictionary<string, Order> Orders { get; set; }

        public TheaterSystem()
        {
			Movies = new Dictionary<string, Movie>();
			Orders = new Dictionary<string, Order>();
		}
        public void AddMovies(string movieName)
		{
			if(!Movies.Keys.Contains(movieName))
				Movies.Add(movieName, new Movie(movieName));	
		}

		public void RemoveMovie(string movieName)
		{
			if(Movies.Keys.Contains(movieName))
				Movies.Remove(movieName);
		}

		public void Buy(string orderId, string name, DateTime showTime, Seat seat)
		{
			if (Orders.Keys.Contains(orderId))
			{
				NewOrder( orderId,  name,  showTime,  seat);
			}
			else
			{
				Orders[orderId].NewTicket(name,showTime, seat);
			}
		}

		private void NewOrder(string orderId, string name, DateTime showTime, Seat seat)
		{
			Orders.Add(orderId, new Order(orderId, name, showTime, seat));
		}

		public void RemoveOrder(string orderId)
		{
			Orders.Remove(orderId);
		}
	}

	/// <summary>
	/// 電影
	/// </summary>
	public class Movie
	{
        public string MovieName { get;}
        public Dictionary<string, Showing> Showings { get; private set; }

        public Movie(string name)
        {
			MovieName = name;
			Showings = new Dictionary<string, Showing>();
        }

		public void AddShowTime(DateTime date)
		{
			Showings.Add(date.ToString("MM/dd HH:mm"), new Showing(date));
		}

		public void RemoveShowTime(DateTime date) 
		{
			string showTime = date.ToString("MM/dd HH:mm");
			if(Showings.Keys.Contains(showTime))
				Showings.Remove(showTime);
		}

		public Dictionary<string, Showing> GetShowings()
		{
			return Showings;
		}

		public void DisplayShowingTime()
		{
			foreach (var kvp in Showings.Keys)
			{
                Console.WriteLine(kvp);
            }
		}

	}

	/// <summary>
	/// 場次
	/// </summary>
	public class Showing
	{
        public DateTime ShowTime { get; set; }
		private bool[,] _Seat;
		public bool[,] Seat { get { return _Seat; }}

		public Showing(DateTime date)
        {
			ShowTime = date;
			_Seat = new bool[5, 5];
        }

		/// <summary>
		/// 訂位方法
		/// </summary>
		/// <param name="rows">輸入1~5</param>
		/// <param name="columns"></param>
		public string SetSeat(int rows, int columns)
		{
			if (rows < 1 || rows > 5) throw new ArgumentOutOfRangeException(nameof(rows), "請確認訂位位置");
			if (columns < 1 || columns > 5) throw new ArgumentOutOfRangeException(nameof(columns), "請確認訂位位置");

			if (_Seat[rows-1, columns-1] != true)
			{
				_Seat[rows-1, columns-1] = true;
				return $"訂位成功，您的位置是第{rows}排的{columns}號。";
			}
			return $"訂位失敗";
		}

    }
}
