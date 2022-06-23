using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Avans_Devops
{
    public class Report
    {
        public int ReportId { get; set; }
        public List<string> Header { get; set; }
        public List<string> Footer { get; set; }
        public SortedDictionary<DateTime?, int> BurnDownChart;
        public Dictionary<User, int> DeveloperEffortValues;
        public Report(Sprint sprint)
        {
            // BurnDownChart
            BurnDownChart = new SortedDictionary<DateTime?, int>();
            GenerateBurnDownChart(sprint.BacklogItems, sprint.EndDate);
    
            // Effort per developer
            GenerateDeveloperEffortValues(sprint.BacklogItems);

            Random rnd = new Random();
            ReportId = rnd.Next(9999);

            Header = new List<string>();
            // Projectnaam
            Header.Add(sprint.Backlog.Name);
            // Bedrijfsnaam
            Header.Add(sprint.Backlog.Company.Name);
            // Bedrijfslogo
            Header.Add(sprint.Backlog.Company.Logo);

            Footer = new List<string>();
            // Versie
            Footer.Add(sprint.Name);
            // Datum
            Footer.Add(sprint.StartDate + " - " + sprint.EndDate);

        }

        public void GenerateBurnDownChart(List<BacklogItem> BacklogItems, DateTime endTime)
        {
            List<BacklogItem> FinishedBacklogItems = new List<BacklogItem>();
            List<BacklogItem> NonFinishedBacklogItems = new List<BacklogItem>();
            int totalEffort = 0;

            foreach (BacklogItem backlogItem in BacklogItems)
            {
                if (backlogItem.State == PhaseState.Done)
                {
                    FinishedBacklogItems.Add(backlogItem);
                }
                else
                {
                    NonFinishedBacklogItems.Add(backlogItem);
                }
                totalEffort += backlogItem.Effort;
            }

            foreach (BacklogItem backlogItem in FinishedBacklogItems){
                if (BurnDownChart.ContainsKey(backlogItem.FinishedOn))
                {
                    // If date already exists in the list, add effort onto the existing value
                    BurnDownChart[backlogItem.FinishedOn] = (int)BurnDownChart[backlogItem.FinishedOn] + backlogItem.Effort;
                    totalEffort -= backlogItem.Effort;
                }
                else
                {
                    // If date is new in the list, add effort as the new (first) value
                    BurnDownChart[backlogItem.FinishedOn] = backlogItem.Effort;
                    totalEffort -= backlogItem.Effort;
                }
            }

            DateTime lastDate = (DateTime)BurnDownChart.Keys.Last();

            if (BurnDownChart.ContainsKey(lastDate))
            {
                BurnDownChart[lastDate] = (int)BurnDownChart[lastDate] + totalEffort;
            }
            else
            {
                BurnDownChart[lastDate] = totalEffort;
            }
        }
        public void GenerateDeveloperEffortValues(List<BacklogItem> BacklogItems)
        {
            foreach (BacklogItem backlogItem in BacklogItems)
            {
                foreach (Activity activity in backlogItem.Activities)
                {
                    if (activity.State == PhaseState.Done) {
                        if (DeveloperEffortValues.ContainsKey(activity.ResponsibleDeveloper))
                        {
                            DeveloperEffortValues[activity.ResponsibleDeveloper] += activity.Effort;
                        }
                        else
                        {
                            DeveloperEffortValues[activity.ResponsibleDeveloper] = activity.Effort;
                        }
                    }
                }
            }

        }
    }
}