using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.application.Dtos
{
    public class AccountTransfer
    {
        public int AcountFrom { get; set; }
        public int AccountTo { get; set; }
        public decimal AmountTransfer { get; set; }
    }
}
