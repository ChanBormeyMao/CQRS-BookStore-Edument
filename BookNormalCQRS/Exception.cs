using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNormalCQRS
{
    public class BookTitleExisted : Exception
    {

    }
    public class BookNotExisted : Exception
    {

    }
    public class UserEmailExisted : Exception
    {

    }
    public class CannotBorrowBook : Exception
    {

    }
}

