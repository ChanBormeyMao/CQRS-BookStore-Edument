using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class AddedWaitList
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }

    public class RemovedWaitList
    {
        public Guid Id { get; set; }
    }
}
