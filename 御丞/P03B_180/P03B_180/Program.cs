using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03B_180
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 設計一個類別來表示一個簡單的圖書管理系統，擁有書籍列表、借出記錄列表、歸還記錄列表等屬性，以及新增書籍、借出書籍、歸還書籍、顯示書籍列表等方法，並且支援儲存到檔案和從檔案讀取的方法。
			/// 
			LibarySystem library = new LibarySystem();
			library.AddBook(new Book("The Matrix", "William Gibson"));
			library.BorrwoBook(library.Books[0], "John");
			library.ReturnBook(library.Books[0], "John");
			library.ShowBooksInfo();
			//Library.SaveToFile(library, "library.txt");
			//Library loadedLibrary = Library.LoadFromFile("library.txt");
			//loadedLibrary.ShowBooks();
			Console.ReadKey();
		}

		public class Book
		{
            public string Title { get; }
            public string Author { get; }
			public bool IsBorrow { get; set; }
            public Book(string title, string author)
            {
				Title = title;
				Author = author;
				IsBorrow = false;
            }
        }

		public class BorrowRecord
		{
            public Book Book { get; set; }
			public DateTime BorrowDate { get; set; }
			public string Borrower { get; set; }
            public BorrowRecord(Book book, DateTime borrowDate, string borrower)
            {
				Book = book;
				BorrowDate = borrowDate;
				Borrower = borrower;
            }
        }

		public class ReturnRecord
		{
            public Book Book { get; set; }
            public DateTime ReturnDate { get; set; }
			public string Borrower { get; set; }
			public ReturnRecord(Book book, DateTime returnDate, string borrower)
			{
				Book = book;
				ReturnDate = returnDate;
				Borrower = borrower;
			}
		}

		public class LibarySystem
		{
            public List<Book> Books { get; set; }
            public List<BorrowRecord> BorrowRecords { get; set; }
            public List<ReturnRecord> ReturnRecords { get; set; }
            public LibarySystem()
            {
				Books = new List<Book>();
				BorrowRecords = new List<BorrowRecord>();
				ReturnRecords = new List<ReturnRecord>();
            }

			public void AddBook(Book book)
			{
				Books.Add(book);
			}

			public string BorrwoBook(Book book, string borrower)
			{
				if (book.IsBorrow)
				{
					return "書已被借出";
				}
				else
				{
					book.IsBorrow = true;
                    Console.WriteLine(AddBorrowRecord(book, borrower));
                    return "借書成功!!";
				}
			}
			public string ReturnBook(Book book, string borrower)
			{
				if (book.IsBorrow)
				{
					book.IsBorrow = false;
                    Console.WriteLine(AddReturnRecord(book, borrower));
					return "還書成功";
				}
				else
				{
					return "書已歸還";
				}
			}

			public string AddBorrowRecord(Book book, string borrower)
			{
				BorrowRecords.Add(new BorrowRecord(book, DateTime.Now, borrower));
				return "新增借書紀錄完成";
			}

			public string AddReturnRecord(Book book, string borrower)
			{
				ReturnRecords.Add(new ReturnRecord(book, DateTime.Now, borrower));
				return "新增還書紀錄完成";
			}

			public void ShowBooksInfo()
			{
				foreach (Book book in Books) 
				{
                    Console.WriteLine($"書名: {book.Title}\n作者: {book.Author}\n書籍狀態: {(book.IsBorrow ? "已外借" : "可借用")}");
                }
			}

		}
	}
}
