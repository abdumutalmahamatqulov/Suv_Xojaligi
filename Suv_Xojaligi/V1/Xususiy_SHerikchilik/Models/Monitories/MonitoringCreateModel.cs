using System.ComponentModel.DataAnnotations;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories
{
    public class MonitoringCreateModel
    {
        [Required]
        public string Project_Name { get; set; }
        [Required]
        public string Private_Partner { get; set; }
        [Required]
        public int Time_of_period { get; set; }
        [Required]
        public DateTime Registry_Number_And_Date { get; set; }
        [Required]
        public DateTime Submission_And_Acceptance_Date { get; set; }
        [Required]
        public decimal Project_Value { get; set; }
        [Required]
        public decimal Private_Partner_Investment { get; set; }
        [Required]
        public decimal Operating_Costs { get; set; }
    }
}
