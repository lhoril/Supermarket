using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class ShoppingCart
    {
        private Dictionary<Item, double> cart;

        public ShoppingCart(string FileName)
        {
            StreamReader sr = new StreamReader(FileName);
            string line;
            line = sr.ReadLine();
            string[] camps;
            int num = 0;
            while (line != null)
            {
                num++;
                camps = line.Split(';');
                Item producte = new Item(num, camps[0], false, 0, Convert.ToInt32(camps[1]), Convert.ToChar(camps[2]), Convert.ToDouble(camps[3]), Convert.ToInt32(camps[4]));
            }
        }
    }
}
