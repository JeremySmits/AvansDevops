using System;
using System.Collections.Generic;
using Avans_Devops.Observe;
using Avans_Devops.Releases;

namespace Avans_Devops.Pipeline
{
	public class DeploymentPipeline : Pipeline, IObservable
	{
        public DeploymentPipeline()
        {
			Observers = new();
			Release = new SuccesRelease();
		}

		public override bool CanRun()
		{
			// A deployment pipeline may only run if it has deployments
			return Deploys != null && Deploys.Count != 0;
		}
	}
}
