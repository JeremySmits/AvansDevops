using System.Collections.Generic;

namespace Avans_Devops
{
    public class BacklogItem
    {
        public int SprintId { get; set; }
        public int BacklogId { get; set; }
        public int BacklogItemId { get; set; }
        public string Name { get; set; }
        public Phase State { get; set; }
        public List<Activity> Activities { get; set; }
        public int ThreatId { get; set; }
        public int Effort { get; set; }

        public BacklogItem(int sprintId, int backlogId,int backlogItemId, string name, Phase state, int threatId, int effort)
        {
            SprintId = sprintId;
            BacklogId = backlogId;
            BacklogItemId = backlogItemId;
            Name = name;
            State = state;
            Activities = new List<Activity>();
            ThreatId = threatId;
            Effort = effort;
        }

        public bool CheckActivitiesDone() { return false; }
        public void AddActivity(Activity Activity) { }
        public void SwitchState(Phase state) { }
    }
}