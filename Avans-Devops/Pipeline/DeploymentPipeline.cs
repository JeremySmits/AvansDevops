﻿using System;
using System.Collections.Generic;
using Avans_Devops.Observe;

namespace Avans_Devops.Pipeline
{
	public class DeploymentPipeline : Pipeline, IObservable
	{
        public DeploymentPipeline()
        {
			Observers = new();
        }

		public override bool CanRun()
		{
			// A deployment pipeline may only run if it has deployments
			return Deploys != null && Deploys.Count != 0;
		}
	}
}
