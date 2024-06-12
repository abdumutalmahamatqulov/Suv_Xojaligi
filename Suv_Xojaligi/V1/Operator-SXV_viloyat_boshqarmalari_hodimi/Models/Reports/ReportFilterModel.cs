using Suv_Xojaligi.Data.Page;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;

public class ReportFilterModel : PaginationParams
{
    public Guid? Id { get; set; }
    public string? NameObject { get; set; }
    public string? PrivatePartner { get; set; }
    public decimal? MinProjectValue { get; set; }
    public decimal? MaxProjectValue { get; set; }
}
