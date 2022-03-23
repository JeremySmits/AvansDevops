using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Observer
{
    public class IObservable
    {
        public void AddObserver() { }
        public void DeleteObserver() { }
        public void NotifyObservers() { }
        public void SetChanged() { }
    }
}
