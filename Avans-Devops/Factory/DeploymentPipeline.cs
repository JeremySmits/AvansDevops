using System;
using System.Collections.Generic;
using Avans_Devops.Observe;
using Avans_Devops.Releases;

namespace Avans_Devops.Pipelines
{
	public class DeploymentPipeline : IPipeline
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

        public DeploymentPipeline(string title)
        {
			Observers = new();
			Release = new SuccesRelease(Sprint);
			Title = title;
		}

		public bool CanRun()
		{
			// A deployment pipeline may only run if it has deployments
			return Deploys != null && Deploys.Count != 0;
		}
	}
}
