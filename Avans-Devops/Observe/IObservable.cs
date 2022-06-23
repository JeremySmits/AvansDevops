using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Observe
{
    public interface IObservable
    {
        public List<Observer> Observers { get; set; }

        public void AttachObserver(Observer observer)
        {
            this.Observers.Add(observer);
        }
        public void DetachObserver(Observer observer)
        {
            this.Observers.Remove(observer);
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
