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
    public class DeploymentPipelineTests
    {
        [Fact]
        public void tryValidDeploymentPipeline()
        {
            //Arrange
            var deploymentPipeline = PipelineFactory.createPipeline(PipelineType.Deployment, "deploymentPipeline");

            deploymentPipeline.Sources.Add("Source 1");
            deploymentPipeline.Packages.Add("Package 1");
            deploymentPipeline.Builds.Add("Build 1");
            deploymentPipeline.Tests.Add("Test 1");
            deploymentPipeline.Analyses.Add("Analysis 1");
            deploymentPipeline.Deploys.Add("Deploy 1");
            deploymentPipeline.Deploys.Add("Deploy 2");
            deploymentPipeline.Utilities.Add("Utility 1");

			//Act
            var canRun = deploymentPipeline.canRun();

            //Assert
            Assert.True(canRun);
        }

        [Fact]
        public void tryInvalidDeploymentPipelineWithoutDeployment()
        {
            //Arrange
            var deploymentPipeline = PipelineFactory.createPipeline(PipelineType.Deployment, "deploymentPipeline");

            deploymentPipeline.Sources.Add("Source 1");
            deploymentPipeline.Packages.Add("Package 1");
            deploymentPipeline.Builds.Add("Build 1");
            deploymentPipeline.Tests.Add("Test 1");
            deploymentPipeline.Analyses.Add("Analysis 1");
            deploymentPipeline.Utilities.Add("Utility 1");

			//Act
            var canRun = deploymentPipeline.canRun();

            //Assert
            Assert.False(canRun);
        }
    }
}
