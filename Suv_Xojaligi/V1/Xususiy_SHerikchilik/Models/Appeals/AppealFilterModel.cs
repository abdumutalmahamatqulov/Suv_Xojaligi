 using Suv_Xojaligi.Data.Page;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Appeals;

public class AppealFilterModel : PaginationParams
{
    public Guid? Id { get; set; }
    public string? Name_Organization { get; set; }
}
