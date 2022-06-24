using System;
using System.Collections.Generic;
using Xunit;
using Avans_Devops;
using Avans_Devops.Observe;
using Avans_Devops.Composite;
using Avans_Devops.Releases;
using Avans_Devops.Pipeline;

namespace Avans_Devops_Tests.Tests
{
    public class ReleaseTests
    {
        [Fact]
        public void AddActivityToBacklog()
        {
            //Arrange
            Sprint Sprint = new ActiveSprint(1, null, "Sprint 1",  DateTime.Now, DateTime.Now.AddDays(10),"Type 1", 
                new User(1,"Jeremy Smits", Roles.ScrumMaster, "jsmits9@avans.nl"));
            
            //Act

            //Assert
        }
    }
}
