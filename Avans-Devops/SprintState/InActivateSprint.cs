using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops
{
    public class InActivateSprint : Sprint
    {
        public InActivateSprint(int sprintId, int backlogId, string name, DateTime startDate, DateTime endDate, string sprintType, User scrumMaster)
        {
            SprintId = sprintId;
            BacklogId = backlogId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            SprintType = sprintType;
            BacklogItems = new();
            ScrumMaster = scrumMaster;
        }

        public override string GetTypeSprint()
        {
            return "Inactive";
        }

        public override void AddBacklogItem(BacklogItem backlogItem)
        {
            if (CheckSprintStarted() && !CheckSprintDone())
            {
                BacklogItems.Add(backlogItem);
            }
        }

        public override void UpdateSprinteDetails(int sprintId, int backlogId,
            string name, DateTime startDate, DateTime endDate, string sprintType,
            User scrumMaster)
        {
            SprintId = sprintId;
            BacklogId = backlogId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            SprintType = sprintType;
            BacklogItems = new();
            ScrumMaster = scrumMaster;
        }
    }
}
