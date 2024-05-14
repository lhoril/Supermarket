using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Suppermarket
    {
        private string name;
        private string address;
        public const int MAXLINES = 5;
        private int activeLines;
        private CheckOutLine[] lines = new CheckOutLine[MAXLINES];
        private Dictionary<string, Person> staff;
        private Dictionary<string, Person> customer;
        private SortedDictionary<int, Item> warehouse;

        public Suppermarket(string name, string address, string fileCashiers, string fileCustomers, string fileItems, int activeLines)
        {
            this.name = name;
            this.address = address;
            this.staff = LoadCashiers(fileCashiers);
            this.customer = LoadCustomers(fileCustomers);
            this.warehouse = LoadWarehouse(fileItems);

            for (int i = 0; i < activeLines; i++)
            {
                lines[i] = new CheckOutLine(GetAvailableCashier(), i);
                if(activeLines <= MAXLINES) this.activeLines = activeLines;
            }

        }


        private Dictionary<string, Person> LoadCashiers(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            Dictionary<string, Person> persones = new Dictionary<string, Person>();
            string line;
            line = sr.ReadLine();
            string[] camps;
            while (line != null)
            {
                camps = line.Split(';');
                Person person = new Cashier(camps[0], camps[1], camps[3]);
                persones.Add(camps[0],person);
                line = sr.ReadLine();
            }
            return persones;
        }

        private Dictionary<string, Person> LoadCustomers(string fileName) 
        {
            StreamReader sr = new StreamReader(fileName);
            Dictionary<string, Person> persones = new Dictionary<string, Person>();
            string line;
            line = sr.ReadLine();
            line = sr.ReadLine();
            string[] camps;
            while (line != null)
            {
                camps = line.Split(';');
                line = sr.ReadLine();
                if (camps[2] == "") camps[2] = null;
                Person person = new Customer(camps[0], camps[1], Convert.ToInt32(camps[2]));
                persones.Add(camps[0], person);
            }
            return persones;
        }

        private SortedDictionary<int, Item> LoadWarehouse(string fileName) 
        {
            StreamReader sr = new StreamReader (fileName);
            Random random = new Random();
            SortedDictionary<int, Item> items = new SortedDictionary<int, Item>();
            string line;
            line = sr.ReadLine();
            string[] camps;
            int num=0;
            while (line != null)
            {
                camps = line.Split(";");
                line = sr.ReadLine();
                Item item = new Item(num, camps[0], false, Convert.ToDouble(camps[3]), Convert.ToInt32(camps[1]), Convert.ToChar(camps[2]), random.Next(11, 300) , 10);
                num++;
                items.Add(num, item);
            }
            return items;
        }

        #region Segona Part

        public Dictionary<string, Person> Staff
        {
            get { return this.staff; }
        }

        public Dictionary<string, Person> Customer
        {
            get { return this.customer; }
        }

        public SortedDictionary<int, Item> Warehouse
        {
            get { return this.warehouse; }
        }

        public int ActiveLines
        {
            get { return this.activeLines; }
        }

        public CheckOutLine[] Linies
        {
            get { return lines; }
            set { lines = value; }
        } 

        public HashSet<Item> GetItemsByStock()
        {
            HashSet<Item> items = new HashSet<Item>();
            foreach (KeyValuePair <int, Item> key in warehouse)
            {
                items.Add(key.Value);
            }
            return items;
        }

        public Person GetAvailableCustomer()
        {
            Random random = new Random();
            int numRand = random.Next(0, customer.Count);
            Person[] person = customer.Values.ToArray();
            person[numRand].Active = true;
            return person[numRand];
        }

        public Person GetAvailableCashier()
        {
            Random random = new Random();
            int numRand = random.Next(0, Staff.Count);
            Person[] person = staff.Values.ToArray();
            person[numRand].Active = true;
            return person[numRand];
        }

        public void OpenCheckOutLine(int line20pen)
        {
            if (activeLines == MAXLINES) throw new Exception("El numero de ActiveLines esta al Maxim");
            lines[line20pen-1] = new CheckOutLine(GetAvailableCashier(), line20pen-1);
            activeLines = line20pen;
        }

        public CheckOutLine GetCheckOutLine(int lineNumber)
        {
            CheckOutLine cua;
            if (lineNumber > MAXLINES) cua = null;
            else if (lines[lineNumber-1] == null) cua = null;
            else cua = lines[lineNumber-1];
            return cua;
        }

        public bool JoinTheQueue(ShoppingCart theCart, int line)
        {
            bool isValid;
            if (activeLines >= line && lines[line] != null)
            {
                lines[line].CheckIn(theCart);
                isValid = true;
            }
            else isValid = false;
            return isValid;
        }

        public bool Checkout(int line)
        {
            bool isValid;
            if(activeLines >= line)
            {
                lines[line-1].CheckOut();
                isValid = true;
            }
            else isValid = false;
            return isValid;
        }

        public static bool RemoveQueue(Suppermarket super, int lineToRemove)
        {
            bool isRemove;
            if (super.lines[lineToRemove-1].Empty)
            {
                super.lines[lineToRemove-1].Casher.Active = false;
                super.lines[lineToRemove-1] = default;
                super.activeLines --;
                isRemove = true;
            }
            else isRemove = false;
            return isRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(name);
            sb.AppendLine(address);
            for (int i = 0; i < lines.Length; i++)
            {
                sb.AppendLine(lines[i].ToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}
