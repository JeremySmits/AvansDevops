using Avans_Devops;
using Avans_Devops.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Avans_Devops_Tests.Tests
{
    public class PostTests
    {
        [Fact]
        public void AddChild()
        {
            //Arrange
            BacklogItem backlogItem1 = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
            BacklogItem backlogItem2 = new BacklogItem(1, 1, 2, "Backlog Item Name 2", 1, 1);

            Thread thread1 = new Thread(1, backlogItem1, null, "Thread text 1", null);
            Thread thread2 = new Thread(2, backlogItem2, null, "Thread text 2", null);

            Comment comment1 = new Comment(thread1.PostID, thread1, "Comment text 1", null);
            Comment comment2 = new Comment(thread1.PostID, thread1, "Comment text 2", null);

            Comment comment3 = new Comment(thread2.PostID, thread2, "Comment text 3", null);
            Comment comment4 = new Comment(thread2.PostID, thread2, "Comment text 4", null);
            Comment comment5 = new Comment(thread2.PostID, thread2, "Comment text 5", null);

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
        public void RemoveChild()
        {
            //Arrange
            BacklogItem backlogItem1 = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
            BacklogItem backlogItem2 = new BacklogItem(1, 1, 2, "Backlog Item Name 2", 1, 1);

            Thread thread1 = new Thread(1, backlogItem1, null, "Thread text 1", null);
            Thread thread2 = new Thread(2, backlogItem2, null, "Thread text 2", null);

            Comment comment1 = new Comment(thread1.PostID, thread1, "Comment text 1", null);
            Comment comment2 = new Comment(thread1.PostID, thread1, "Comment text 2", null);

            Comment comment3 = new Comment(thread2.PostID, thread2, "Comment text 3", null);
            Comment comment4 = new Comment(thread2.PostID, thread2, "Comment text 4", null);
            Comment comment5 = new Comment(thread2.PostID, thread2, "Comment text 5", null);

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
    }
}
