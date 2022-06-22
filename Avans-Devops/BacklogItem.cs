using System.Collections.Generic;

namespace Avans_Devops
{
    public class BacklogItem
    {
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public Backlog Backlog { get; set; }
        public int BacklogItemId { get; set; }
        public string Name { get; set; }
        public PhaseState State { get; set; }
        public List<Activity> Activities { get; set; }
        public int ThreatId { get; set; }
        public int Effort { get; set; }

        public BacklogItem(int sprintId, Backlog backlog, int backlogItemId, string name, int threatId, int effort)
        {
            SprintId = sprintId;
            Backlog = backlog;
            BacklogItemId = backlogItemId;
            Name = name;
            State = PhaseState.ToDo;
            Activities = new List<Activity>();
            ThreatId = threatId;
            Effort = effort;
        }

        public void AddActivity(Activity Activity) 
        {
            if(this.Sprint != null)
            {
                if (this.Sprint.CheckSprintStarted())
                {
                    this.Activities.Add(Activity);
                }
            }
        }

        public void SwitchState(string nextstate) 
        {
            switch (this.State)
            {
                case PhaseState.ToDo:
                    if(nextstate == "Doing")
                    {
                        State = PhaseState.Doing;
                    }
                    break;
                case PhaseState.Doing:
                    if (nextstate == "ReadyForTesting")
                    {
                        State = PhaseState.ReadyForTesting;
                    }
                    break;
                case PhaseState.ReadyForTesting:
                    if (nextstate == "Testing")
                    {
                        State = PhaseState.Testing;
                    }
                    break;
                case PhaseState.Testing:
                    if (nextstate == "ToDo")
                    {
                        State = PhaseState.ToDo;
                    }
                    if (nextstate == "Done")
                    {
                        State = PhaseState.Done;
                    }
                    break;
                case PhaseState.Done:
                    break;
            }
        }
    }
}