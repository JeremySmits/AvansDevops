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
    }
}
