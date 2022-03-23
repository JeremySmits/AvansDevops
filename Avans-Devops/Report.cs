using System.IO;

namespace Avans_Devops
{
    public class Report
    {
        public int ReportId { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }

        public string GetBurnDownChart() { return null; }
        public string GetDeveloperEffortValues() { return null; }
    }
}