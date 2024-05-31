using System.ComponentModel.DataAnnotations;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories
{
    public class MonitoringUpdateModel
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
    }
}
