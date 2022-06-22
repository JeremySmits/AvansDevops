using System;
using System.Collections.Generic;
using Avans_Devops.Observe;

namespace Avans_Devops.Pipeline
{
	public class TestPipeline : IPipeline, IObservable
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
			// A testing pipeline may only run if it has tests, analyses (test results) and no deployments.
			return hasTests() && hasAnalyses() && !hasDeployment();
		}

		public bool hasTests(){
			return this.Tests != null && this.Tests.Count > 0;
		}

		public bool hasAnalyses(){
			return this.Analyses != null && this.Analyses.Count > 0;
		}

		public bool hasDeployment(){
			return this.Deploys != null && this.Deploys.Count > 0;
		}
	}
}
