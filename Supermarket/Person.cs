using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public abstract class Person : IComparable<Person>
    {
        protected string _id;
        private string _fullname;
        private int _points;
        protected double _totalInvoiced;
        private bool active;

        protected Person(string id, string fullName, int points)
        {
            _id = id;
            _fullname = fullName;
            _points = points;
            _totalInvoiced = 0;
            active = false;

        }

        protected Person(string id, string fullName)
        {
            _id = id;
            _fullname = fullName;
            _points = 0;
        }

        public string FullName
        {
            get { return _fullname; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public void AddInvoiceAmount(double amount)
        {
            _totalInvoiced += amount;
        }

        public override string ToString()
        {
            string disponible;
            if (active == true) disponible = "N";
            else disponible = "S";
            return $"DISPONIBLE -> {disponible}";
        }

        public abstract int GetRating
        {
            get;
        }

        public abstract int AddPoints(int pointsToAdd);
        

        public int CompareTo(Person? other)
        {
            throw new NotImplementedException();
        }
    }
}
