using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    [Serializable]
    public class Individual : Customer
    {
        public Individual(string name)
            : base(name)
        {
        }
    }
}
