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

        //public CheckOutLine(int num, string FileName, Person cashier, bool active)
        //{
        //    Customer customer = new Customer("1", "arnau", null);
        //    DateTime dateOfPurchase = new DateTime();
        //    StreamReader sr = new StreamReader(FileName);
        //    queue = new Queue<ShoppingCart>();
        //    string line;
        //    line = sr.ReadLine();
        //    string[] camps;
        //    this.number = num;
        //    this.cashier = cashier;
        //    this.active = active;
        //    while (line != null)
        //    {
        //        num++;
        //        camps = line.Split(';');
        //        line = sr.ReadLine();
        //        Item producte = new Item(num, camps[0], false, 0, Convert.ToInt32(camps[1]), Convert.ToChar(camps[2]), Convert.ToDouble(camps[3]), Convert.ToInt32(camps[4]));
        //        this.queue.Append(new ShoppingCart(customer, dateOfPurchase));
        //    }
        //}

        public CheckOutLine(Person responsable, int number)
        {
            queue = new Queue<ShoppingCart>();
            this.number = number;
            this.cashier = responsable;
        }

        public bool CheckIn(ShoppingCart oneShoppintCart)
        {
            if (active)
            {
                queue.Enqueue(oneShoppintCart);
            }
            return active;
        }

        public bool CheckOut()
        {
            double numImport = 0;
            int punts;
            if(active && queue != null)
            {
                ShoppingCart[] carts = queue.ToArray();
                ShoppingCart tmp = carts[0];
                numImport = ShoppingCart.ProcessItems(tmp);
                punts = tmp.RawPointsObtainedAtCheckout(numImport);
                tmp.Customer.AddInvoiceAmount(numImport);
                tmp.Customer.AddPoints(punts);
                cashier.AddInvoiceAmount(numImport);
                cashier.AddPoints(punts);
                tmp.Customer.Active = false;
                queue.Dequeue();
            }
            return active;
        }

        public override string ToString()
        {
            ShoppingCart[] carts = queue.ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < carts.Length; i++)
            {
                sb.Append($"NUMERO DE CAIXA --> {i}");
                sb.Append($"CAIXER/A AL CÀRREC --> {cashier}");
                sb.Append(carts[i].ToString());
            }
            return sb.ToString();
        }
    }
}
