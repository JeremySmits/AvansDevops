using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Devops.Observe;


namespace Avans_Devops.Pipeline
{
    public abstract class IPipelineFactory
    {
        public string Title { get; set; }
        public List<IPipelineFactory> Pipelines { get; set; }
        public void ReSet() { }
        public List<string> SetSources() { return null; }
        public List<string> SetPackages() { return null; }
        public List<string> SetBuilds() { return null; }
        public List<string> SetTests() { return null; }
        public List<string> SetAnalyses() { return null; }
        public List<string> SetDeploys() { return null; }
        public List<string> SetUtilities() { return null; }
        public void Build() { }

        public List<Observer> Observers { get; } = new List<Observer>();

        public void RunPipeline() {
            // if onderdeel niet leeg, run dat onderdeel
            // als onderdeel faalt, NotifyObserver met gefaalde onderdeel naar scrum master.
            // als alle onderdelen goed gaan NotifyObserver message naar scrum master en product owner.
            // als alle onderdelen goed gaan, sprint wordt op finished gezet
            List<List<string>> steps = new List<List<string>>();

            String failed = null;

            foreach (var step in steps) {
                if (step.Count > 0) {
                    foreach (var item in step) {
                        // De console log is het uitvoeren
                        Console.Write(item);
                        if (item == "fail") {
                           // De pipeline faalt; melding naar scrum master met gefaalde item & pipeline 
                           failed = item;
                           break;
                        };
                    }
                }
                if (failed != null) {
                    // Failed is niet leeg, dus stop met pipeline
                    break;
                }
                // Else het onderdeel is leeg en gaat verder
            }
            NotifyObservers(failed);
        }
        public void AttachObserver(Observer observer) {
            this.Observers.Add(observer);
        }
        public void DetachObserver(Observer observer) {
            this.Observers.Remove(observer);
        }
        public void NotifyObservers(String failed) {
            String message;
            // Als failed null is dat is de pipeline geslaagd
            if (failed == null) {
                message = "Pipeline " + this.Title + " has succeeded!";
            } else {
                message = "Item " + failed[0] + " in pipeline " + this.Title;
            }

            foreach (var o in Observers) {
                o.Message = message;
                o.SendMessage();
            }
        }
    }
}
