using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops
{
    public class FinishedSprint : ISprint
    {
        public int SprintId { get; set; }
        public int BacklogId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SprintType { get; set; }
        public ISprint SprintState { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }

        public FinishedSprint(int sprintId, int backlogId, string name, DateTime startDate, DateTime endDate, string sprintType)
        {
            SprintId = sprintId;
            BacklogId = backlogId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            SprintType = sprintType;
            BacklogItems = new();
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
