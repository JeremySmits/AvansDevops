using Avans_Devops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Avans_Devops.Pipeline;

namespace Avans_Devops_Tests.Tests
{
    public class IPipelineTests
    {

        [Fact]
        public void TryValidGenericPipeline()
        {
            //Arrange
            var genericPipeline = PipelineFactory.CreatePipeline(PipelineType.Generic, "genericPipeline");

            genericPipeline.Sources.Add("Source 1");
            genericPipeline.Builds.Add("Build 1");
            genericPipeline.Analyses.Add("Analysis 1");
            genericPipeline.Deploys.Add("Deploy 1");

			//Act
            var canRun = genericPipeline.CanRun();

            //Assert
            Assert.True(canRun);
        }
		
        [Fact]
        public void RunSuccessGenericPipeline()
        {
            //Arrange
            var genericPipeline = PipelineFactory.CreatePipeline(PipelineType.Generic, "genericPipeline");

            genericPipeline.Sources.Add("Source 1");
            genericPipeline.Packages.Add("Package 1");
            genericPipeline.Builds.Add("Build 1");
            genericPipeline.Tests.Add("Test 1");
            genericPipeline.Analyses.Add("Analysis 1");
            genericPipeline.Deploys.Add("Deploy 1");
            genericPipeline.Deploys.Add("Deploy 2");
            genericPipeline.Utilities.Add("Utility 1");

			//Act
            var hasSucceeded = genericPipeline.RunPipeline();

            //Assert
            Assert.True(hasSucceeded);
        }

        [Fact]
        public void RunFailureGenericPipeline()
        {
            //Arrange
            var genericPipeline = PipelineFactory.CreatePipeline(PipelineType.Generic, "genericPipeline");

            genericPipeline.Sources.Add("Source 1");
            genericPipeline.Packages.Add("Package 1");
            genericPipeline.Builds.Add("Build 1");
            genericPipeline.Tests.Add("Fail");
            genericPipeline.Analyses.Add("Analysis 1");
            genericPipeline.Deploys.Add("Deploy 1");
            genericPipeline.Deploys.Add("Deploy 2");
            genericPipeline.Utilities.Add("Utility 1");

			//Act
            var hasSucceeded = genericPipeline.RunPipeline();

            //Assert
            Assert.False(hasSucceeded);
        }

        
    }
}
