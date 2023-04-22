using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace P03B_140
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/// 140 設計一個類別來表示一個訂單，擁有訂單編號、訂單日期、商品列表等屬性，以及新增商品、刪除商品、計算總金額等方法，並且支援序列化和反序列化的方法。
			///
			Order order_One = new Order("A0000001", DateTime.Today);
			var product1 = new Product() { Name = "Apple", Price = 36 };
			var product2 = new Product() { Name = "Bag", Price = 420 };
			var product3 = new Product() { Name = "Chair", Price = 550 };
			var product4 = new Product() { Name = "Desk", Price = 2580 };
			var product5 = new Product() { Name = "Egg", Price = 85 };
			order_One.AddProduct(product1);
			order_One.AddProduct(product2);
			order_One.AddProduct(product3);
			order_One.AddProduct(product4);
			order_One.AddProduct(product5);

			foreach (var item in order_One.ProductList) 
			{
                Console.WriteLine(item.Name);
            }

			Order.Serialize(order_One, "Test.bin");
			var order_Two = Order.Deserialize("Test.bin");
			Console.WriteLine(order_Two.GetSumPrice());

			Console.ReadLine();
		}
	}

	[Serializable]//必須加上的序列化特性
	public class Order
	{
        public string Id { get;}
        public DateTime OrderDate { get;}
		public List<Product> ProductList { get; private set; }

        public Order(string id, DateTime date)
        {
            Id = id;
			OrderDate = date;
			ProductList = new List<Product>();
        }
		
		public void AddProduct(Product product)
		{
			ProductList.Add(product);
		}
		public List<Product> GetProductList()
			=> ProductList;
		public void RemoveProduct(Product product)
		{
				ProductList.Remove(product);
		}
		public int GetSumPrice()
			=> ProductList.Sum(x => x.Price);


		// 序列化是將物件的狀態轉換成可保存或傳輸之形式的程序。  // Ex: *.bin, *.xsd (XML), *.json
		// 序列化的互補方法是還原序列化，它將資料流轉換成為物件。
		// 這些程式會一起允許儲存和傳輸資料。

		public static void Serialize(Order order, string fileName)
		{
			using (Stream stream = File.Open(fileName, FileMode.Create))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, order);
			}
		}

		public static Order Deserialize(string fileName)
		{
			using (Stream stream = File.Open(fileName, FileMode.Open))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				return (Order)formatter.Deserialize(stream);
			}
		}

	}

	[Serializable]//必須加上的序列化特性
	public class Product
	{
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
