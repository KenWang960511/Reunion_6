using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Order
{/// <summary>
 ///設計一個類別來表示一個訂單，擁有訂單編號、訂單日期、商品列表等屬性，以及新增商品、刪除商品、計算總金額等方法，並且支援序列化和反序列化的方法。
 /// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			Order order = new Order("001", DateTime.Now);

			//創建商品
			Product product1 = new Product("PencilCase", 150);
			order.AddProduct (product1);

			Product product2 = new Product("LunchBox", 170);
			order.AddProduct (product2);

			Product product3 = new Product("Novel", 250);
			order.AddProduct (product3);

			//計算總價
			decimal totalPrice = order.CalculateTotalPrice ();
			Console.WriteLine($"總金額是{totalPrice}");

			//序列化
			Order.SerializeToXml("order.xml", order);


			//反序列化
			Order.DeserializeFromXml("order.xml");
		}
	}

	public class Order
	{
		public string OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public List<Product> ProductList { get; set; } //商品列表

		public decimal TotalPrice { get; set; }

        public Order(string orderId, DateTime orderDate)
        {
			this.OrderId = orderId;
			this.OrderDate = orderDate;
			this.ProductList = new List<Product>();
			this .TotalPrice = 0;
            
        }
        public Order()
        {
            
        }


        public decimal CalculateTotalPrice() //計算總金額
		{
			if (ProductList.Count == 0)
			{
				return 0;
			}
			
			foreach (Product product in ProductList)
			{
                TotalPrice = TotalPrice + product.Price;
            }

			return TotalPrice;
		}

		public void AddProduct(Product product)  //新增商品
		{
			ProductList.Add(product);
		}

		public void RemoveProduct(Product product)  //刪除商品
		{
			ProductList.Remove(product);
		}

		//序列化

		public static void SerializeToXml (string filePath, Order order)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order));
			using (FileStream stream = new FileStream (filePath,FileMode.Create ))
			{
				xmlSerializer.Serialize(stream, order);
			}
		}

		public static Order DeserializeFromXml (string filePath)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof (Order));
			using (FileStream stream = new FileStream (filePath, FileMode.Open))
			{
				return (Order )xmlSerializer.Deserialize(stream);
			}
		}



	}

	public class Product
	{
        public string ProductName { get;  private set; }
        public decimal Price { get;  private set; }

        public Product(string productName, decimal price)
        {
			this.ProductName = productName;
			this.Price = price;

        }

	}
}
