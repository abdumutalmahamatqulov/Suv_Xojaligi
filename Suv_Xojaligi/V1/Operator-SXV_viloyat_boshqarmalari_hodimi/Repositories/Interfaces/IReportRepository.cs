using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.Common.Repositories.Interfaces;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories.Interfaces;

public interface IReportRepository : IBaseRepository<Report, ReportFilterModel>
{
    Task<Report> Get(Guid id);
    Task<Report> DeleteReport(Guid id);
    Task<Report> CreateReport(Report report);
    Task<Report> UpdateReport(Report report);
    Task<List<Report>> GetByFilter(ReportFilterModel model, string[] includes = null);
    Task<int> GetCount(ReportFilterModel model);
    Task<Report> UpdateReport(AddetionalDataModel model, Guid? fileId);

}
