using System;
using System.Collections.Generic;
using Avans_Devops.Observe;

namespace Avans_Devops.Pipelines
{

	public enum PipelineType
	{
		Deployment,
		Test,
		Generic
	}

	public static class PipelineFactory
	{
		public static IPipeline CreatePipeline(PipelineType type, String title){
			IPipeline pipeline;
			switch(type)
			{
				case PipelineType.Deployment:
					Console.Write("Deployment pipeline made");
					pipeline = new DeploymentPipeline(title);
					break;
				case PipelineType.Test:
					Console.Write("Test pipeline made");
					pipeline = new TestPipeline(title);
					break;
				default:
					Console.Write("Generic pipeline made");
					pipeline = new GenericPipeline(title);
					break;
			}

			pipeline.Sources = new List<String>();
			pipeline.Sources = new List<String>();
			pipeline.Packages = new List<String>();
			pipeline.Builds = new List<String>();
			pipeline.Tests = new List<String>();
			pipeline.Analyses = new List<String>();
			pipeline.Deploys = new List<String>();
			pipeline.Utilities = new List<String>();

			return pipeline;


		}

		
	}
}
