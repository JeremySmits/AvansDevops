using System;
using System.Collections.Generic;
using Avans_Devops.Observe;

namespace Avans_Devops.Pipeline
{
	public class GenericPipeline : IPipeline, IObservable
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
		public List<Observer> Observers { get; set;} = new List<Observer>();

		public bool canRun()
		{
			// A generic pipeline may always run, even if it has no steps.
			return true;
		}
	}
}
