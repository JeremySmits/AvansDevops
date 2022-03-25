using System;
using System.Collections.Generic;

namespace Avans_Devops
{
    public interface ISprint
    {
        public int SprintId { get; }
        public Report RunPipeline();
        public void UpdateSprinteDetails();
        public void AddBacklogItem(BacklogItem backlogItem);
        public void RemoveBacklogItem(BacklogItem BacklogItem);
        public void ReleaseSprint();
        public bool CheckSprintStarted();
        public bool CheckSprintDone();
    }
}