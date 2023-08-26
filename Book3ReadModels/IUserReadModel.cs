
using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book3ReadModels;

namespace Book3ReadModels
{
    public interface IUserReadModel
    {
        List<UserReadModel.User> GetAllUsers();
        UserReadModel.User SearchUser(Guid UserId);
    }
}
