using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Devops.Observe;
using Avans_Devops.Releases;

namespace Avans_Devops.Pipelines
{
    public interface IPipeline: IObservable
    {
        public string Title { get; set; }
        public int PipelineId { get; set; }
        public List<string> Sources { get; set; }
        public List<string> Packages { get; set; }
        public List<string> Builds { get; set; }
        public List<string> Tests { get; set; }
        public List<string> Analyses { get; set; }
        public List<string> Deploys { get; set; }
        public List<string> Utilities { get; set; }
        public GitIntegration GitIntegration { get; set; }
        public Sprint Sprint { get; set; }

        public IRelease Release { get; set; }

        public bool CanRun();

		public bool RunPipeline(User scrumMaster) {
            if (CanRun()){

                List<List<string>> steps = new();
                steps.Add(this.Sources);
                steps.Add(this.Packages);
                steps.Add(this.Builds);
                steps.Add(this.Tests);
                steps.Add(this.Analyses);
                steps.Add(this.Deploys);
                steps.Add(this.Utilities);

                String failed = null;

                foreach (var step in steps) {
                    if (step.Count > 0) {
                        foreach (var item in step) {
                            // De console log is het uitvoeren
                            Console.Write(item);
                            if (item == "Fail") {
                                // De pipeline faalt; melding naar scrum master met gefaalde item & pipeline 
                                failed = item;
                                break;
                            }
                        }
                    }
                    if (failed != null) {
                        // Failed is niet leeg, dus stop met pipeline
                        break;
                    }
                    // Else het onderdeel is leeg en gaat verder
                }
                Observer observer = new();
                String message;
                // Als failed null is dat is de pipeline geslaagd
                if (failed == null) {
                    message = "Pipeline " + this.Title + " has succeeded!";
                } 
                else 
                {
                    message = "Item " + failed + " in pipeline " + this.Title;
                }
                observer.Message = message;
                observer.Receiver = scrumMaster;
                // AttachObserver(observer);
                this.Observers.Add(observer);
                NotifyObservers();

                // Als pipeline succesvol is, zet sprint op finished
                if (failed == null) {
                    //Placeholder voor de sprint
                    if(GitIntegration!=null)
                    GitIntegration.CommitAndPushToMaster();
                    return true;
                } 
                else 
                {
                    return false;
                }
            }
            else {
                Console.Write("This pipeline is invalid!");
                return false;
            }

            // if onderdeel niet leeg, run dat onderdeel
            // als onderdeel faalt, NotifyObserver met gefaalde onderdeel naar scrum master.
            // als alle onderdelen goed gaan NotifyObserver message naar scrum master en product owner.
            // als alle onderdelen goed gaan, sprint wordt op finished gezet
            
        }
        
    }
}
