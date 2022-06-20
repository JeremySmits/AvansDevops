using System;
using System.Collections.Generic;
using Avans_Devops.Observe;

namespace Avans_Devops.Pipeline
{

	public enum PipelineType
	{
		Development,
		Test,
		Other
	}

	public static class PipelineFactory
	{
		public static IPipeline createPipeline(PipelineType type){
			switch(type)
			{
				case PipelineType.Development:
				Console.Write("Development pipeline made");
				break;
				case PipelineType.Test:
				Console.Write("Development pipeline made");
				break;
				case PipelineType.Other:
				default:
				Console.Write("Generic pipeline made");
				break;
			}
		}

		
	}
}
