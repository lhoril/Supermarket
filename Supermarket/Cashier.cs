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

        public Cashier(string id, string fullName, long date) : base(id, fullName)
        {
            _joiningDate = new DateTime(date);
        }

        public int YearsOfService
        {
            get { return _joiningDate.Year; }
        }

        public override double GetRating
        {
            get {
                DateTime dateNow = DateTime.Now;
                TimeSpan Interval = _joiningDate - dateNow;
                return Interval.Days + (_totalInvoiced * 0.10); }
        }

        public override void AddPoints(int pointsToAdd)
        {
            base._points += pointsToAdd * (YearsOfService + 1);
        }

        public override string ToString()
        {
            return $"DNI/NIE -> {base._id} NOM -> {base.FullName} RATING -> {GetRating}   ANTIGUITAT -> {YearsOfService} VENDES -> {_totalInvoiced} " +
                $"PUNTS -> {_points} DISPONIBLE -> {base.ToString}";
        }
    }
}
