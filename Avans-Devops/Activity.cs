using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops
{
    public class Activity
    {
        public string Name { get; set; }
        public User ResponsibleDeveloper { get; set; }
        public BacklogItem BacklogItem { get; set; }
        public PhaseState State { get; set; }
        public DateTime? FinishedOn { get; set; }
        public int Effort { get; set; }

        public Activity(string name, User responsibleDeveloper, BacklogItem backlogItem, int effort)
        {
            Name = name;
            ResponsibleDeveloper = responsibleDeveloper;
            BacklogItem = backlogItem;
            State = PhaseState.ToDo;
            Effort = effort;
        }
        public void SetActvityToDone()
        {
            FinishedOn = DateTime.Today;
            bool AllActivitiesDone = true;

            foreach(Activity activitiy in BacklogItem.Activities)
            {
                if (activitiy.FinishedOn == null)
                    AllActivitiesDone = false;
            }

            if(AllActivitiesDone)
                BacklogItem.FinishedOn = DateTime.Today;
        }

    }
}
