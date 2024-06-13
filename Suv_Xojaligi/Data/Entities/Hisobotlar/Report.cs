using System.ComponentModel.DataAnnotations;
using Suv_Xojaligi.Data.Entities.Commons;

namespace Suv_Xojaligi.Data.Entities.Hisobotlar;

public class Report : Auditable
{
    public string NameObject { get; set; }

    public string PrivatePartner { get; set; }
    public DateTime RegistrationDate { get; set; }
    public decimal? InvestmentAmount { get; set; }
    public int? ProjectDuration { get; set; }
    public decimal? ProjectValue { get; set; }
    public string? Explain { get; set; }
    public Guid? FileId { get; set; }
    public FileMetadata FileDown { get; set; }
}
