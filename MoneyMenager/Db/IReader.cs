using MoneyMenager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMenager.Db
{
    interface IReader
    {
        IEnumerable<Item> ReadAll();
        int GetNextId();

    }
}
