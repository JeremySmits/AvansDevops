using System;
using System.Collections.Generic;

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
        public Company Company { get; set; }

        public Backlog(int backlogId, string name, string description)
        {
            BacklogId = backlogId;
            Name = name;
            Description = description;
            ScrumTeam = new List<User>();
            Sprints = new List<Sprint>();
            BackLogItems = new List<BacklogItem>();
            Company = new Company("Default Company", "Default logo");
        }

        public Backlog(int backlogId, string name, string description, Company company)
        {
            BacklogId = backlogId;
            Name = name;
            Description = description;
            ScrumTeam = new List<User>();
            Sprints = new List<Sprint>();
            BackLogItems = new List<BacklogItem>();
            Company = company;
        }

        public void AddSprint(Sprint Sprint) 
        {
            this.Sprints.Add(Sprint);
        }
        public void RemoveSprint(int SprintId) 
        {
            List<Sprint> tempSprints = new();

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
            List<User> tempUsers = new();

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
            List<BacklogItem> tempBacklogItem= new();

            foreach (BacklogItem backlogItem in BackLogItems)
            {
                if (backlogItem.BacklogItemId != BackLogItemId)
                    tempBacklogItem.Add(backlogItem);
            }

            BackLogItems = tempBacklogItem;
        }
        public bool RunSprintDeployment(Sprint sprint, int i)
        {
            if(sprint.GetTypeSprint() == "Active")
            {
                if (sprint.RunPipeline(i))
                {
                    foreach (Sprint s in Sprints)
                    {
                        List<Sprint> sprintsCopy = new();
                        if (s.SprintId == sprint.SprintId)
                        {
                            sprintsCopy.Add(new FinishedSprint(sprint.SprintId, sprint.BacklogId, sprint.Name,
                                sprint.StartDate, sprint.EndDate, sprint.SprintType, sprint.ScrumMaster));
                        }
                        else
                        {
                            sprintsCopy.Add(s);
                        }
                        Sprints = sprintsCopy;
                    }

                    return true;
                }
                else
                {
                    Console.WriteLine("Build Failed");
                    return false;
                }
            }
            return false;
        }
    }
}
