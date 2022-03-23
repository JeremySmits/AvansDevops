using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Pipeline
{
    public class Director
    {
        public IPipelineBuilder PipelineBuilder { get; set; }
        public void BuildPipeline(IPipelineBuilder pipelineBuilder) { }
    }
}
