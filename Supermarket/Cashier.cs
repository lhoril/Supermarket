using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Cashier : Person
    {
        private DateTime _joiningDate;

        public Cashier(string id, string fullName, string date) : base(id, fullName)
        {
            _joiningDate = DateTime.Parse(date);
        }

        public int YearsOfService
        {
            get
            {
                TimeSpan Interval = DateTime.Now - _joiningDate;
                return Interval.Days / 365;
            }
        }

        public override double GetRating
        {
            get {
                DateTime dateNow = DateTime.Now;
                TimeSpan Interval = dateNow - _joiningDate;
                return Interval.Days + (_totalInvoiced * 0.10); }
        }

        public override void AddPoints(int pointsToAdd)
        {
            base._points += pointsToAdd * (YearsOfService + 1);
        }

        public override string ToString()
        {
            return $"DNI/NIE -> {base._id,10} NOM -> {base.FullName,-10} RATING -> {GetRating}   ANTIGUITAT -> {YearsOfService} VENDES -> {_totalInvoiced} " +
                $"PUNTS -> {_points} {base.ToString()}";
        }
    }
}
