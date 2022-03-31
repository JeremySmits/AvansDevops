using Avans_Devops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Avans_Devops_Tests.Tests
{
    public class UserTests
    {
        [Fact]
        public void ChangeUserRole()
        {
            //Arrange
            User user = new User(1, "TestUser", Roles.Developer, "Test@User.com");

            //Act
            user.ChangeRole(Roles.ProductOwner);

            //Assert
            Assert.True(user.Role == Roles.ProductOwner);
        }
    }
}
