using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Reservation
    {
        public Guid Id;
        public User User;
        public Book Book;
    }
    public class Book
    {
        public Guid Id;
        public string BookTitle;
        public bool IsReserved;
    }
    public class User
    {
        public Guid Id;
        public string UserName;
        public string UserEmail;
    }
    public class WaitList
    {
        public Guid Id;
        public Book Book;
        public User User;
    }
}
