using Avans_Devops.Observe;
using System;
using System.Collections.Generic;

namespace Avans_Devops
{
    public abstract class Sprint : IObservable
    {
        public int SprintId { get; set; }
        public Backlog Backlog { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SprintType { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }
        public User ScrumMaster { get; set; }
        public bool IsRunningPipeline { get; set; }
        public bool IsFinished { get; set; }
        public List<Observer> Observers { get; set; }

        public void SetSprintToFinished()
        {
            Observer observer = new();
            observer.Receiver = ScrumMaster;
            observer.Message = "BacklogItem: " + this.Name + " is done!";
            this.Observers.Add(observer);
            NotifyObservers();
            IsRunningPipeline = false;
            IsFinished = true;
        }

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
            if(!IsRunningPipeline)
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

        public void ReleaseSprint()
        {
            throw new NotImplementedException();
        }

        public virtual string GetTypeSprint()
        {
            return null;
        }

        public Report GenerateReport(FileType fileType)
        {
            return new Report(this, fileType);
        }
        public void NotifyObservers()
        {
            foreach (var o in Observers)
            {
                o.SendMessage();
            }
        }
    }
}
