using Suv_Xojaligi.V1.FileMetadataFolder.Model;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Efficiencies;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;

public class AddetionalDataModel
{
    public Guid ReportId { get; set; }
    public string Explain { get; set; }
    public EfficiencyUpdateModel PlannedEfficiencie { get; set; }
    public EfficiencyUpdateModel RealEffeciency { get; set; }
    public UpdateFileMetadataModel FileUpdate { get; set; }
}
