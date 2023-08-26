using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using NUnit.Framework.Internal;
using System.IO;
using Events;
using BookNormalCQRS;

namespace UserNormalCQRSUnitTests
{
    [TestFixture]
    public class UserTest : BDDTest<UserAggregate>
    {
        private Guid _userId;
        private string _userName;
        private string _userEmail;
        private string _updatedUserName;
        private string _updatedUserEmail;

        [SetUp]
        public void Setup()
        {
            _userId = Guid.NewGuid();
            _userName = "Mey";
            _userEmail = "chan@mao.com";
            _updatedUserName = "Mei";
            _updatedUserEmail = "chan@gmail.com";

        }
        [Test]
        public void AddNewUserTest()
        {
            Test(
               Given(),
           When(new AddNewUser
           {
               Id = _userId,
               UserName = _userName,
               UserEmail = _userEmail

           }),
           Then(new AddedUser
           {
               Id = _userId,
               UserName = _userName,
               UserEmail = _userEmail
           }));
        }
        [Test]
        public void UpdateUserTest()
        {
            Test(
               Given(),
           When(new UpdateUser
           {
               Id = _userId,
               UpdatedUserName = _updatedUserName,
               UpdatedUserEmail = _updatedUserEmail
           }),
           Then(new UpdatedUser
           {
               Id = _userId,
               UpdatedUserName = _updatedUserName,
               UpdatedUserEmail = _updatedUserEmail
           }));
        }
        [Test]
        public void DeleteUserTest()
        {
            Test(
               Given(),
           When(new DeleteUser
           {
               Id = _userId,

           }),
           Then(new DeletedUser
           {
               Id = _userId,

           }));
        }
    }
}
