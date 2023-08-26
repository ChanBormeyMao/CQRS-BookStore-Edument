using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNormalCQRS
{
    public class AddToWaitList
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
    public class RemoveFromWaitList
    {
        public Guid Id { get; set; }
    }
}
