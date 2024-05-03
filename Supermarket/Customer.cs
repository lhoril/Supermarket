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

        public override double GetRating => throw new NotImplementedException();

        public override void AddPoints(int points)
        {

        }

        public override string ToString()
        {
            return $"DNI/NIE-> {base._id} ";
        }
        #endregion
    }
}
