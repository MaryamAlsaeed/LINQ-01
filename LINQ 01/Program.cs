using LINQ.Models;
using static LINQ.DataSources.Source;

namespace LINQ_01
{
    internal class Program
    {
        public static void Space()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
        public static void QuestionNumber(int number)
        {
            Console.WriteLine();
            Console.WriteLine($"-- Question {number}: --");
            Console.WriteLine("-----------------");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            #region Q1
            QuestionNumber(1);
            var seafood = ProductList.Where(p => p.Category == "Seafood");

            foreach (var product in seafood) 
                Console.WriteLine($"Product: {product.ProductName}\n   Price: {product.UnitPrice}");
            Space();
            #endregion

            #region Q2
            QuestionNumber(2);          
            var names = ProductList.Select(p => p.ProductName);
            foreach (var name in names) Console.WriteLine($"Product Name: {name}");
            Space();

            #endregion

            #region Q3
            QuestionNumber(3);
            var AssendingPrice = ProductList.OrderBy(p => p.UnitPrice);
            foreach (var product in AssendingPrice) Console.WriteLine($"Product: {product.ProductName}\n   Price: {product.UnitPrice}");
            Space();
            #endregion


            #region Q4
            QuestionNumber(4);
            var between = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var product in between) Console.WriteLine($"Product: {product.ProductName}\n   Price: {product.UnitPrice}");
            Space();
            #endregion

            #region Q5
            QuestionNumber(5);
            var inStock = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Spices & Condiments");
            foreach (var product in inStock) Console.WriteLine($"Product: {product.ProductName}\n   In Stock: {product.UnitsInStock}");
            Space();
            #endregion

            #region Q6
            QuestionNumber(6);
            var anonymous = ProductList.Select (p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var product in anonymous) Console.WriteLine($"Product: {product.Name}\n   Price: {product.Price}\n   Status: {product.StockStatus}");
            Space();
            #endregion

            #region Q7
            QuestionNumber(7);
            var productPosition = ProductList.Select((p, i) => $"Product: {p.ProductName}\n   Position: {i + 1}");
            foreach (var position in productPosition) Console.WriteLine(position);
            Space();
            #endregion

            #region Q8
            QuestionNumber(8);
            var CategoryAssending = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var product in CategoryAssending) Console.WriteLine($"Product: {product.ProductName}\n   Category: {product.Category}\n   Price: {product.UnitPrice}");
            Space();
            #endregion

            #region Q9
            QuestionNumber(9);
            var BeveragesDecending = ProductList.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock);
            foreach (var product in BeveragesDecending) Console.WriteLine($"Product: {product.ProductName}\n   Category: {product.Category}\n   In Stock: {product.UnitsInStock}");
            Space();
            #endregion

            #region Q10
            QuestionNumber(10);
            var orders1997 = from c in CustomerList
                             from o in c.Orders
                             where o.OrderDate >= new DateTime(1997)
                             select new { c.CustomerID, o.OrderDate };
            foreach (var order in orders1997) Console.WriteLine($"Customer ID: {order.CustomerID}\n   Order Date: {order.OrderDate}");
            #endregion
        }
    }
}
