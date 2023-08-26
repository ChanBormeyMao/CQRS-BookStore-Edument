using Book3ReadModels;
using Edument.CQRS;
using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book3ReadModels
{
    public class UserReadModel : IUserReadModel, ISubscribeTo<AddedUser>, ISubscribeTo<UpdatedUser>, ISubscribeTo<DeletedUser>
    {
        public class User
        {
            public Guid Id;
            public string UserName;
            public string UserEmail;
        }

        private List<User> _allUsers = new List<User>()
        {
            new User { Id = new Guid("5027b854-00ce-4f1f-9285-48687c17dffc"), UserName="jsmith123",UserEmail="jsmith123@example.com" },
            new User { Id = new Guid("57a5b5c5-5f5e-4f3d-a347-bcf22341f9cc"),  UserName="kwilliams",UserEmail="kwilliams@example.com"},
            new User { Id = new Guid("a5b79415-2d8c-43ce-9a6e-2c44a8c5350c"),  UserName="lcooper",UserEmail="lcooper@example.com"}
        };

        public List<User> GetAllUsers()
        {
            lock (_allUsers)
            {
                return (from u in _allUsers
                        select new User
                        {
                            Id = u.Id,
                            UserName = u.UserName,
                            UserEmail = u.UserEmail
                        }
                       ).ToList();
            }
        }
        public User SearchUser(Guid UserId)
        {
            return _allUsers.First(b => b.Id == UserId);
        }

        public void Handle(AddedUser e)
        {
            var user = new User
            {
                Id = e.Id,
                UserEmail = e.UserEmail,
                UserName = e.UserName
            };
            lock (_allUsers)
            {
                _allUsers.Add(user);
            }
        }
        public void Handle(UpdatedUser e)
        {
            var user = _allUsers.First(b => b.Id == e.Id);
            lock (_allUsers)
            {
                user.UserEmail = e.UpdatedUserEmail;
                user.UserName = e.UpdatedUserName;
            }
        }
        public void Handle(DeletedUser e)
        {
            var user = _allUsers.First(b => b.Id == e.Id);
            lock (_allUsers)
            {
                _allUsers.Remove(user);
            }
        }


    }
}
