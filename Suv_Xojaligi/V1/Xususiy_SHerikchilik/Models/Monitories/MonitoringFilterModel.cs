using Suv_Xojaligi.Data.Page;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories;

public class MonitoringFilterModel : PaginationParams
{
    public Guid? Id { get; set; }

    public string? Project_Name { get; set; }
    public string? Private_Partner { get; set; }
    public decimal? MinProjectValue { get; set; }
    public decimal? MaxProjectValue { get; set; }
}
