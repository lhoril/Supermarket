using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Customer: Person
    {
        private int? _fidelity_card;


        #region Constructors
        public Customer(string id, string fullName, int? fidelityCard) : base(id, fullName)
        {
            _fidelity_card = fidelityCard;
        }
        #endregion
        public override double GetRating
        {
            get
            {
                return 0.02 * _totalInvoiced;
            }
        }
        public override void AddPoints(int pointsToAdd)
        {
            if (_fidelity_card != null)
            {
                _points += pointsToAdd;
            }
            else
            {
                Console.WriteLine("No tens fidelity card, no s'afegeixen punts!");
            }
        }

        public override string ToString()
        {
            return $"DNI/NIE -> {base._id} NOM -> {base.FullName} RATING -> {GetRating}  VENDES -> {_totalInvoiced} PUNTS -> {_points} DISPONIBLE -> {base.ToString}";
        }
        
    }
}
