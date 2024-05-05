using System.Text;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine('\u20AC');

            Customer customer = new Customer("12345678A", "Benito Camela", 1234);
            customer.AddPoints(50); 

            Cashier cashier = new Cashier("12345678B", "Elver Galarga", 1609459200);
            cashier.AddPoints(30); 

            Console.WriteLine("Informació del client:");
            Console.WriteLine(customer.ToString());


            Console.WriteLine("Informació del caixer:");
            Console.WriteLine(cashier.ToString());
        }
    }
}