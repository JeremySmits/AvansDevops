using System;
using System.Collections.Generic;
using Xunit;
using Avans_Devops.Observe;
using Avans_Devops.Composite;
using Avans_Devops.Releases;
using Avans_Devops.Pipeline;

namespace Avans_Devops.Tests
{
    public class ObserverTests
    {
		[Fact]
		public void AttachSingleThreadObserver()
		{
			//Arrange
			BacklogItem backlogItem = new(1, null, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new(1, backlogItem, null, "Thread text 1", null);
			Observer observer = new();

			//Act
			thread.AttachObserver(observer);

			//Assert
			Assert.True(thread.Observers.Count == 1);
		}

		[Fact]
		public void AttachMultipleThreadObservers()
		{
			//Arrange
			BacklogItem backlogItem = new(1, null, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new(1, backlogItem, null, "Thread text 1", null);
			Observer observer1 = new();
			Observer observer2 = new();
			Observer observer3 = new();

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
			BacklogItem backlogItem = new(1, null, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new(1, backlogItem, null, "Thread text 1", null);
			Observer observer = new();

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
			BacklogItem backlogItem = new(1, null, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new(1, backlogItem, null, "Thread text 1", null);
			Observer observer1 = new();
			Observer observer2 = new();
			Observer observer3 = new();
			Observer observer4 = new();

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
        public void ThreadNotificationSingleObserver()
        {
            //Arrange
			BacklogItem backlogItem = new(1, null, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new(1, backlogItem, null, "Thread text 1", null);
			Comment comment = new(thread.PostID, thread, "Comment text 1", null);
			Observer observer = new();

            //Act
			thread.AttachObserver(observer);
			thread.AddChild(comment);

            //Assert
			Assert.True(observer.NotificationMemory.Count == 1);
        }

		[Fact]
        public void ThreadNotificationMultipleObservers()
        {
            //Arrange
			BacklogItem backlogItem = new(1, null, 1, "Backlog Item Name 1", 1, 1);
			Thread thread = new(1, backlogItem, null, "Thread text 1", null);
			Comment comment = new(thread.PostID, thread, "Comment text 1", null);
			Observer observer1 = new();
			Observer observer2 = new();

            //Act
			thread.AttachObserver(observer1);
			thread.AttachObserver(observer2);
			thread.AddChild(comment);

            //Assert
			Assert.True(observer1.NotificationMemory.Count == 1);
			Assert.True(observer2.NotificationMemory.Count == 1);
        }

		[Fact]
		public void AttachFailReleaseObserver()
		{
			//Arrange
			FailRelease failRelease = new(null);
			string message = "The release has been cancelled!";

			User scrumMaster = new(1, "Scrum Master Placeholder", Roles.ScrumMaster, "scrum@master.com");
            Observer scrumMasterObserver = new();
            scrumMasterObserver.Receiver = scrumMaster;
            scrumMasterObserver.Message = message;

			//Act
			failRelease.AttachObserver(scrumMasterObserver);

			//Assert
			Assert.True(failRelease.Observers.Count == 1);
		}

		[Fact]
		public void DetachFailReleaseObserver()
		{
			//Arrange
			FailRelease failRelease = new(null);
			string message = "The release has been cancelled!";

			User scrumMaster = new(1, "Scrum Master Placeholder", Roles.ScrumMaster, "scrum@master.com");
            Observer scrumMasterObserver = new();
            scrumMasterObserver.Receiver = scrumMaster;
            scrumMasterObserver.Message = message;

			//Act
			failRelease.AttachObserver(scrumMasterObserver);
			failRelease.DetachObserver(scrumMasterObserver);

			//Assert
			Assert.True(failRelease.Observers.Count == 0);
		}

		[Fact]
		public void AttachMultipleFailReleaseObservers()
		{
			//Arrange
			FailRelease failRelease = new(null);
			string message = "The release has been cancelled!";

			User scrumMaster = new(1, "Scrum Master Placeholder", Roles.ScrumMaster, "scrum@master.com");
            Observer scrumMasterObserver = new();
            scrumMasterObserver.Receiver = scrumMaster;
            scrumMasterObserver.Message = message;

            User productOwner = new(2, "Product Owner Placeholder", Roles.ProductOwner, "product@owner.com");
            Observer productOwnerObserver = new();
            productOwnerObserver.Receiver = productOwner;
            productOwnerObserver.Message = message;

			//Act
			failRelease.AttachObserver(scrumMasterObserver);
			failRelease.AttachObserver(productOwnerObserver);

			//Assert
			Assert.True(failRelease.Observers.Count == 2);
		}
		
		[Fact]
		public void DetachMultipleFailReleaseObservers()
		{
			//Arrange
			FailRelease failRelease = new(null);
			string message = "The release has been cancelled!";

			User scrumMaster = new(1, "Scrum Master Placeholder", Roles.ScrumMaster, "scrum@master.com");
            Observer scrumMasterObserver = new();
            scrumMasterObserver.Receiver = scrumMaster;
            scrumMasterObserver.Message = message;

            User productOwner = new(2, "Product Owner Placeholder", Roles.ProductOwner, "product@owner.com");
            Observer productOwnerObserver = new();
            productOwnerObserver.Receiver = productOwner;
            productOwnerObserver.Message = message;

			//Act
			failRelease.AttachObserver(scrumMasterObserver);
			failRelease.AttachObserver(productOwnerObserver);

			failRelease.DetachObserver(scrumMasterObserver);
			failRelease.DetachObserver(productOwnerObserver);

			//Assert
			Assert.True(failRelease.Observers.Count == 0);
		}

		[Fact]
		public void FailReleaseNotificationObserver()
		{
			//Arrange
			FailRelease failRelease = new(null);
			// Observer observer = new Observer();
			
			//Act
			// failRelease.AttachObserver(observer);
			failRelease.Proceed();

			//Assert
			foreach (var o in failRelease.Observers) {
                Assert.True(o.NotificationMemory.Count == 1);
            }
		}

		[Fact]
		public void AttachPipelineObserver()
		{
			//Arrange
			var pipeline = PipelineFactory.CreatePipeline(PipelineType.Deployment, "deploymentPipeline");
			Observer observer = new();

			//Act
			pipeline.AttachObserver(observer);

			//Assert
			Assert.True(pipeline.Observers.Count == 1);
		}

		[Fact]
		public void AttachMultiplePipelineObservers()
		{
			//Arrange
			var pipeline = PipelineFactory.CreatePipeline(PipelineType.Deployment, "deploymentPipeline");
			Observer observer1 = new();
			Observer observer2 = new();

			//Act
			pipeline.AttachObserver(observer1);
			pipeline.AttachObserver(observer2);

			//Assert
			Assert.True(pipeline.Observers.Count == 2);
		}

		[Fact]
		public void DetachPipelineObserver()
		{
			//Arrange
			var pipeline = PipelineFactory.CreatePipeline(PipelineType.Deployment, "deploymentPipeline");
			Observer observer = new();

			//Act
			pipeline.AttachObserver(observer);
			pipeline.DetachObserver(observer);

			//Assert
			Assert.True(pipeline.Observers.Count == 0);
		}

		[Fact]
		public void DetachMultiplePipelineObservers()
		{
			//Arrange
			var pipeline = PipelineFactory.CreatePipeline(PipelineType.Deployment, "deploymentPipeline");
			Observer observer1 = new();
			Observer observer2 = new();
			Observer observer3 = new();

			//Act
			pipeline.AttachObserver(observer1);
			pipeline.AttachObserver(observer2);
			pipeline.AttachObserver(observer3);

			pipeline.DetachObserver(observer1);
			pipeline.DetachObserver(observer2);

			//Assert
			Assert.True(pipeline.Observers.Count == 1);
		}
    }
}
