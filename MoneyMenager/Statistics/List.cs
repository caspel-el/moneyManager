using MoneyMenager.Db;
using MoneyMenager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMenager.Statistics
{
    class List
    {
        private IReader _reader;
        public List(IReader reader)
        {
            _reader = reader;

        }
        public void DisplayLine(Item item)
        {
            string type = "";
            switch (item.Type)
            {
                case ItemType.Income:
                    type = "DOCHÓD";
                    break;
                case ItemType.Outcome:
                    type = "WYDATEK";
                    break;

             
            }
            Console.WriteLine($"{item.Id} {item.Name} {item.Amount}zł {item.Date}");
        }
        public void DispalList()
        {
            IEnumerable<Item> list = _reader.ReadAll();
            foreach (Item item in list)
            {
                DisplayLine(item);
            }
        }
    }
}
