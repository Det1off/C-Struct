namespace ConsoleApp6
{

    public enum ProductCategory
    {
        Food,
        Electronics,
        Clothing,
        Household,
        Other
    }

    public struct Product
    {
        public string Name;
        public int Quantity;
        public decimal UnitPrice;
        public decimal Discount;
        public ProductCategory Category;

        public Product(string name, int quantity, decimal unitPrice, decimal discount, ProductCategory category)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
            Category = category;
        }

        public decimal GetTotalPrice()
        {
            decimal discountMultiplier = 1 - Discount / 100;
            return Quantity * UnitPrice * discountMultiplier;
        }
    }

    public struct CashReceipt
    {
        private List<Product> _products;

        public CashReceipt()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void PrintReceipt()
        {
            Console.WriteLine("Кассовый чек");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Наименование       Кол-во Цена   Скидка  Итого");
            Console.WriteLine(new string('-', 40));

            decimal total = 0;

            foreach (var product in _products)
            {
                decimal totalPrice = product.GetTotalPrice();
                total += totalPrice;
                Console.WriteLine(
                    $"{product.Name,-18} {product.Quantity,-6} {product.UnitPrice,6:C} {product.Discount,6}% {totalPrice,8:C}");
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Итого: {total:C}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CashReceipt receipt = new CashReceipt();

            receipt.AddProduct(new Product("Яблоки", 2, 50, 10, ProductCategory.Food));
            receipt.AddProduct(new Product("Футболка", 1, 1200, 15, ProductCategory.Clothing));
            receipt.AddProduct(new Product("Чайник", 1, 2500, 5, ProductCategory.Household));

            receipt.PrintReceipt();
        }

    }
}
