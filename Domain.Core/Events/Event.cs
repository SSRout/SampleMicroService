using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime TimeStamp { get; set; }
        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
