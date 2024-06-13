using Suv_Xojaligi.Data.Entities.Commons;
using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Efficiencies;

public class EfficiencyUpdateModel
{
    public Guid Id { get; set; }
    public int? Year { get; set; }
    public decimal Inestment { get; set; }
    public decimal Enery_Consumption { get; set; }
    public decimal Actual_Energy_Consumption { get; set; }
    public decimal Actual_Budget { get; set; }
    public decimal Percentage { get; set; }
    public OrdersStatus Current_Status { get; set; }
    public EffeciencyType Type { get; set; }
    public Guid ReportId { get; set; }
    public Efficiency ToEntity()
    {
        var newEfficiency = new Efficiency();
        newEfficiency.Id = this.Id;
        newEfficiency.Year = this.Year;
        newEfficiency.Inestment = this.Inestment;
        newEfficiency.EneryConsumption = this.Enery_Consumption;
        newEfficiency.ActualEnergyConsumption = this.Actual_Energy_Consumption;
        newEfficiency.ActualBudget = this.Actual_Budget;
        newEfficiency.Percentage = this.Percentage;
        newEfficiency.CurrentStatus = this.Current_Status;
        newEfficiency.Type = this.Type;
        newEfficiency.ReportId = this.ReportId;
        return newEfficiency;
    }
}
