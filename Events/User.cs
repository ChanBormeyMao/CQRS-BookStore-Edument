using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class AddedUser
    {
        //public Guid AddNewUserEventId { get; set; }
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }

    public class UpdatedUser
    {
        //public Guid UpdateUserEventId { get; set; }
        public Guid Id { get; set; }

        public string UpdatedUserName { get; set; }
        public string UpdatedUserEmail { get; set; }

    }
    public class DeletedUser
    {
        //public Guid DeleteUserEventId { get; set; }
        public Guid Id { get; set; }

    }
}
