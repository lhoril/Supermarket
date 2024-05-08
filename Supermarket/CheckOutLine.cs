using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class CheckOutLine
    {
        private int number;
        private Queue<ShoppingCart> queue;
        private Person cashier;
        private bool active;

        public CheckOutLine(int num, string FileName, Person cashier, bool active)
        {
            Customer customer = new Customer("1", "arnau", null);
            DateTime dateOfPurchase = new DateTime();
            StreamReader sr = new StreamReader(FileName);
            queue = new Queue<ShoppingCart>();
            string line;
            line = sr.ReadLine();
            string[] camps;
            this.number = num;
            this.cashier = cashier;
            this.active = active;
            while (line != null)
            {
                num++;
                camps = line.Split(';');
                line = sr.ReadLine();
                Item producte = new Item(num, camps[0], false, 0, Convert.ToInt32(camps[1]), Convert.ToChar(camps[2]), Convert.ToDouble(camps[3]), Convert.ToInt32(camps[4]));
                this.queue.Append(new ShoppingCart(customer, dateOfPurchase));
            }
        }
    }
}
