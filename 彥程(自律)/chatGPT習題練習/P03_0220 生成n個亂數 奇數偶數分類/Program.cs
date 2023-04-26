namespace P03_0220_生成n個亂數_奇數偶數分類
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = GetInput();
            List<int> list = PutNNumbersInList(num);
            IEnumerable<int> odd_numbers = list.Where(m => m % 2 == 1);
            IEnumerable<int> even_numbers = list.Where(m => m % 2 == 0);
            IEnumerable<int> union_numbers = odd_numbers.Union(even_numbers);

            Console.WriteLine("奇數為：");
            Printcollections(odd_numbers);

            Console.WriteLine("偶數為：");
            Printcollections(even_numbers);

            Console.WriteLine("集合為：");
            Printcollections(union_numbers);
        }

        static void Printcollections(IEnumerable<int> numbers) //印出結果
        {
            foreach (int item in numbers)
            {
                Console.Write("{0,3}",item );
            }
            Console.WriteLine();
        }
        static int GetRandomNumber()  // 產出1~99的亂數
        {
            int seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            return random.Next(1, 100);
        }

        static List<int> PutNNumbersInList(int num) //把亂數裝進list中
        {
            List<int> result = new List<int>();
            for (int count = 0; count < num; )
            {
                int random_number = GetRandomNumber();
                if (!result.Contains(random_number)) //不重複才加入
                {
                    result.Add(random_number);
                    count++;
                }
            }
            return result;
        }

        static int GetInput() //持續輸入直至正確,正整數為1.2.3...(不含0)
        {
            int input;

            Console.Write("請輸入一正整數：");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input) && input > 0)
                {
                    return input;
                }

                else
                    Console.Write("輸入錯誤,請重新輸入:");
            }
        }
    }
}