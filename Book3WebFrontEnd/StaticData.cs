using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Book3WebFrontEnd
{
    public static class StaticData
    {
        public enum ActionForReservation
        {
            Borrow,
            Return,

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

        public class Reservation
        {
            public Guid BookId;
            public Guid Id;
            public Guid UserId;

        }

        public static List<Book> Books = new List<Book>
        {
            new Book{ Id = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a6"), BookTitle = "fsfsfsfgsgsgsgfsf", IsReserved= false},
            new Book{ Id = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a7"), BookTitle="fsgfdhgdhgdjg", IsReserved= false},
            new Book{ Id = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a8"), BookTitle="jughkhgjkhuhgf", IsReserved= false}
        };

        public static List<User> Users = new List<User>
        {
            new User { Id = new Guid("5027b854-00ce-4f1f-9285-48687c17dffc"), UserName="jsmith123",UserEmail="jsmith123@example.com" },
            new User { Id = new Guid("57a5b5c5-5f5e-4f3d-a347-bcf22341f9cc"),  UserName="kwilliams",UserEmail="kwilliams@example.com"},
            new User { Id = new Guid("a5b79415-2d8c-43ce-9a6e-2c44a8c5350c"),  UserName="lcooper",UserEmail="lcooper@example.com"}
        };
        public static List<Reservation> Reservations = new List<Reservation>
        {
            new Reservation { BookId = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a6"), UserId = new Guid("5027b854-00ce-4f1f-9285-48687c17dffc"), Id = new Guid("1b6a83c6-2b6c-45f3-ba6e-7c2d66b76f8b") },
            new Reservation { BookId = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a7"), UserId = new Guid("57a5b5c5-5f5e-4f3d-a347-bcf22341f9cc"), Id = new Guid("9e7cc07d-3d01-4e1f-a922-f7c4e21d4d8e") },
            new Reservation { BookId = new Guid("d9ebddd4-40f4-4c92-8715-6bdc3996c5a7"), UserId = new Guid("57a5b5c5-5f5e-4f3d-a347-bcf22341f9cc"), Id = new Guid("9e7cc07d-3d01-4e1f-a922-f7c4e21d4d8e") }
        };
    }
}