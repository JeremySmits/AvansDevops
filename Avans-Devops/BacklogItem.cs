using Avans_Devops.Observe;
using System;
using System.Collections.Generic;

namespace Avans_Devops
{
    public class BacklogItem : IObservable
    {
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public Backlog Backlog { get; set; }
        public int BacklogItemId { get; set; }
        public string Name { get; set; }
        public PhaseState State { get; set; }
        public List<Activity> Activities { get; set; }
        public User ResponsibleDeveloper { get; set; }
        public int ThreatId { get; set; }
        public DateTime? FinishedOn { get; set; }
        public int Effort { get; set; }
        public List<Observer> Observers { get; set; }

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
            Observers = new();
            FinishedOn = null;
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
                    if (nextstate == "Tested")
                    {
                        State = PhaseState.Tested;
                    }
                    break;
                case PhaseState.Tested:
                    if (nextstate == "Done")
                    {
                        Observer observer = new();
                        observer.Receiver = this.Sprint.ScrumMaster;
                        observer.Message = "BacklogItem: " + this.Name + " is done!";
                        this.Observers.Add(observer);
                        NotifyObservers();
                        State = PhaseState.Done;
                        FinishedOn = DateTime.Now;                       
                    }
                    if (nextstate == "Testing")
                    {
                        State = PhaseState.Testing;
                    }
                    break;
            }
        }
        public void NotifyObservers()
        {
            foreach (var o in Observers)
            {
                o.SendMessage();
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
                    if (nextstate == "Tested")
                    {
                        State = PhaseState.Tested;
                    }
                    break;
                case PhaseState.Tested:
                    if (nextstate == "Done")
                    {
                        Observer observer = new();
                        observer.Receiver = this.Sprint.ScrumMaster;
                        observer.Message = "BacklogItem: " + this.Name + " is done!";
                        this.Observers.Add(observer);
                        NotifyObservers();
                        State = PhaseState.Done;
                        FinishedOn = DateTime.Now;                       
                    }
                    if (nextstate == "Testing")
                    {
                        State = PhaseState.Testing;
                    }
                    break;
            }
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
