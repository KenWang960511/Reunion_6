using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_160
{
	public class Seat
	{
		public int Rows { get; }
		public int Columns { get; }

		public Seat(int row, int col)
		{
			Rows = row;
			Columns = col;
		}

		public override string ToString()
			=> $"位置在 第{Rows}排 {Columns}號";
	}
}
