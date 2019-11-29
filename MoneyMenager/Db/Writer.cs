using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyMenager.Items;

namespace MoneyMenager.Db
{
    class Writer : IWriter
    {
        private string _filename;
        public Writer(string filename)
        {
            _filename = filename;
        }
        public void Remove(int id)
        {
            IEnumerable<string> lines = System.IO.File.ReadAllLines(_filename);
            IList<string> toSave = new List<string>();
            foreach (string line in lines)
            {
                if (!HasId(id,line))
                {
                    toSave.Add(line);
                }
            }
        }

        private bool HasId(int id, string line)
        {
            string[] columns = line.Split(';');
            int lineId = int.Parse(columns[0]);

            return id == lineId;
        }
        public void Write(Item item)
        {
            string line = ItemToText(item);
            System.IO.File.AppendAllText(_filename, line);
        }
        public string ItemToText(Item item)
        {
            string type = "I";
            if (item.Type == ItemType.Outcome)
            {
                type = "O";
            }
            string line = string.Format($"{item.Id};{item.Name};{item.Type};{item.Amount};{item.Date.ToString("dd-MM-yyy")} ");
            return line + Environment.NewLine;
        }
    }
}
