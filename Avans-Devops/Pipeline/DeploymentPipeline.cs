﻿using System;
using System.Collections.Generic;
using Avans_Devops.Observe;

namespace Avans_Devops.Pipeline
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
		public List<Observer> Observers { get; set;} = new List<Observer>();

		public bool canRun()
		{
			// A deployment pipeline may only run if it has deployments
			return Deploys != null && Deploys.Count != 0;
		}
	}
}