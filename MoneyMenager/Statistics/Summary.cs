using MoneyMenager.Db;
using MoneyMenager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMenager.Statistics
{
    class Summary
    {
        //private IReader _file;
        private IReader _reader;

        public Summary(IReader file)
        {
            //_file = file;
            _reader = file;
            
        }
        private decimal SumIncomes (IEnumerable<Item> list)
        {
            decimal sum = 0.0M;
            foreach (Item item in list)
            {
                if (item.Type==ItemType.Income)
                {
                    sum += item.Amount; 
                }

            }
            return sum;
        }
        private decimal SumOutcomes(IEnumerable<Item> list)
        {
            decimal sum = 0.0M;
            foreach (Item item in list)
            {
                if (item.Type == ItemType.Outcome)
                {
                    sum += item.Amount;
                }

            }
            return sum;
        }
        private decimal Balance(decimal incomes, decimal outcomes)
        {
            return incomes - outcomes;
        }
        private IEnumerable<Item> GetItems(int year, int month)
        {
            //IEnumerable<Item> list = _file.ReadAll();
            IEnumerable<Item> list = _reader.ReadAll();
            List<Item> reportList = new List<Item>();
            foreach (Item item in list)
            {
                if (item.Date.Year==year && item.Date.Month==month)
                {
                    reportList.Add(item);
                }
            }
            return reportList;
        }
        public void DisplayRaport(int year, int month)
        {
            IEnumerable<Item> list = GetItems(year, month);

            decimal incomes = SumIncomes(list);
            decimal outcomes = SumOutcomes(list);
            decimal balance = Balance(incomes, outcomes);

            Console.WriteLine($"Podsumowanie {month}/{year}");
            Console.WriteLine($"Suma dochodów:){incomes}");
            Console.WriteLine($"Suma wydatków:){outcomes}");
            Console.WriteLine("============================");
            Console.WriteLine($"Bilans:){balance}");
        }
    }
}
