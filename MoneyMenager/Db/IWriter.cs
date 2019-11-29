using MoneyMenager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMenager.Db
{
    interface IWriter
    {
        void Write(Item item);
        void Remove(int id);
    }
}
