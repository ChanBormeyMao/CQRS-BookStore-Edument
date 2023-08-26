using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BookNormalCQRS
{

    public class BorrowBook
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }



    }
    public class ReturnBook
    {
        public Guid Id { get; set; }
        //public Guid UserId { get; set; }
        //public Guid BookId { get; set; }
    }

}
