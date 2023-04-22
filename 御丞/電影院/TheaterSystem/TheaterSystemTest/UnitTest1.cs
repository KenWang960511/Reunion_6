using TheaterSystem;

namespace TheaterSystemTest
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase (1,1)]
		[TestCase (2,2)]
		[TestCase (3,3)]
		[TestCase (4,4)]
		[TestCase (5,4)]
		[TestCase (2,2)]
		[TestCase (3,4)]
		[TestCase (4,1)]
		public void 劃位測試(int rows, int columns)
		{
			var seat = new Showing(DateTime.Today);
			seat.SetSeat(rows, columns);
			Assert.IsTrue(seat.Seat[rows - 1, columns - 1]);
			Assert.IsFalse(seat.Seat[rows - 1, columns]);
		}

		[TestCase ("2023/4/15 9:00:00", "2023/4/16 9:00:00", "2023/4/17 9:00:00")]
		public void 新增與移除電影時間(DateTime dt1, DateTime dt2, DateTime dt3)
		{
			var movie = new Movie("鈴芽之旅");
			movie.AddShowTime(dt1);
			Assert.AreEqual(1, movie.Showings.Count);
			movie.AddShowTime(dt2);
			Assert.AreEqual(2, movie.Showings.Count);
			movie.AddShowTime(dt2);
			Assert.AreEqual(2, movie.Showings.Count);
			movie.AddShowTime(dt3);
			Assert.AreEqual(3, movie.Showings.Count);
			movie.RemoveShowTime(dt1);
			Assert.AreEqual(2, movie.Showings.Count);
		}

		[Test]
		public void 新增與移除電影()
		{
			var system = new MovieTheaterSystem();
			system.AddMovies("鈴芽之旅");
			Assert.AreEqual(1, system.Movies.Count);
			system.AddMovies("鈴芽之旅");
			Assert.AreEqual(1, system.Movies.Count);
			system.AddMovies("天氣之子");
			Assert.AreEqual(2, system.Movies.Count);
			system.AddMovies("你的名字");
			Assert.AreEqual(3, system.Movies.Count);
			system.RemoveMovie("鬼滅之刃");
			Assert.AreEqual(3, system.Movies.Count);
			system.RemoveMovie("你的名字");
			Assert.AreEqual(2, system.Movies.Count);
		}

		[TestCase ("2023/4/15 9:00:00", "2023/4/16 9:00:00", "2023/4/17 9:00:00")]
		public void 購票刪除票與移除訂單(DateTime dt1, DateTime dt2, DateTime dt3)
		{
			var ticket = new MovieTheaterSystem();
			ticket.AddMovies("鈴芽之旅");
			ticket.Movies["鈴芽之旅"].AddShowTime(dt1);
			Assert.AreEqual(0, ticket.Orders.Count);
			ticket.PurchaseTicket("A001", "鈴芽之旅", dt1, new Seat(3, 3));
			Assert.AreEqual(1, ticket.Orders.Count);
			Assert.AreEqual(1, ticket.Orders["A001"].Tickets.Count);
			ticket.PurchaseTicket("A001", "鈴芽之旅", dt1, new Seat(3, 3));
			Assert.AreEqual(1, ticket.Orders.Count);
			Assert.AreEqual(1, ticket.Orders["A001"].Tickets.Count);
			ticket.PurchaseTicket("A001", "鈴芽之旅", dt1, new Seat(3, 4));
			Assert.AreEqual(1, ticket.Orders.Count);
			Assert.AreEqual(2, ticket.Orders["A001"].Tickets.Count);
			ticket.RemoveTicket("A001", 2);
			Assert.AreEqual(1, ticket.Orders.Count);
			Assert.AreEqual(1, ticket.Orders["A001"].Tickets.Count);
			ticket.RemoveTicket("A001", 1);
			Assert.AreEqual(1, ticket.Orders.Count);
			Assert.AreEqual(0, ticket.Orders["A001"].Tickets.Count);
			ticket.RemoveTicket("A001", 1);
			Assert.AreEqual(0, ticket.Orders.Count);
		}

	}
}