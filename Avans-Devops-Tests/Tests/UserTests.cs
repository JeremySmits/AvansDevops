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
        public void ChangeRole()
        {
            //Arrange
            User user = new(1, "Jeremy", Roles.Developer, "jsmits9@avans.nl");

            //Act
            user.ChangeRole(Roles.ScrumMaster);

            //Assert
            Assert.True(user.Role == Roles.ScrumMaster);
        }
    }
}
