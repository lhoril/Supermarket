using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class ShoppingCart
    {
        private Dictionary<Item, double> shoppingList;
        private Customer customer;
        private DateTime dateOfPurchase;

        public Dictionary<Item, double> ShoppingList
        {
            get { return shoppingList; }
        }

        public Customer Customer
        {
            get { return customer; }
        }

        public DateTime DateOfPurchase
        {
            get { return dateOfPurchase; }
        }

        //public ShoppingCart(int num, string linia)
        //{
        //    shoppingList = new Dictionary<Item, double>();
        //    string[] camps;
        //    camps = linia.Split(';');   
        //    Item producte = new Item(num, camps[0], false, 0, Convert.ToInt32(camps[1]), Convert.ToChar(camps[2]), Convert.ToDouble(camps[3]), Convert.ToInt32(camps[4]));
        //    shoppingList.Add(producte, num);
        //}

        public ShoppingCart(Customer customer, DateTime dateOfPurchase)
        {
            this.customer = customer;
            this.dateOfPurchase = dateOfPurchase;
            customer.Active = true;

            string linia = "";
            shoppingList = new Dictionary<Item, double>();
            string[] camps;
            //camps = linia.Split(';');
            //Item producte = new Item()
        }
        public void AddOne(Item item, double qty)
        {

        }

        public void AddAllRandomly(SortedDictionary<int, Item> warehouse)
        {

        }

        public int RawPointsObtainedAtCheckout(double totalInvoiced)
        {
            return 0;
        }

        public static double ProcessItems(ShoppingCart cart)
        {
            return 0;
        }


    }
}
