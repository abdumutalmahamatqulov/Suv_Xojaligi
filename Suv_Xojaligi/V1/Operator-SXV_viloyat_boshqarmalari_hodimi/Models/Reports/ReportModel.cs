using Suv_Xojaligi.Data.Entities;
using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;

public class ReportModel
{
    public Guid Id { get; set; }
    public string NameObject { get; set; }

    public string PrivatePartner { get; set; }
    public DateTime RegistrationDate { get; set; }
    public decimal? InvestmentAmount { get; set; }
    public int? ProjectDuration { get; set; }
    public decimal? ProjectValue { get; set; }
    public string Explain { get; set; }
    public Guid? FileId { get; set; }
    public FileMetadataModel FileDownDocument { get; set; }
    public ReportModel MapFromEntity(Report entity)
    {
        Id = entity.Id;
        NameObject = entity.NameObject;
        PrivatePartner = entity.PrivatePartner;
        RegistrationDate = entity.RegistrationDate;
        InvestmentAmount = entity.InvestmentAmount;
        ProjectDuration = entity.ProjectDuration;
        ProjectValue = entity.ProjectValue;
        Explain = entity.Explain;
        FileId = entity.FileId;
        FileDownDocument = entity.FileDown is null ? null : new FileMetadataModel().MapFromEntity(entity.FileDown);
        return this;
    }
}
