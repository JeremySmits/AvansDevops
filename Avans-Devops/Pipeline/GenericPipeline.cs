using System;
using System.Collections.Generic;
using Avans_Devops.Observe;

namespace Avans_Devops.Pipeline
{
	public class GenericPipeline : Pipeline, IObservable
	{
		public override bool canRun()
		{
			// A generic pipeline may always run, even if it has no steps.
			return true;
		}
	}
}
