using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops
{
    public class ActiveSprint : Sprint
    {
        public ActiveSprint(int sprintId, Backlog backlog, string name, DateTime startDate, DateTime endDate, string sprintType, User scrumMaster)
        {
            SprintId = sprintId;
            Backlog = backlog;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            SprintType = sprintType;
            BacklogItems = new();
            ScrumMaster = scrumMaster;
            IsFinished = false;
        }
        public override string GetTypeSprint()
        {
            return "Active";
        }
    }
}
