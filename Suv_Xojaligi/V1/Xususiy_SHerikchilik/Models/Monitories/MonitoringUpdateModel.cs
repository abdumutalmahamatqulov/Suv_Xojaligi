using System.ComponentModel.DataAnnotations;
using Suv_Xojaligi.Data.Entities.Monitorings;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories
{
    public class MonitoringUpdateModel
    {
        public Guid Id { get; set; }
        public string Project_Name { get; set; }
        public string Private_Partner { get; set; }
        public TimeSpan? Time_of_period { get; set; }
        public DateTime Registry_Number_And_Date { get; set; }
        public DateTime Submission_And_Acceptance_Date { get; set; }
        public decimal? Project_Value { get; set; }
        public decimal? Private_Partner_Investment { get; set; }
        public decimal? Operating_Costs { get; set; }
        public Monitoring ToEntity()
        {
            var newMonitoring = new Monitoring();
            newMonitoring.Id = this.Id;
            newMonitoring.Project_Name = this.Project_Name;
            newMonitoring.Private_Partner = this.Private_Partner;
            newMonitoring.Project_Value = this.Project_Value;
            newMonitoring.Private_Partner_Investment = this.Private_Partner_Investment;
            newMonitoring.Operating_Costs = this.Operating_Costs;
            newMonitoring.Registry_Number_And_Date = this.Registry_Number_And_Date;
            newMonitoring.Submission_And_Acceptance_Date = this.Submission_And_Acceptance_Date;
            return newMonitoring;
        }
    }
}
