using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BookNormalCQRS
{

    public class AddNewBook
    {
        public Guid Id;
        public string BookTitle { get; set; }
        public bool IsReserved { get; set; }
    }

    public class UpdateBook
    {
        //public Guid UpdateBookEventId { get; set; }
        public Guid Id { get; set; }
        public string UpdatedBookTitle { get; set; }
    }
    public class DeleteBook
    {
        //public Guid DeleteBookEventId { get; set; }
        public Guid Id { get; set; }

    }
    public class UpdateReserveStatus
    {
        public Guid Id { get; set; }
    }

    //public class SearchBook
    //{
    //    public Guid Id { get; set; }
    //}

}
