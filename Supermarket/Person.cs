﻿using System;
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
        protected int _points;
        protected double _totalInvoiced;
        private bool active;

        #region Constructors
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
        #endregion

        #region propietats
        public string FullName
        {
            get { return _fullname; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        #endregion

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

        public abstract double GetRating
        {
            get;
        }

        public abstract void AddPoints(int pointsToAdd);
        

        public int CompareTo(Person? other)
        {
            int resultat = 0;
            resultat = this._points - other._points;
            return resultat;
        }
    }
}
