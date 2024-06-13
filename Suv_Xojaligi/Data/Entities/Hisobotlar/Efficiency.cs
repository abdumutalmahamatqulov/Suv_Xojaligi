using System.ComponentModel.DataAnnotations;
using Suv_Xojaligi.Data.Entities.Commons;

namespace Suv_Xojaligi.Data.Entities.Hisobotlar;
//Samaradorlik
public class Efficiency : Auditable
{
    public int? Year { get; set; }

    public decimal? Inestment { get; set; }

    public decimal? EneryConsumption { get; set; }

    public decimal? ActualEnergyConsumption { get; set; }


    public decimal? ActualBudget { get; set; }


    public decimal? Percentage { get; set; }


    public OrdersStatus CurrentStatus { get; set; }
    public EffeciencyType Type { get; set; }
    public Guid ReportId { get; set; }
    public Report Report { get; set; }

}
