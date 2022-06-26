using System;
using System.Collections.Generic;
using Avans_Devops.Observe;
using Avans_Devops.Releases;

namespace Avans_Devops.Pipelines
{
	public class TestPipeline : IPipeline
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
		public IRelease Release { get; set; }
		public List<Observer> Observers { get; set; }
		public Sprint Sprint { get; set; }

		public TestPipeline(string title)
        {
			Observers = new();
			Title = title;
		}

		public bool CanRun()
		{
			// A testing pipeline may only run if it has tests, analyses (test results) and no deployments.
			return HasTests() && HasAnalyses() && !HasDeployment();
		}

		public bool HasTests(){
			return this.Tests != null && this.Tests.Count > 0;
		}

		public bool HasAnalyses(){
			return this.Analyses != null && this.Analyses.Count > 0;
		}

		public bool HasDeployment(){
			return this.Deploys != null && this.Deploys.Count > 0;
		}
	}
}
