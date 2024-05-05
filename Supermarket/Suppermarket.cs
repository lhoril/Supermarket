using System;
using System.Collections.Generic;
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
            this.activeLines = activeLines;
            this.staff = LoadCashiers(fileCashiers);
            this.customer = LoadCustomers(fileCustomers);
            this.warehouse = LoadWarehouse(fileItems);
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
                line = sr.ReadLine();
                Person person = new Cashier(camps[0], camps[1], Convert.ToInt32(camps[3]));
                persones.Add(camps[0],person);
            }
            return persones;
        }

        private Dictionary<string, Person> LoadCustomers(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            Dictionary<string, Person> persones = new Dictionary<string, Person>();
            string line;
            line = sr.ReadLine();
            string[] camps;
            while (line != null)
            {
                camps = line.Split(';');
                line = sr.ReadLine();
                Person person = new Customer(camps[0], camps[1], Convert.ToInt32(camps[3]));
                persones.Add(camps[0], person);
            }
            return persones;
        }

        private SortedDictionary<int, Item> LoadWarehouse(string fileName)
        {
            StreamReader sr = new StreamReader (fileName);
            SortedDictionary<int, Item> items = new SortedDictionary<int, Item>();
            string line;
            line = sr.ReadLine();
            string[] camps;
            int num=0;
            while (line != null)
            {
                camps = line.Split(";");
                line = sr.ReadLine();
                Item item = new Item(num, camps[0], false, 0, Convert.ToInt32(camps[1]), Convert.ToChar(camps[2]), Convert.ToDouble(camps[3]), Convert.ToInt32(camps[4]));
                num++;
                items.Add(num, item);
            }
            return items;
        }

    }
}
