using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_190
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 190 設計一個類別來表示一個簡單的銀行帳戶系統，擁有帳戶號碼、戶名、餘額等屬性，以及存款、提款、轉帳、顯示帳戶資訊等方法，並且支援記錄交易紀錄和查詢交易紀錄等功能。
			/// 
			Bank firstBank = new Bank("First Bank");
            Console.WriteLine(firstBank.OpenAccount("Ken"));
			Console.WriteLine(firstBank.Deposit("202304240",50));
			Console.WriteLine(firstBank.OpenAccount("hgjgjy"));
            Console.WriteLine(firstBank.Remit("202304240", "202304241", 30));
			firstBank.ShowAccountInfo("202304240");
			firstBank.ShowAccountInfo("202304241");
            Console.WriteLine("==========================================================================");
            firstBank.ShowTrrnsactionRecords();

			Console.ReadLine();
		}


		public class Account
		{
			public string AccountNumber { get; }
			public string Name { get; set; }
			public decimal Balance { get; private set; }

            public Account(string accountNumber, string name)
            {
				AccountNumber = accountNumber;
				Name = name;
				Balance = 0;
            }
			/// <summary>
			/// 存款
			/// </summary>
			/// <param name="money">存入金額</param>
			/// <returns></returns>
			public string Deposit(decimal money)
			{
				if (money <= 0) return "請輸入正確的存款金額";

				Balance += money;
				return $"帳號: {AccountNumber}\t存款成功，存入 ${money:N}，目前餘額 ${Balance:N}";
			}
			/// <summary>
			/// 提款
			/// </summary>
			/// <param name="money">提取金額</param>
			/// <returns></returns>
			public string Withdraw(decimal money)
			{
				if (money <= 0) return "請輸入正確的提款金額";

				if ( Balance - money < 0)
				{
					return $"餘額不足，您的餘額為 {Balance:N}";
				}
				else
				{
					Balance -= money;
					return $"帳號: {AccountNumber}\t提款成功，提取 ${money:N}，目前餘額為 ${Balance:N}";
				}
			}
			public override string ToString()
			{
				return $@"帳號: {AccountNumber}
戶名: {Name}
餘額: ${Balance:N}";
			}

		}

		public class Bank
		{
            public string Name { get; }
            public Dictionary<string, Account> Accounts { get; private set; }

			public List<string> TransactionRecords { get; private set; }

            public Bank(string name)
            {
				Name = name;
				Accounts = new Dictionary<string, Account>();
				TransactionRecords = new List<string>();

			}

			public string OpenAccount(string name)
			{
				string accountNumber = CreateAccountNumber();
				Accounts.Add(accountNumber, new Account(accountNumber, name));
				return AddTrrnsactionRecords($"建立帳號成功\r\n{Accounts[accountNumber]}");
			}

			public string CreateAccountNumber()
			{
				//DateTime dateTime = DateTime.Now;
				//return dateTime.ToString("yyyyMMddHHmmss");
				DateTime dateTime = DateTime.Today;
				return dateTime.ToString("yyyyMMdd") + Accounts.Count;
			}

			public string Deposit(string accountNumber, decimal money)
				=> AddTrrnsactionRecords(Accounts[accountNumber].Deposit(money));

			public string Withdraw(string accountNumber, decimal money)
				=> AddTrrnsactionRecords(Accounts[accountNumber].Withdraw(money));

			public void ShowAccountInfo(string accountNumber)
			{
				if (Accounts.ContainsKey(accountNumber))
					Console.WriteLine(Accounts[accountNumber]);
				else
                    Console.WriteLine("此帳戶不存在");
            }

			public string Remit(string senderAccountNumber, string receiverAccountNumber, decimal money)
			{
				if (!Accounts.ContainsKey(senderAccountNumber)) return AddTrrnsactionRecords($"匯款失敗，帳號{senderAccountNumber}不存在。");
				if (!Accounts.ContainsKey(receiverAccountNumber)) return AddTrrnsactionRecords($"匯款失敗，帳號{receiverAccountNumber}不存在。");

				if (money <= 0) return AddTrrnsactionRecords($"請輸入正確的匯款金額");

				Accounts[senderAccountNumber].Withdraw(money);
				Accounts[receiverAccountNumber].Deposit(money);
				return AddTrrnsactionRecords($"匯款成功，已從 {senderAccountNumber} 匯出 ${money} 到 {receiverAccountNumber}");
			}

			public string AddTrrnsactionRecords(string message)
			{
				TransactionRecords.Add(message);
				return message;
			}

			public void ShowTrrnsactionRecords()
			{
				foreach(var record in TransactionRecords)
					Console.WriteLine(record);
			}

		}

	}
}
