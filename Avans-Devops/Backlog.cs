﻿using System.Collections.Generic;

namespace Avans_Devops
{
    public class Backlog
    {
        public int BacklogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> ScrumTeam { get; set; }
        public List<Sprint> Sprints { get; set; }
        public List<BacklogItem> BackLogItems { get; set; }

        public Backlog(int backlogId, string name, string description)
        {
            BacklogId = backlogId;
            Name = name;
            Description = description;
            ScrumTeam = new List<User>();
            Sprints = new List<Sprint>();
            BackLogItems = new List<BacklogItem>();
        }

        public void AddSprint(Sprint Sprint) 
        {
            this.Sprints.Add(Sprint);
        }
        public void RemoveSprint(int SprintId) 
        {
            List<Sprint> tempSprints = new List<Sprint>();

            foreach(Sprint sprint in Sprints)
            {
                if (sprint.SprintId != SprintId)
                    tempSprints.Add(sprint);
            }

            Sprints = tempSprints;
        }
        public void AddUser(User User)
        {
            this.ScrumTeam.Add(User);
        }
        public void RemoveUser(int UserId)
        {
            List<User> tempUsers = new List<User>();

            foreach (User user in ScrumTeam)
            {
                if (user.UserId != UserId)
                    tempUsers.Add(user);
            }

            ScrumTeam = tempUsers;
        }
        public void AddBacklogItem(BacklogItem BackLogItem) 
        {
            this.BackLogItems.Add(BackLogItem);
        }
        public void RemoveBacklogItem(int BackLogItemId)
        {
            List<BacklogItem> tempBacklogItem= new List<BacklogItem>();

            foreach (BacklogItem backlogItem in BackLogItems)
            {
                if (backlogItem.BacklogItemId != BackLogItemId)
                    tempBacklogItem.Add(backlogItem);
            }

            BackLogItems = tempBacklogItem;
        }
    }
}
