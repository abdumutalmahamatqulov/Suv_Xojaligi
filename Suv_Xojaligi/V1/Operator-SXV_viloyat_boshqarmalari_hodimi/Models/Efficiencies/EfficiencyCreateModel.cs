using System.ComponentModel.DataAnnotations;
using Suv_Xojaligi.Data.Entities.Commons;
using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models;

public class EfficiencyCreateModel
{
    public int? Year { get; set; }
    public decimal? Inestment { get; set; }
    public decimal? Enery_Consumption { get; set; }
    public decimal? Actual_Energy_Consumption { get; set; }
    public decimal? Actual_Budget { get; set; }
    public decimal? Percentage { get; set; }
    public OrdersStatus Current_Status { get; set; }
    public EffeciencyType Type { get; set; }
    public Efficiency ToEntity()
    {
        var efficiencyCreate = new Efficiency();
        efficiencyCreate.Id = Guid.NewGuid();
        efficiencyCreate.Year = this.Year;
        efficiencyCreate.Inestment = this.Inestment;
        efficiencyCreate.EneryConsumption = this.Enery_Consumption;
        efficiencyCreate.ActualEnergyConsumption = this.Actual_Energy_Consumption;
        efficiencyCreate.ActualBudget = this.Actual_Budget;
        efficiencyCreate.Percentage = this.Percentage;
        efficiencyCreate.CurrentStatus = this.Current_Status;
        efficiencyCreate.Type = this.Type;
        return efficiencyCreate;
    }
}
