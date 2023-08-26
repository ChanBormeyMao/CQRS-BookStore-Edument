
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using Events;

namespace BookNormalCQRS
{
    public class UserAggregate : Aggregate, IHandleCommand<AddNewUser>, IHandleCommand<UpdateUser>, IHandleCommand<DeleteUser>, IApplyEvent<AddedUser>, IApplyEvent<UpdatedUser>, IApplyEvent<DeletedUser>
    {
        private List<User> _allUsers = new List<User>(){
            new User { Id = new Guid("5027b854-00ce-4f1f-9285-48687c17dffc"), UserName="jsmith123",UserEmail="jsmith123@example.com" },
            new User { Id = new Guid("57a5b5c5-5f5e-4f3d-a347-bcf22341f9cc"),  UserName="kwilliams",UserEmail="kwilliams@example.com"},
            new User { Id = new Guid("a5b79415-2d8c-43ce-9a6e-2c44a8c5350c"),  UserName="lcooper",UserEmail="lcooper@example.com"}
        };

        private bool isEmailExisted(string userEmail)
        {
            foreach (User u in _allUsers)
            {
                return u.UserEmail == userEmail;
            }
            return false;
        }
        private bool isUserNameExisted(string userName)
        {
            foreach (User u in _allUsers)
            {
                return u.UserName == userName;
            }
            return false;
        }
        public IEnumerable Handle(AddNewUser c)
        {
            if (isEmailExisted(c.UserEmail))
            {
                throw new UserEmailExisted();
            }
            yield return new AddedUser
            {
                Id = c.Id,
                UserEmail = c.UserEmail,
                UserName = c.UserName,
            };
        }

        public IEnumerable Handle(UpdateUser c)
        {
            if (isEmailExisted(c.UpdatedUserEmail))
            {
                throw new UserEmailExisted();
            }

            yield return new UpdatedUser
            {
                Id = c.Id,
                UpdatedUserEmail = c.UpdatedUserEmail,
                UpdatedUserName = c.UpdatedUserName,
            };
        }
        public IEnumerable Handle(DeleteUser c)
        {
            yield return new DeletedUser
            {
                Id = c.Id,
            };
        }
        public void Apply(AddedUser e)
        {
            User newUser = new User()
            {
                Id = e.Id,
                UserName = e.UserName,
                UserEmail = e.UserEmail
            };
            _allUsers.Add(newUser);
        }
        public void Apply(UpdatedUser e)
        {
            var selectedUser = _allUsers.First(u => u.Id == e.Id);
            selectedUser.UserName = e.UpdatedUserName;
            selectedUser.UserEmail = e.UpdatedUserEmail;
        }
        public void Apply(DeletedUser e)
        {
            var selectedUser = _allUsers.First(u => u.Id == e.Id);
            _allUsers.Remove(selectedUser);
        }
    };

}

