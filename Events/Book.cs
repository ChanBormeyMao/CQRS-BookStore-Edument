using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class AddedBook
    {
        public Guid Id { get; set; }
        public string BookTitle { get; set; }
        public bool IsReserved = false;
    }
    public class UpdatedBook
    {
        public Guid Id { get; set; }
        public string UpdatedBookTitle { get; set; }
    }
    public class DeletedBook
    {
        //public Guid DeleteBookEventId { get; set; }
        public Guid Id { get; set; }

    }
    public class UpdatedReserveStatus
    {
        public Guid Id { get; set; }
    }
    //public class SearchedBook
    //{
    //    public Guid Id { get; set; }
    //}

}
