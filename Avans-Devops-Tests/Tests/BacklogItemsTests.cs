using Avans_Devops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Avans_Devops_Tests.Tests
{
    public class BacklogItemsTests
    {
        [Fact]
        public void BacklogItemStartInToDo()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Assert
            Assert.True(BacklogItem.State == PhaseState.ToDo);
        }

        [Fact]
        public void BacklogItemFromTodoToDoing()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.Doing);
        }
        [Fact]
        public void BacklogItemFromDoingToReadyForTesting()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ReadyForTesting");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.ReadyForTesting);
        }


        [Fact]
        public void BacklogItemFromReadyForTestingToTesting()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ReadyForTesting");
            BacklogItem.SwitchState("Testing");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.Testing);
        }

        [Fact]
        public void BacklogItemFromTestingToDone()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ReadyForTesting");
            BacklogItem.SwitchState("Testing");
            BacklogItem.SwitchState("Done");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.Done);
        }

        [Fact]
        public void BacklogItemFromTestingToToDo()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ReadyForTesting");
            BacklogItem.SwitchState("Testing");
            BacklogItem.SwitchState("ToDo");

            //Assert
            Assert.True(BacklogItem.State == PhaseState.ToDo);
        }

        [Fact]
        public void BacklogItemFromTodoToDone()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Done");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.Done);
        }
        [Fact]
        public void BacklogItemFromTodoToTesting()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Testing");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.Testing);
        }
        [Fact]
        public void BacklogItemFromTodoToReadyForTesting()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("ReadyForTesting");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.ReadyForTesting);
        }
        [Fact]
        public void BacklogItemFromDoingToToDo()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("ToDo");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.ToDo);
        }
        [Fact]
        public void BacklogItemFromDoingToDone()
        {
            //Arrange
            BacklogItem BacklogItem = new(1, 1, 1, "Hond Uitlaten", 1, 2);

            //Act
            BacklogItem.SwitchState("Doing");
            BacklogItem.SwitchState("Done");

            //Assert
            Assert.True(BacklogItem.State != PhaseState.Done);
        }

    }
}
