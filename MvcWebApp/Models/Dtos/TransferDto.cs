using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebApp.Models.Dtos
{
    public class TransferDto
    {
        public int AcountFrom { get; set; }
        public int AccountTo { get; set; }
        public decimal AmountTransfer { get; set; }
    }
}
