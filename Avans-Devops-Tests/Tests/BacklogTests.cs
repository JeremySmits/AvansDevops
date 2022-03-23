﻿using System;
using System.Collections.Generic;
using Xunit;

namespace Avans_Devops.Tests
{
    public class BacklogTests
    {
        [Fact]
        public void AddSprintToBacklog()
        {
            //Arrange
            Backlog backlog = new Backlog(1, "Avans Devops", "SO&A uitwerking");

            //Act
            backlog.AddSprint(new Sprint(1,1,"Sprint 1", DateTime.Today, DateTime.Today.AddDays(1),"Type 1" ,new ActivateSprintState()));
            backlog.AddSprint(new Sprint(2, 1, "Sprint 2", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new ActivateSprintState()));

            //Assert
            Assert.True(backlog.Sprints.Count == 2);
        }

        [Fact]
        public void RemoveSprintFromBacklog()
        {
            //Arrange
            Backlog backlog = new Backlog(1, "Avans Devops", "SO&A uitwerking");

            //Act
            backlog.AddSprint(new Sprint(1, 1, "Sprint 1", DateTime.Today, DateTime.Today.AddDays(1), "Type 1", new ActivateSprintState()));
            backlog.AddSprint(new Sprint(2, 1, "Sprint 2", DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), "Type 1", new ActivateSprintState()));

            backlog.RemoveSprint(2);

            //Assert
            Assert.True(backlog.Sprints.Count == 1);
        }

        [Fact]
        public void AddUserToBacklog()
        {
            //Arrange
            Backlog backlog = new Backlog(1, "Avans Devops", "SO&A uitwerking");

            //Act
            backlog.AddUser(new User(1, "Jeremy Smits", new Role(), "Jsmits9Avans.nl"));
            backlog.AddUser(new User(2, "Sanne Huisman", new Role(), "SHuisman2@Avans.nl"));

            //Assert
            Assert.True(backlog.ScrumTeam.Count == 2);
        }

        [Fact]
        public void RemoveUsersFromBacklog()
        {
            //Arrange
            Backlog backlog = new Backlog(1, "Avans Devops", "SO&A uitwerking");

            //Act
            backlog.AddUser(new User(1, "Jeremy Smits", new Role(), "Jsmits9Avans.nl"));
            backlog.AddUser(new User(2, "Sanne Huisman", new Role(), "SHuisman2@Avans.nl"));

            backlog.RemoveUser(2);

            //Assert
            Assert.True(backlog.ScrumTeam.Count == 1);
        }
        [Fact]
        public void AddBacklogItemToBacklog()
        {
            //Arrange
            Backlog backlog = new Backlog(1, "Avans Devops", "SO&A uitwerking");

            //Act
            backlog.AddBacklogItem(new BacklogItem(1, 1, 1, "Hond uitlaten", new Phase(), 0, 2));
            backlog.AddBacklogItem(new BacklogItem(1, 1, 2, "Kat uitlaten", new Phase(), 0, 2));
            backlog.AddBacklogItem(new BacklogItem(1, 1, 3, "Goudvis uitlaten", new Phase(), 0, 10));

            //Assert
            Assert.True(backlog.BackLogItems.Count == 3);
        }

        [Fact]
        public void RemoveBacklogItemFromBacklog()
        {
            //Arrange
            Backlog backlog = new Backlog(1, "Avans Devops", "SO&A uitwerking");


            //Act
            backlog.AddBacklogItem(new BacklogItem(1, 1, 1, "Hond uitlaten", new Phase(), 0, 2));
            backlog.AddBacklogItem(new BacklogItem(1, 1, 2, "Kat uitlaten", new Phase(), 0, 2));
            backlog.AddBacklogItem(new BacklogItem(1, 1, 3, "Goudvis uitlaten", new Phase(), 0, 10));


            backlog.RemoveBacklogItem(2);

            //Assert
            Assert.True(backlog.BackLogItems.Count == 2);
        }
    }
}