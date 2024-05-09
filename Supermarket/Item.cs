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
        private double minStock;

        public Item(int code, string description, bool onSale, double price, int category, char type, double stock, double minStock)
        {
            if (stock <= minStock) throw new Exception("THE QUANTITY IN STOCK CAN'T BE EQUALS OR LOWEST OF MINSTOCK");
            this.code = code;
            this.description = description;
            this.onSale = onSale;
            this.price = price;
            this.category = (Category)category;
            this.packaging = (Packaging)type;
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

        public double Stock
        {
            get { return stock; }
        }

        public string GetCategory
        {
            get { return $"{category}"; }
        }

        public double MinStock
        {
            get => minStock;
        }

        public string PackagingType
        {
            get { return $"{packaging}"; }
        }

        public bool OnSale
        {
            get {return onSale;}
        }

        public string Description
        {
            get { return description; }
        }

        public override string ToString()
        {
            string Message = "";
            if (onSale) Message = $"CODE ->{code} DESCRIPTION ->{description} CATEGORY -> {category} STOCK ->{stock} \n MIN_STOCK ->{minStock} PRICE ->{price} {currency} ON SALE ->Y{Price}";
            else Message = Message = $"CODE ->{code} DESCRIPTION ->{description} CATEGORY -> {category} STOCK ->{stock} \n MIN_STOCK ->{minStock} PRICE ->{price} {currency} ON SALE ->N";
            return Message;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (obj is Item)
            {
                Item other = (Item)obj;
                return (this.code == other.code);
            }
            else return false;
        }

        /// <summary>
        /// COMPARA LA DIFERENCIA DEL STOCK DONAT AMB EL STOCK ACTUAL
        /// </summary>
        /// <param name="other"></param>
        /// <returns>DIFERENCIA DEL VALOR DONAT I VALOR ACTUAL</returns>
        public int CompareTo(Item? other)
        {
            if (other == null) throw new ArgumentNullException("NO POT SER NULL !!!");
            double resultat = 0;
            resultat = other.stock - this.stock;
            return (int)resultat;
        }
    }
}
