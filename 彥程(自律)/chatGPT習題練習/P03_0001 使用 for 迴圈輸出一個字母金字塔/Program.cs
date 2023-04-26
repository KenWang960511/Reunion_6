using System.Text;
using System.Xml.Linq;

namespace P03_0001_使用_for_迴圈輸出一個字母金字塔
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("請輸入金字塔的高度(1~26)：");
			int number = getInput();

			//看使用者想用大寫或小寫 , 參數寫'A'或'a'。
			//若是要給使用者輸入,還要再寫一個getChar(),然後getInput()要改為getNumber()比較妥當
			List<char> elements = getElements('A'); //可以改成'a'試試看!

			Console.WriteLine($"以下為{number}層的金字塔:");
			Console.WriteLine(getTree(number,elements));
		}

		static int getInput() //持續輸入直至正確,1~26
		{
			int input;

			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out input) && input > 0 && input < 27)
				{	
					return input;
				}
                else
					Console.Write("輸入錯誤,請重新輸入:");
			}
		}


		static List<char> getElements(char character) //將A~Z寫到一個list裡面 並回傳
		{
			List<char> elements = new List<char>();
			if (character == 'A')
			{
				for (char c = 'A'; c <= 'Z'; c++)
				{
					elements.Add(c);
				}
			}
			if (character == 'a')
			{
				for (char c = 'a'; c <= 'z'; c++)
				{
					elements.Add(c);
				}
			}
			return elements;
		}


		static string getTree(int n, List<char> element) // 第一個參數為幾層 , 第二個參數為大寫的list或是小寫的list
		{
			var result = new StringBuilder();

            for (int i = 0; i < n; i++)
			{
				result.Append(new string(' ', n - i - 1)); //串接空格

				for (int m = 0; m < i+1; m++) //串接ABC...
				{
					result.Append(element[m]);
				}

				for (int k = i; k > 0 ; k--) //串接...CBA
				{
					result.Append(element[k-1]);
				}
				result.Append("\n");
			}
			return result.ToString();
		}
	}
}