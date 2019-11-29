using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMenager.Items;

namespace MoneyMenager.Db
{
    class Reader : IReader
    {
        private string _filename;
        public Reader(string filename)
        {
            _filename = filename;
        }
        public int GetNextId()
        {
            IEnumerable<Item> items = ReadAll();
            if (items.Count()==0)
            {
                return 1;
            }
            int lastindex = items.Count() - 1;
            return items.ElementAt(lastindex).Id + 1;
        }

        public IEnumerable<Item> ReadAll()
        {
            IList<Item> items = new List<Item>();

            if (!System.IO.File.Exists(_filename))
            {
                return items;
            }

            IEnumerable<string> lines = System.IO.File.ReadAllLines(_filename);

            foreach (string line in lines)
            {
                Item item = TextToLine(line);
                items.Add(item);
            }

            return items;
        }
        private Item TextToLine(string line)
        {
            string[] columns = line.Split(';');
            int id = int.Parse(columns[0]);
            string name = columns[1];
            string type = columns[2];
            decimal amount = decimal.Parse(columns[3]);
            DateTime date = DateTime.ParseExact(columns[4], "dd-MM-yyyy",null);
            if(type == "I")
            {
                return new Income(id, amount, name, date);
            }
            return new Outcome(id, amount, name, date);
        }
    }
}
