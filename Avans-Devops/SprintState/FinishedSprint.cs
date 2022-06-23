using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops
{
    public class FinishedSprint : Sprint
    {
        public FinishedSprint(int sprintId, Backlog backlog, string name, DateTime startDate, DateTime endDate, string sprintType, User scrumMaster)
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
        public override string GetTypeSprint()
        {
            return "Finished";
        }
    }
}
