using System.Text;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine('\u20AC');

            Customer customer = new Customer("12345678A", "Benito Camela", 1234);
            customer.AddPoints(50);
            customer.AddInvoiceAmount(10);

            Cashier cashier = new Cashier("12345678B", "Elver Galarga", 1609459200);
            cashier.AddPoints(30);
            cashier.AddInvoiceAmount(50);

            Console.WriteLine("Informació del client:");
            Console.WriteLine(customer.ToString());

            Console.WriteLine("Informació del caixer:");
            Console.WriteLine(cashier.ToString());

            Console.WriteLine("------------------------------");
            Item item1 = new Item(1, "Poma", true, 1.99, (int)Item.Category.FRUITS, (char)Item.Packaging.Unit, 100, 20);
            Item item2 = new Item(2, "Suc detaronja", false, 2.49, (int)Item.Category.BEVERAGE, (char)Item.Packaging.Unit, 50, 10);
            Item item3 = new Item(3, "Pa", true, 1.29, (int)Item.Category.BREAD, (char)Item.Packaging.Unit, 80, 15);

            Console.WriteLine("Informació dels articles:");
            Console.WriteLine(item1.ToString());
            Console.WriteLine(item2.ToString());
            Console.WriteLine(item3.ToString());

            Item.UpdateStock(item1, 90);

            Console.WriteLine("Preu actualitzat de l'article 1:");
            Console.WriteLine(item1.ToString());

            int comparacio = item1.CompareTo(item2);
            Console.WriteLine($"Comparació longitud de item1 i item2: {comparacio}");

            Console.WriteLine("------------------------------");
            Suppermarket supermarket = new Suppermarket("Supermarket", "123 Main", "CASHIERS.csv", "CUSTOMERS.csv", "GROCERIES.csv", 3);
            //SortedSet<Item> items = supermarket.GetItemsByStock(); <-- 2n Part
            //foreach (Item item in items)
            //{
            //    Console.WriteLine(item.ToString());
            //}
        }
    }
}