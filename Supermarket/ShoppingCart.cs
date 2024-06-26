﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            shoppingList = new Dictionary<Item, double>();

            //string linia = "";
            //int num=0;
            //string[] camps;
            //camps = linia.Split(';');
            //Item producte = new Item(num, camps[0], false, 0, Convert.ToInt32(camps[1]), Convert.ToChar(camps[2]), Convert.ToDouble(camps[3]), Convert.ToInt32(camps[4]));
            //shoppingList.Add(producte, num);
        }

        public void AddOne(Item item, double qty)
        {
            if(item.Stock < qty)
            {
                qty = item.Stock;
            }

            if (item.PackagingType == "Unit" && item.PackagingType == "Package")
            {
                if(!shoppingList.Keys.Contains(item))
                    shoppingList.Add(item, Math.Truncate(qty));
            }
            else //AQUI SÓN KG
            {
                if (!shoppingList.Keys.Contains(item)) 
                    shoppingList.Add(item, qty);
            }
            
        }

        public void AddAllRandomly(SortedDictionary<int, Item> warehouse)
        {
            int rndItem = 0;
            int qty = 0;
            int nVoltes= 0;
            Random rnd = new Random();
            nVoltes = rnd.Next(1, 11);
            Item[] items = warehouse.Values.ToArray(); //CREEM UNA ARRAY A PARTIR D'UN DICCIONARI
            for (int i = 0; i < nVoltes; i++)
            {
                rndItem = rnd.Next(1, warehouse.Count);
                qty = rnd.Next(1, 6);
                AddOne(items[rndItem],qty);
            }
        }

        public int RawPointsObtainedAtCheckout(double totalInvoiced)
        {
            double punts=0;
            if (totalInvoiced >=20)
            {
                punts = Math.Truncate(totalInvoiced * 0.1);
            }

            return (int)punts;
        }

        public static double ProcessItems(ShoppingCart cart)
        {
            double qty;
            double preuTotalItem = 0;
            
            foreach (KeyValuePair<Item,double> obj in cart.ShoppingList)
            {
                qty = obj.Value;
                if (obj.Key.Stock < qty)
                    qty = obj.Key.Stock;
                
                Item.UpdateStock(obj.Key, qty-obj.Key.Stock); //DISMINUIM STOCK  

                preuTotalItem += obj.Key.Price * qty;                
            }
            return Math.Round(preuTotalItem,2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string onSale = "";
            sb.AppendLine("*********");
            sb.AppendLine($"INFO CARRITO DE COMPRA CLIENTE ->{customer.FullName}");
            foreach (KeyValuePair<Item, double> key in shoppingList)
            {
                if (key.Key.OnSale) onSale = "(*)"; //Si te estrelleta te descompte
                sb.AppendLine($"{key.Key.Description,-10} - CAT-->{key.Key.GetCategory,10} - QTY-->{key.Key.Stock,10} - UNIT PRICE-->{key.Key.Price,10} € {onSale}");
            }
            sb.Append("*****FI CARRITO COMPRA*****");
            return sb.ToString();
        }
    }
}
