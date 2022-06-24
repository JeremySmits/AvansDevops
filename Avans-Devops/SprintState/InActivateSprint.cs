using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops
{
    public class InActivateSprint : Sprint
    {
        public InActivateSprint(int sprintId, Backlog backlog, string name, DateTime startDate, DateTime endDate, string sprintType, User scrumMaster)
        {
            SprintId = sprintId;
            Backlog = backlog;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            SprintType = sprintType;
            BacklogItems = new();
            ScrumMaster = scrumMaster;
            IsRuningPipeline = false;
            IsFinished = false;
        }

        public override string GetTypeSprint()
        {
            return "Inactive";
        }

        public override void AddBacklogItem(BacklogItem backlogItem)
        {
            if (CheckSprintStarted() && !CheckSprintDone() && !IsRuningPipeline)
            {
                BacklogItems.Add(backlogItem);
            }
        }

        public override void UpdateSprinteDetails(int sprintId, Backlog backlog,
            string name, DateTime startDate, DateTime endDate, string sprintType,
            User scrumMaster)
        {
            SprintId = sprintId;
            Backlog = backlog;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            SprintType = sprintType;
            BacklogItems = new();
            ScrumMaster = scrumMaster;
        }
    }
}
