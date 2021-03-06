using System;
using System.Collections.Generic;
using Xunit;
using Avans_Devops.Composite;

namespace Avans_Devops.Tests
{
    public class PostTests
    {
        [Fact]
        public void AddChildToThread()
        {
            //Arrange
            BacklogItem backlogItem1 = new(1, null, 1, "Backlog Item Name 1", 1, 1);
            BacklogItem backlogItem2 = new(1, null, 2, "Backlog Item Name 2", 1, 1);

            Thread thread1 = new(1, backlogItem1, null, "Thread text 1", null);
            Thread thread2 = new(2, backlogItem2, null, "Thread text 2", null);

            Comment comment1 = new(thread1.PostID, thread1, "Comment text 1", null);
            Comment comment2 = new(thread1.PostID, thread1, "Comment text 2", null);

            Comment comment3 = new(thread2.PostID, thread2, "Comment text 3", null);
            Comment comment4 = new(thread2.PostID, thread2, "Comment text 4", null);
            Comment comment5 = new(thread2.PostID, thread2, "Comment text 5", null);

            //Act
            thread1.AddChild(comment1);
            thread1.AddChild(comment2);

            thread2.AddChild(comment3);
            thread2.AddChild(comment4);
            thread2.AddChild(comment5);

            //Assert
            Assert.True(thread1.Posts.Count == 2);
            Assert.True(thread2.Posts.Count == 3);
        }

        [Fact]
        public void RemoveChildFromThread()
        {
            //Arrange
            BacklogItem backlogItem1 = new(1, null, 1, "Backlog Item Name 1", 1, 1);
            BacklogItem backlogItem2 = new(1, null, 2, "Backlog Item Name 2", 1, 1);

            Thread thread1 = new(1, backlogItem1, null, "Thread text 1", null);
            Thread thread2 = new(2, backlogItem2, null, "Thread text 2", null);

            Comment comment1 = new(thread1.PostID, thread1, "Comment text 1", null);
            Comment comment2 = new(thread1.PostID, thread1, "Comment text 2", null);

            Comment comment3 = new(thread2.PostID, thread2, "Comment text 3", null);
            Comment comment4 = new(thread2.PostID, thread2, "Comment text 4", null);
            Comment comment5 = new(thread2.PostID, thread2, "Comment text 5", null);

            //Act
            thread1.AddChild(comment1);
            thread1.AddChild(comment2);

            thread2.AddChild(comment3);
            thread2.AddChild(comment4);
            thread2.AddChild(comment5);

            thread1.RemoveChild(comment1);
            thread2.RemoveChild(comment4);

            //Assert
            Assert.True(thread1.Posts.Count == 1);
            Assert.True(thread2.Posts.Count == 2);
        }

        [Fact]
        public void ChangeCommentIntoThread()
        {
            //Arrange
            BacklogItem backlogItem1 = new(1, null, 1, "Backlog Item Name 1", 1, 1);
            Thread thread1 = new(1, backlogItem1, null, "Thread text 1", null);
            Comment comment1 = new(thread1.PostID, thread1, "Comment text 1", null);
            thread1.AddChild(comment1);

            //Act
            Comment comment2 = new(thread1.PostID, thread1, "Comment text 1", null);
            thread1.Posts[0].AddChild(comment2);

            var temp = thread1.Posts[0].GetType();
            
            //Assert
            Assert.True(temp == typeof(Thread));
        }

        [Fact]
        public void ThreadCanSaveCommentsAndThreads()
        {
            //Arrange
            BacklogItem backlogItem1 = new(1, null, 1, "Backlog Item Name 1", 1, 1);
            Thread thread1 = new(1, backlogItem1, null, "Thread text 1", null);
            Comment comment1 = new(thread1.PostID, thread1, "Comment text 1", null);
            Thread thread2 = new(1, backlogItem1, null, "Thread text 1", null);

            //Act
            thread1.AddChild(comment1);
            thread1.AddChild(thread2);


            //Assert
            Assert.True(thread1.Posts[0].GetType() == typeof(Comment));
            Assert.True(thread1.Posts[1].GetType() == typeof(Thread));
        }

        [Fact]
        public void OpenThread()
        {
            //Arrange
            BacklogItem backlogItem1 = new(1, null, 1, "Backlog Item Name 1", 1, 1);
            Thread thread1 = new(1, backlogItem1, null, "Thread text 1", null);

            //Act
            thread1.OpenThread();

            //Assert
            Assert.False(thread1.IsClosed);
        }

        [Fact]
        public void CloseThread()
        {
            //Arrange
            BacklogItem backlogItem1 = new(1, null, 1, "Backlog Item Name 1", 1, 1);
            Thread thread1 = new(1, backlogItem1, null, "Thread text 1", null);

            //Act
            thread1.CloseThread();

            //Assert
            Assert.True(thread1.IsClosed);
        }

        [Fact]
        public void CantAddCommentToClosedThread()
        {
            //Arrange
            BacklogItem backlogItem1 = new(1, null, 1, "Backlog Item Name 1", 1, 1);
            Thread thread1 = new(1, backlogItem1, null, "Thread text 1", null);
            Comment comment1 = new(thread1.PostID, thread1, "Comment text 1", null);

            //Act
            thread1.CloseThread();
            thread1.AddChild(comment1);

            //Assert
            Assert.True(thread1.Posts.Count == 0);
        }

        [Fact]
        public void CantAddCommentToDoneThread()
        {
            //Arrange
            BacklogItem backlogItem1 = new(1, null, 1, "Backlog Item Name 1", 1, 1);
            User user = new User(1, "John", Roles.ScrumMaster, "John@avans.nl");
            backlogItem1.Sprint = new ActiveSprint(1, null, "Sprint 1", DateTime.Today, DateTime.Now.AddDays(10), "", user);
            Thread thread1 = new(1, backlogItem1, null, "Thread text 1", null);
            Comment comment1 = new(thread1.PostID, thread1, "Comment text 1", null);

            //Act
            backlogItem1.SwitchState("Doing");
            backlogItem1.SwitchState("ReadyForTesting");
            backlogItem1.SwitchState("Testing");
            backlogItem1.SwitchState("Tested");
            backlogItem1.SwitchState("Done");

            thread1.AddChild(comment1);

            //Assert
            Assert.True(thread1.Posts.Count == 0);
        }
    }
}
