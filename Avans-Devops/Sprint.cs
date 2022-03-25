using System;
using System.Collections.Generic;

namespace Avans_Devops
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public int BacklogId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SprintType { get; set; }
        public ISprintState SprintState { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }

        public Sprint(int sprintId, int backlogId, string name, DateTime startDate, DateTime endDate, string sprintType, ISprintState sprintState)
        {
            SprintId = sprintId;
            BacklogId = backlogId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            SprintType = sprintType;
            SprintState = sprintState;
            BacklogItems = new();
        }

        public bool CheckSprintStarted() 
        { 
            if(StartDate > DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckSprintDone()
        {
            if (EndDate < DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddBacklogItem(BacklogItem backlogItem)
        {
            if (CheckSprintStarted() && !CheckSprintDone())
            {
                BacklogItems.Add(backlogItem);
            }
        }

        public Report RunPipeline() { return new Report(); }
    }
}