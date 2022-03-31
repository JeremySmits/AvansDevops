using System;
using System.Collections.Generic;

namespace Avans_Devops
{
    public abstract class Sprint
    {
        public int SprintId { get; set; }
        protected int BacklogId { get; set; }
        protected string Name { get; set; }
        protected DateTime StartDate { get; set; }
        protected DateTime EndDate { get; set; }
        protected string SprintType { get; set; }
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

        public virtual void AddBacklogItem(BacklogItem backlogItem)
        {
            Console.WriteLine("Je kan alleen een sprint aanpassen als de status inactive is!");
        }

        public void RemoveBacklogItem(int BackLogItemId)
        {
            List<BacklogItem> tempBacklogItem = new();

            foreach (BacklogItem backlogItem in BacklogItems)
            {
                if (backlogItem.BacklogItemId != BackLogItemId)
                    tempBacklogItem.Add(backlogItem);
            }

            BacklogItems = tempBacklogItem;
        }

        public virtual void UpdateSprinteDetails(int sprintId, int backlogId, 
            string name, DateTime startDate, DateTime endDate, string sprintType, 
            User scrumMaster)
        {
            Console.WriteLine("Je kan alleen een sprint aanpassen als de status inactive is!");
        }

        public Report RunPipeline() { return new Report(); }

        public void ReleaseSprint()
        {
            throw new NotImplementedException();
        }

        public virtual string GetTypeSprint()
        {
            return null;
        }
    }
}