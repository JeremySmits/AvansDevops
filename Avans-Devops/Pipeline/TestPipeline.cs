using System;
using System.Collections.Generic;
using Avans_Devops.Observe;

namespace Avans_Devops.Pipeline
{
	public class TestPipeline : Pipeline, IObservable
	{
        public TestPipeline()
        {
			Observers = new();
		}

		public override bool CanRun()
		{
			// A testing pipeline may only run if it has tests, analyses (test results) and no deployments.
			return HasTests() && HasAnalyses() && !hasDeployment();
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
