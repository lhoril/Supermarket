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
        public Customer(string id, string fullNaime, int? fidelityCard)
        {
            _id = id;
            _fullName = fullNaime;
            fidelityCard = 0;
            active = false;

        }

        public override double GetRating()
        {

        }

        public override void AddPoints(int points)
        {

        }

        public override string ToString()
        {
            return $"DNI/NIE-> {_id} ";
        }
        #endregion
    }
}
