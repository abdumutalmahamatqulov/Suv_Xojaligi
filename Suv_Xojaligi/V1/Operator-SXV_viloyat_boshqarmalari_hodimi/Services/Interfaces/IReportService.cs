using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services.Interfaces;

public interface IReportService
{
    ValueTask<ReportModel> CreateReport(ReportCreateModel model);
    ValueTask<ReportModel> UpdateReport(ReportUpdateModel model);
    ValueTask<bool> Delete(Guid id);
    ValueTask<ReportModel> GetReport(Guid id);
    ValueTask<PagedResult<ReportModel>> GetAllReports(ReportFilterModel filter);
    ValueTask<ReportModel> Edit(AddetionalDataModel model);
}
