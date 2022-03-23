using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Pipeline
{
    public interface IPipelineBuilder
    {
        public List<Pipeline> Pipelines { get; set; }

        public void ReSet() { }
        public List<string> SetSources() { return null; }
        public List<string> SetPackages() { return null; }
        public List<string> SetBuilds() { return null; }
        public List<string> SetTests() { return null; }
        public List<string> SetAnalyses() { return null; }
        public List<string> SetDeploys() { return null; }
        public List<string> SetUtilities() { return null; }
        public void Build() { }
    }
}
