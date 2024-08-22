using Suv_Xojaligi.Data.Page;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Models;

public class NewFilterModel : PaginationParams
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}
