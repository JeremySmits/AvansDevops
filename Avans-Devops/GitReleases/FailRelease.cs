using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Devops.Observe;

namespace Avans_Devops.Releases
{
    public class FailRelease : IObservable
    {
        public List<Observer> Observers { get; set; } = new List<Observer>();

        public void Proceed() {
            string message = "The release has been cancelled!";

            // Scrum master notification
            User scrumMaster = new(1, "Scrum Master Placeholder", Roles.ScrumMaster, "scrum@master.com");
            Observer scrumMasterObserver = new();
            scrumMasterObserver.Receiver = scrumMaster;
            scrumMasterObserver.Message = message;
            AttachObserver(scrumMasterObserver);
            
            // Product owner notification
            User productOwner = new(2, "Product Owner Placeholder", Roles.ProductOwner, "product@owner.com");
            Observer productOwnerObserver = new();
            productOwnerObserver.Receiver = productOwner;
            productOwnerObserver.Message = message;
            AttachObserver(productOwnerObserver);

            NotifyObservers();
        }
        public void AttachObserver(Observer observer) {
            this.Observers.Add(observer);
        }
        public void DetachObserver(Observer observer) {
            this.Observers.Remove(observer);
        }
        public void NotifyObservers() {
            foreach (var o in Observers) {
                o.SendMessage();
            }
        }
    }
}
