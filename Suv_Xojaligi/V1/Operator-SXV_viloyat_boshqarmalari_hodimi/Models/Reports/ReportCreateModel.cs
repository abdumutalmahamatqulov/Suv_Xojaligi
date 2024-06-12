using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;

public class ReportCreateModel
{
    public string NameObject { get; set; }

    public string PrivatePartner { get; set; }
    public DateTime RegistrationDate { get; set; }
    public decimal? InvestmentAmount { get; set; }
    public int? ProjectDuration { get; set; }
    public decimal? ProjectValue { get; set; }
    public EfficiencyCreateModel PlannedEfficiencie { get; set; }
    public EfficiencyCreateModel RealEffeciency { get; set; }

    public Report ToEntity()
    {

        var newReport = new Report();

        newReport.Id = Guid.NewGuid();
        newReport.PrivatePartner = this.PrivatePartner;
        newReport.NameObject = this.NameObject;
        newReport.RegistrationDate = this.RegistrationDate;
        newReport.InvestmentAmount = this.InvestmentAmount;
        newReport.ProjectDuration = this.ProjectDuration;
        newReport.ProjectValue = this.ProjectValue;
        return newReport;
    }
}
