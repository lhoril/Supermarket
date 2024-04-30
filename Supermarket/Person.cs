
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class Person : IComparable<Person>
    {
        private int _id;
        private string _fullName;

        public int CompareTo(Person? other)
        {
            throw new NotImplementedException();
        }
    }
}
