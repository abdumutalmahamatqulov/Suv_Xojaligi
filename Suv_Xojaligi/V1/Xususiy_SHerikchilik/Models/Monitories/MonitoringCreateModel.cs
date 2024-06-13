using System.ComponentModel.DataAnnotations;
using Suv_Xojaligi.Data.Entities.Monitorings;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories;

public class MonitoringCreateModel
{
    [Required]
    public string Project_Name { get; set; }
    [Required]
    public string Private_Partner { get; set; }
    [Required]
    public TimeSpan? Time_of_period { get; set; }
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
    public Monitoring ToEntity()
    {
        var newMonitoring = new Monitoring();
        newMonitoring.Id = Guid.NewGuid();
        newMonitoring.Project_Name = this.Project_Name;
        newMonitoring.Private_Partner = this.Private_Partner;
        newMonitoring.Project_Value = this.Project_Value;
        newMonitoring.Private_Partner_Investment = this.Private_Partner_Investment;
        newMonitoring.Operating_Costs = this.Operating_Costs; 
        newMonitoring.Registry_Number_And_Date = DateTime.UtcNow;
        newMonitoring.Submission_And_Acceptance_Date = DateTime.UtcNow;
        return newMonitoring;
    }
}
