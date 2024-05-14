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

        public CheckOutLine(Person responsable, int number)
        {
            queue = new Queue<ShoppingCart>();
            this.number = number;
            this.cashier = responsable;
            active = true;
        }

        public bool CheckIn(ShoppingCart oneShoppintCart)
        {
            if (active)
            {
                queue.Enqueue(oneShoppintCart);
            }
            return active;
        }

        public bool Empty
        {
            get { return queue.Count == 0; }
        }

        public Person Casher
        {
            get { return this.cashier; }
        }

        public bool CheckOut()
        {
            double numImport = 0;
            int punts;
            if(active && queue.Count != 0)
            {
                ShoppingCart carts = queue.ElementAt(0);
                numImport = ShoppingCart.ProcessItems(queue.ElementAt(0));
                punts = queue.ElementAt(0).RawPointsObtainedAtCheckout(numImport);
                carts.Customer.AddInvoiceAmount(numImport);
                carts.Customer.AddPoints(punts);
                cashier.AddInvoiceAmount(numImport);
                cashier.AddPoints(punts);
                queue.ElementAt(0).Customer.Active = false;
                queue.Dequeue();
            }
            return active;
        }

        public override string ToString()
        {
            ShoppingCart[] carts = queue.ToArray();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NUMERO DE CAIXA --> {number}");
            sb.AppendLine($"CAIXER/A AL CÀRREC --> {cashier.FullName}");
            for (int i = 0; i < carts.Length; i++)
            {
                sb.AppendLine(carts[i].ToString());
            }
            if (queue.Count == 0) sb.AppendLine("CUA BUIDA");
            return sb.ToString();
        }
    }
}
