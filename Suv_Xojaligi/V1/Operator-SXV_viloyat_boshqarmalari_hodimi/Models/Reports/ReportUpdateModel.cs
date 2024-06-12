using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Efficiencies;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;

public class ReportUpdateModel
{
    public Guid Id { get; set; }
    public string NameObject { get; set; }
    public string PrivatePartner { get; set; }
    public DateTime RegistrationDate { get; set; }
    public decimal? InvestmentAmount { get; set; }
    public int? ProjectDuration { get; set; }
    public decimal? ProjectValue { get; set; }
    public Guid EfficiencyId { get; set; }
    public EfficiencyUpdateModel PlannedEfficiencie { get; set; }
    public EfficiencyUpdateModel RealEffeciency { get; set; }
    public Report ToEntity()
    {
        var newReport = new Report();
        newReport.Id = this.Id;
        newReport.PrivatePartner = this.PrivatePartner;
        newReport.NameObject = this.NameObject;
        newReport.RegistrationDate = this.RegistrationDate;
        newReport.InvestmentAmount = this.InvestmentAmount;
        newReport.ProjectDuration = this.ProjectDuration;
        newReport.ProjectValue = this.ProjectValue;
        return newReport;
    }
}