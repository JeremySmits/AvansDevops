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
    public class TestPipelineTests
    {
        [Fact]
        public void TryValidTestPipeline()
        {
            //Arrange
            var testPipeline = PipelineFactory.CreatePipeline(PipelineType.Test, "testPipeline");

            testPipeline.Sources.Add("Source 1");
            testPipeline.Packages.Add("Package 1");
            testPipeline.Builds.Add("Build 1");
            testPipeline.Tests.Add("Test 1");
            testPipeline.Analyses.Add("Analysis 1");
            testPipeline.Utilities.Add("Utility 1");

			//Act
            var canRun = testPipeline.CanRun();

            //Assert
            Assert.True(canRun);
        }

        [Fact]
        public void TryInvalidTestPipelineWithoutTests()
        {
            //Arrange
            var testPipeline = PipelineFactory.CreatePipeline(PipelineType.Test, "testPipeline");

            testPipeline.Sources.Add("Source 1");
            testPipeline.Packages.Add("Package 1");
            testPipeline.Builds.Add("Build 1");
            testPipeline.Analyses.Add("Analysis 1");
            testPipeline.Deploys.Add("Deploy 1");
            testPipeline.Deploys.Add("Deploy 2");
            testPipeline.Utilities.Add("Utility 1");

			//Act
            var canRun = testPipeline.CanRun();

            //Assert
            Assert.False(canRun);
        }

		[Fact]
        public void TryInvalidTestPipelineWithoutAnalyses()
        {
            //Arrange
            var testPipeline = PipelineFactory.CreatePipeline(PipelineType.Test, "testPipeline");

            testPipeline.Sources.Add("Source 1");
            testPipeline.Packages.Add("Package 1");
            testPipeline.Builds.Add("Build 1");
            testPipeline.Tests.Add("Test 1");
            testPipeline.Deploys.Add("Deploy 1");
            testPipeline.Deploys.Add("Deploy 2");
            testPipeline.Utilities.Add("Utility 1");

			//Act
            var canRun = testPipeline.CanRun();

            //Assert
            Assert.False(canRun);
        }

		[Fact]
        public void TryInvalidTestPipelineWithDeployment()
        {
            //Arrange
            var testPipeline = PipelineFactory.CreatePipeline(PipelineType.Test, "testPipeline");

            testPipeline.Sources.Add("Source 1");
            testPipeline.Packages.Add("Package 1");
            testPipeline.Builds.Add("Build 1");
            testPipeline.Tests.Add("Test 1");
            testPipeline.Analyses.Add("Analysis 1");
            testPipeline.Deploys.Add("Deploy 1");
            testPipeline.Deploys.Add("Deploy 2");
            testPipeline.Utilities.Add("Utility 1");

			//Act
            var canRun = testPipeline.CanRun();

            //Assert
            Assert.False(canRun);
        }
    }
}
