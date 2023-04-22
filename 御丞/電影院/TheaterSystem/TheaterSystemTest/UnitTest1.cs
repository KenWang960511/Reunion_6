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
		public void �������(int rows, int columns)
		{
			var seat = new Showing(DateTime.Today);
			seat.SetSeat(rows, columns);
			Assert.IsTrue(seat.Seat[rows - 1, columns - 1]);
			Assert.IsFalse(seat.Seat[rows - 1, columns]);
		}

		[TestCase ("2023/4/15 9:00:00", "2023/4/16 9:00:00", "2023/4/17 9:00:00")]
		public void �s�W�P�����q�v�ɶ�(DateTime dt1, DateTime dt2, DateTime dt3)
		{
			var movie = new Movie("�a�ޤ���");
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
		public void �s�W�P�����q�v()
		{
			var system = new MovieTheaterSystem();
			system.AddMovies("�a�ޤ���");
			Assert.AreEqual(1, system.Movies.Count);
			system.AddMovies("�a�ޤ���");
			Assert.AreEqual(1, system.Movies.Count);
			system.AddMovies("�Ѯ𤧤l");
			Assert.AreEqual(2, system.Movies.Count);
			system.AddMovies("�A���W�r");
			Assert.AreEqual(3, system.Movies.Count);
			system.RemoveMovie("�������b");
			Assert.AreEqual(3, system.Movies.Count);
			system.RemoveMovie("�A���W�r");
			Assert.AreEqual(2, system.Movies.Count);
		}

		[TestCase ("2023/4/15 9:00:00", "2023/4/16 9:00:00", "2023/4/17 9:00:00")]
		public void �ʲ��R�����P�����q��(DateTime dt1, DateTime dt2, DateTime dt3)
		{
			var ticket = new MovieTheaterSystem();
			ticket.AddMovies("�a�ޤ���");
			ticket.Movies["�a�ޤ���"].AddShowTime(dt1);
			Assert.AreEqual(0, ticket.Orders.Count);
			ticket.PurchaseTicket("A001", "�a�ޤ���", dt1, new Seat(3, 3));
			Assert.AreEqual(1, ticket.Orders.Count);
			Assert.AreEqual(1, ticket.Orders["A001"].Tickets.Count);
			ticket.PurchaseTicket("A001", "�a�ޤ���", dt1, new Seat(3, 3));
			Assert.AreEqual(1, ticket.Orders.Count);
			Assert.AreEqual(1, ticket.Orders["A001"].Tickets.Count);
			ticket.PurchaseTicket("A001", "�a�ޤ���", dt1, new Seat(3, 4));
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