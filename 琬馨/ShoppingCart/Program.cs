using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShoppingCart
{/// <summary>
 /// 設計一個類別來表示一個購物車，擁有添加商品、移除商品、計算總金額等方法，並且支援儲存到檔案和從檔案讀取的方法。
 /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();

            //添加商品到購物車
            Product product1 = new Product("Pen", 10);
            cart.AddProduct(product1);

            Product product2 = new Product("Eraser", 5);
            cart.AddProduct(product2);

            Product product3 = new Product("Ruler", 15);
            cart.AddProduct(product3);

            //算總價
            decimal totalPrice = cart.CalculateTotalPrice();
            Console.WriteLine($"總金額是{totalPrice}");

            //將購物車資訊存入檔案
            string filePath = "C:\\shoppingcart.dat";
            ShoppingCart.SaveToFile(cart, filePath);



        }
    }

    public class ShoppingCart
    {
        private List<Product> products;
        public decimal TotalPrice { get; set; }

        public ShoppingCart()
        {
            this.products = new List<Product>();
            this.TotalPrice = 0;

        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public decimal CalculateTotalPrice()
        {
            if (products.Count == 0)
            {
                return 0;
            }

            foreach (Product product in products)
            {
                TotalPrice = TotalPrice + product.Price;
            }
            return TotalPrice;
        }

        //儲存到檔案
        public static void SaveToFile(ShoppingCart cart, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(stream, cart);
            }
        }

        //從檔案讀取
        public static ShoppingCart LoadFromFile(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (ShoppingCart)formatter.Deserialize(stream);
            }

        }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Product(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }
    }







}
