using System;
using System.Collections.Generic;
using Xunit;

namespace Avans_Devops.Tests
{
    public class CommentTests
    {
        [Fact]
        public void AddChild()
        {
            //Arrange
            BacklogItem backlogItem1 = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
            BacklogItem backlogItem2 = new BacklogItem(1, 1, 2, "Backlog Item Name 2", 1, 1);

            Composite.Thread thread1 = new Composite.Thread(1, backlogItem1, 0, null, "Thread text 1", null);
            Composite.Thread thread2 = new Composite.Thread(2, backlogItem2, 0, null, "Thread text 2", null);

            Composite.Comment comment1 = new Composite.Comment(2, thread1.BacklogItem, thread1.PostID, thread1, "Comment text 1", null);
            Composite.Comment comment2 = new Composite.Comment(3, thread1.BacklogItem, thread1.PostID, thread1, "Comment text 2", null);

            Composite.Comment comment3 = new Composite.Comment(4, thread2.BacklogItem, thread2.PostID, thread2, "Comment text 3", null);
            Composite.Comment comment4 = new Composite.Comment(5, thread2.BacklogItem, thread2.PostID, thread2, "Comment text 4", null);
            Composite.Comment comment5 = new Composite.Comment(6, thread2.BacklogItem, thread2.PostID, thread2, "Comment text 5", null);

            //Act
            thread1.AddChild(comment1);
            thread1.AddChild(comment2);

            thread2.AddChild(comment3);
            thread2.AddChild(comment4);
            thread2.AddChild(comment5);

            //Assert
            Assert.True(thread1.Comments.Count == 2);
            Assert.True(thread2.Comments.Count == 3);
        }

        [Fact]
        public void RemoveChild()
        {
            //Arrange
            BacklogItem backlogItem1 = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
            BacklogItem backlogItem2 = new BacklogItem(1, 1, 2, "Backlog Item Name 2", 1, 1);

            Composite.Thread thread1 = new Composite.Thread(1, backlogItem1, 0, null, "Thread text 1", null);
            Composite.Thread thread2 = new Composite.Thread(2, backlogItem2, 0, null, "Thread text 2", null);

            Composite.Comment comment1 = new Composite.Comment(2, thread1.BacklogItem, thread1.PostID, thread1, "Comment text 1", null);
            Composite.Comment comment2 = new Composite.Comment(3, thread1.BacklogItem, thread1.PostID, thread1, "Comment text 2", null);

            Composite.Comment comment3 = new Composite.Comment(4, thread2.BacklogItem, thread2.PostID, thread2, "Comment text 3", null);
            Composite.Comment comment4 = new Composite.Comment(5, thread2.BacklogItem, thread2.PostID, thread2, "Comment text 4", null);
            Composite.Comment comment5 = new Composite.Comment(6, thread2.BacklogItem, thread2.PostID, thread2, "Comment text 5", null);

            //Act
            thread1.AddChild(comment1);
            thread1.AddChild(comment2);

            thread2.AddChild(comment3);
            thread2.AddChild(comment4);
            thread2.AddChild(comment5);

            thread1.RemoveChild(comment1);
            thread2.RemoveChild(comment4);

            //Assert
            Assert.True(thread1.Comments.Count == 1);
            Assert.True(thread2.Comments.Count == 2);
        }
    }
}
