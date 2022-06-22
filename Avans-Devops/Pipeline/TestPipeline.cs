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

		public override bool canRun()
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
