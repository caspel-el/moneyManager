using MoneyMenager.Db;
using MoneyMenager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMenager
{
    class Service
    {
        private IReader _reader;
        private IWriter _writer;

        public Service(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void AddIncome(decimal amount, string name, DateTime date)
        {
            int id = _reader.GetNextId();
            Income income = new Income(id, amount, name, date);
            _writer.Write(income);
        }
        public void OutOutcome(decimal amount, string name, DateTime date)
        {
            int id = _reader.GetNextId();
            Outcome outcome = new Outcome(id, amount, name, date);
            _writer.Write(outcome);
        }
        public void RemoveById(int id)
        {
            _writer.Remove(id);
        }
    }
}
