using Suv_Xojaligi.Data.Entities.Commons;
using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;
using System.ComponentModel.DataAnnotations;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Hisobotlar;

public class EfficiencyModel
{
    public Guid Id { get; set; }
    public int? Year { get; set; }
    public decimal? Inestment { get; set; }
    public decimal? Enery_Consumption { get; set; }
    public decimal? Actual_Energy_Consumption { get; set; }
    public decimal? Actual_Budget { get; set; }
    public decimal? Percentage { get; set; }
    public OrdersStatus Current_Status { get; set; }
    public EffeciencyType Type { get; set; }
    public Guid ReportId { get; set; }
    public Report Report { get; set; }
    public EfficiencyModel MapFromEntity(Efficiency entity)
    {
        Id = entity.Id;
        Year = entity.Year;
        Inestment = entity.Inestment;
        Enery_Consumption = entity.EneryConsumption;
        Actual_Energy_Consumption = entity.ActualEnergyConsumption;
        Actual_Budget = entity.ActualBudget;
        Percentage = entity.Percentage;
        Current_Status = entity.CurrentStatus;
        ReportId = entity.ReportId;
        Report = entity.Report;
        return this;
    }
}
