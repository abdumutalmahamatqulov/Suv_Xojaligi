using Suv_Xojaligi.Data.Contexts.Configurations;
using Suv_Xojaligi.Data.Entities.Monitorings;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories
{
    public class MonitoringModel
    {
        public Guid Id { get; set; }
        public string Project_Name { get; set; }
        public string Private_Partner { get; set; }
        public int? Time_of_period { get; set; }
        public DateTime Registry_Number_And_Date { get; set; }
        public DateTime Submission_And_Acceptance_Date { get; set; }
        public decimal? Project_Value { get; set; }
        public decimal? Private_Partner_Investment { get; set; }
        public decimal? Operating_Costs { get; set; }
        public MonitoringModel MapFromEntity(Monitoring entity)
        {
            Id = entity.Id;
            Project_Name = entity.Project_Name;
            Private_Partner = entity.Private_Partner;
            Time_of_period = entity.Time_of_period;
            Registry_Number_And_Date = entity.Registry_Number_And_Date;
            Submission_And_Acceptance_Date = entity.Submission_And_Acceptance_Date;
            Project_Value = entity.Project_Value;
            Private_Partner_Investment = entity.Private_Partner_Investment;
            Operating_Costs = entity.Operating_Costs;
            return this;
        }
        public MonitoringModel MapFromEntityies(Monitoring entity)
        {
            return this;
        }
    }
}
