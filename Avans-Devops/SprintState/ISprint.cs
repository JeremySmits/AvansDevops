using System;
using System.Collections.Generic;

namespace Avans_Devops
{
    public abstract class Sprint
    {
        public int SprintId { get; set; }
        public int BacklogId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SprintType { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }
        public User ScrumMaster { get; set; }

        public bool CheckSprintStarted()
        {
            if (StartDate > DateTime.Today)
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

        public void UpdateSprinteDetails()
        {
            throw new NotImplementedException();
        }

        public void RemoveBacklogItem(BacklogItem BacklogItem)
        {
            throw new NotImplementedException();
        }

        public void ReleaseSprint()
        {
            throw new NotImplementedException();
        }
    }
}