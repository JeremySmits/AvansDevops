using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Observe
{
    public interface IObservable
    {
        public void AttachObserver(Observer observer);
        public void DetachObserver(Observer observer);
        public void NotifyObservers();
    }
}
