using LeaveTimes;
using static LeaveTimes.Program;

namespace LeaveTimes_Test
{
	public class LeaveTests
	{
		[SetUp]
		public void Setup()
		{
		}
		private DateTime dtStart = new DateTime(2023, 5, 20, 8, 0, 0);
		private DateTime dtEnd = new DateTime(2023, 5, 20, 18, 0, 0);

		private DateTime dtStart9 = new DateTime(2023, 5, 20, 9, 0, 0);
		private DateTime dtStart12 = new DateTime(2023, 5, 20, 12, 0, 0);

		private DateTime dtEnd12 = new DateTime(2023, 5, 20, 12, 0, 0);
		private DateTime dtEnd13 = new DateTime(2023, 5, 20, 13, 0, 0);
		private DateTime dtEnd14 = new DateTime(2023, 5, 20, 14, 0, 0);
		private DateTime dtEnd17 = new DateTime(2023, 5, 20, 17, 0, 0);
		private DateTime dtEnd23 = new DateTime(2023, 5, 20, 23, 0, 0);


		[Test]
		public void GetStartTime_���o�а��}�l�ɶ�()
		{
			DateTime expected = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, dtStart.Hour + 1, dtStart.Minute, dtStart.Minute);
			DateTime actual = Leave.GetStartTime(dtStart);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetEndTime_���o�а������ɶ�()
		{
			DateTime expected = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, dtEnd.Hour, dtEnd.Minute, dtEnd.Minute);
			DateTime actual = Leave.GetEndTime(dtEnd);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetToTalLeave_�p��а��ɼƤE�I�ܤ��ȤQ�G�I()
		{
			int expected = 3;
			double actual = Leave.GetToTalLeave(dtStart9, dtEnd12);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetToTalLeave_�p��а��ɼƤE�I�ܤU�Ȥ@�I()
		{
			int expected = 3;
			double actual = Leave.GetToTalLeave(dtStart9, dtEnd13);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetToTalLeave_�p��а��ɼƤE�I�ܤU�Ȥ��I()
		{
			int expected = 7;
			double actual = Leave.GetToTalLeave(dtStart9, dtEnd17);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetToTalLeave_�p��а��ɼƤQ�G�I�ܤU�ȤG�I()
		{
			int expected = 1;
			double actual = Leave.GetToTalLeave(dtStart12, dtEnd14);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetToTalLeave_�p��а��ɼƤE�I�ܤU�Ȥ��I()
		{
			int expected = 8;
			double actual = Leave.GetToTalLeave(dtStart9, dtEnd);
			Assert.AreEqual(expected, actual);
		}

	}
}