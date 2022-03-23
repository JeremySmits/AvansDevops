using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Observer
{
    class Observer
    {
        public User Receiver { get; set; }
        public string Message { get; set; }

        public void SendMessage(User Receiver, string Message) { }
    }
}
