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
		public static Pipeline CreatePipeline(PipelineType type, String title){
			Pipeline pipeline;
			switch(type)
			{
				case PipelineType.Deployment:
					Console.Write("Deployment pipeline made");
					pipeline = new DeploymentPipeline();
					break;
				case PipelineType.Test:
					Console.Write("Test pipeline made");
					pipeline = new TestPipeline();
					break;
				default:
					Console.Write("Generic pipeline made");
					pipeline = new GenericPipeline();
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
