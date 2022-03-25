using System;
using System.Collections.Generic;
using Xunit;
using Avans_Devops.Observe;
using Avans_Devops.Composite;

namespace Avans_Devops.Tests
{
    public class ObserverTests
    {
		[Fact]
		public void AttachSingleThreadObserver()
		{
			//Arrange
			BacklogItem backlogItem = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new Thread(1, backlogItem, 0, null, "Thread text 1", null);
			Observer observer = new Observer();

			//Act
			thread.AttachObserver(observer);

			//Assert
			Assert.True(thread.Observers.Count == 1);
		}

		[Fact]
		public void AttachMultipleThreadObservers()
		{
			//Arrange
			BacklogItem backlogItem = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new Thread(1, backlogItem, 0, null, "Thread text 1", null);
			Observer observer1 = new Observer();
			Observer observer2 = new Observer();
			Observer observer3 = new Observer();

			//Act
			thread.AttachObserver(observer1);
			thread.AttachObserver(observer2);
			thread.AttachObserver(observer3);

			//Assert
			Assert.True(thread.Observers.Count == 3);
		}

		[Fact]
		public void DetachSingleThreadObserver()
		{
			//Arrange
			BacklogItem backlogItem = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new Thread(1, backlogItem, 0, null, "Thread text 1", null);
			Observer observer = new Observer();

			//Act
			thread.AttachObserver(observer);

			thread.DetachObserver(observer);

			//Assert
			Assert.True(thread.Observers.Count == 0);
		}
		
		[Fact]
		public void DetachMultipleThreadObservers()
		{
			//Arrange
			BacklogItem backlogItem = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new Thread(1, backlogItem, 0, null, "Thread text 1", null);
			Observer observer1 = new Observer();
			Observer observer2 = new Observer();
			Observer observer3 = new Observer();
			Observer observer4 = new Observer();

			//Act
			thread.AttachObserver(observer1);
			thread.AttachObserver(observer2);
			thread.AttachObserver(observer3);
			thread.AttachObserver(observer4);

			thread.DetachObserver(observer1);
			thread.DetachObserver(observer3);

			//Assert
			Assert.True(thread.Observers.Count == 2);
		}

        [Fact]
        public void ThreadSingleObserver()
        {
            //Arrange
			BacklogItem backlogItem = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new Thread(1, backlogItem, 0, null, "Thread text 1", null);
			Comment comment = new Comment(2, thread.BacklogItem, thread.PostID, thread, "Comment text 1", null);
			Observer observer = new Observer();

            //Act
			thread.AttachObserver(observer);
			thread.AddChild(comment);

            //Assert
			Assert.True(observer.NotificationMemory.Count == 1);
        }

		[Fact]
        public void ThreadMultipleObservers()
        {
            //Arrange
			BacklogItem backlogItem = new BacklogItem(1, 1, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new Thread(1, backlogItem, 0, null, "Thread text 1", null);
			Comment comment = new Comment(2, thread.BacklogItem, thread.PostID, thread, "Comment text 1", null);
			Observer observer1 = new Observer();
			Observer observer2 = new Observer();

            //Act
			thread.AttachObserver(observer1);
			thread.AttachObserver(observer2);
			thread.AddChild(comment);

            //Assert
			Assert.True(observer1.NotificationMemory.Count == 1);
			Assert.True(observer2.NotificationMemory.Count == 1);
        }
    }
}
