using System;
using System.Collections.Generic;

namespace Avans_Devops
{
    public abstract class Sprint
    {
        public int SprintId { get; set; }
        public Backlog Backlog { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SprintType { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }
        public User ScrumMaster { get; set; }
        public bool IsRuningPipeline { get; set; }

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
            if(!IsRuningPipeline)
            {
                List<BacklogItem> tempBacklogItem = new();

                foreach (BacklogItem backlogItem in BacklogItems)
                {
                    if (backlogItem.BacklogItemId != BackLogItemId)
                        tempBacklogItem.Add(backlogItem);
                }

                BacklogItems = tempBacklogItem;
            }
        }

        public virtual void UpdateSprinteDetails(int sprintId, Backlog backlog, 
            string name, DateTime startDate, DateTime endDate, string sprintType, 
            User scrumMaster)
        {
            Console.WriteLine("Je kan alleen een sprint aanpassen als de status inactive is!");
        }

        public virtual void UpdateBacklogItemState(BacklogItem bitem, PhaseState phaseState)
        {
            bitem.State = phaseState;
            List<BacklogItem> tempBacklogItem = new();

            foreach (BacklogItem backlogItem in BacklogItems)
            {
                if (backlogItem.BacklogItemId != bitem.SprintId)
                    tempBacklogItem.Add(backlogItem);
            }

            BacklogItems = tempBacklogItem;
        }

        public bool RunPipeline(int i) 
        {
            IsRuningPipeline = true;
            if (i == 1)
            {
                IsRuningPipeline = false;
                return true;
            }
            IsRuningPipeline = false;
            return false;
        }

        public void ReleaseSprint()
        {
            throw new NotImplementedException();
        }

        public virtual string GetTypeSprint()
        {
            return null;
        }

        public Report GenerateReport(FileType FileType)
        {
            return new Report(this, FileType);
        }
    }
}