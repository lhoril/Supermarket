using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Item : IComparable<Item>
    {
        public enum Category { BEVERAGE = 1, FRUITS, VEGEYABLES, BREAD, MILK_AND_DERIVATIVES, GARDEN, MEAT, SWEETS, SAUCES, FROZEN, CLEANING, FISH, OTHER };
        public enum Packaging { Unit, kg, Package};

        private char currency = '\u20AC';
        private int code;
        private string description;
        private bool onSale;
        private double price;
        private Category category;
        private Packaging packaging;
        private double stock;
        private int minStock;

        public Item(int code, string description, bool onSale, double price, Category category, Packaging package, double stock, int minStock)
        {
            if (stock <= minStock) throw new Exception("THE QUANTITY IN STOCK CAN'T BE EQUALS OR LOWEST OF MINSTOCK");
            this.code = code;
            this.description = description;
            this.onSale = onSale;
            this.price = price;
            this.category = category;
            this.packaging = package;
            this.stock = stock;
            this.minStock = minStock;
        }

        public static void UpdateStock(Item item, double qty)
        {
            item.stock = qty;
        }

        public double Price
        {
            get
            {
                double FinalPrice = price;
                if(onSale) FinalPrice = price - (price * 0.10);
                return FinalPrice;
            }
        }

        public override string ToString()
        {
            string Message = "";
            if (onSale) Message = $"CODE ->{code} DESCRIPTION ->{description} CATEGORY -> {category} STOCK ->{stock} MIN_STOCK ->{minStock} PRICE ->{price} {currency} ON SALE ->Y{Price}";
            else Message = Message = $"CODE ->{code} DESCRIPTION ->{description} CATEGORY -> {category} STOCK ->{stock} MIN_STOCK ->{minStock} PRICE ->{price} {currency} ON SALE ->N";
            return Message;
        }


        public int CompareTo(Item? other)
        {
            throw new NotImplementedException();
        }
    }
}
