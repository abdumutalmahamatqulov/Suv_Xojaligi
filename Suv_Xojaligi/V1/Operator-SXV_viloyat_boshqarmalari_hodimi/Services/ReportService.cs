using Suv_Xojaligi.Data.Entities;
using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.FileMetadataFolder.Repositories.Interfaces;
using Suv_Xojaligi.V1.FileMetadataFolder.Services.Interfaces;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories.Interfaces;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services.Interfaces;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;
    private readonly ILogger<ReportService> _logger;
    private readonly IFileMetadataService _fileMetadataService;
    private readonly IEfficiencyService _efficiencyService;
    public ReportService(IReportRepository reportRepository, IFileMetadataService fileMetadataService, ILogger<ReportService> logger, IEfficiencyService efficiencyService)
    {
        _reportRepository = reportRepository;
        _fileMetadataService = fileMetadataService;
        _logger = logger;
        _efficiencyService = efficiencyService;
    }
    public async ValueTask<ReportModel> GetReport(Guid id)
    {
        return new ReportModel().MapFromEntity(await _reportRepository.Get(id));
    }
    public async ValueTask<PagedResult<ReportModel>> GetAllReports(ReportFilterModel filter)
    {
        var count = await _reportRepository.GetCount(filter);
        var list = await _reportRepository.GetByFilter(filter);
        return PagedResult.Create(list.Select(r => new ReportModel().MapFromEntity(r)).ToList(),filter.PageIndex,filter.PageSize,count);
    }
    public async ValueTask<bool> Delete(Guid id)
    {
        await _reportRepository.DeleteReport(id);
        return true;
    }
    public async ValueTask<ReportModel> CreateReport(ReportCreateModel model)
    {
        try
        {
            var newReport = model.ToEntity();
            await _reportRepository.CreateReport(newReport);
            var efficiencyPlanned = await _efficiencyService.CreateEfficiency(model.PlannedEfficiencie,newReport.Id);
            var efficiencyReal = await _efficiencyService.CreateEfficiency(model.RealEffeciency,newReport.Id);
            return new ReportModel().MapFromEntity(newReport);

        }
        catch
        {
            throw new Suv_Xojaligi_ApiException(400, "report_can_not_be_create");
        }
    }

    public async ValueTask<ReportModel> UpdateReport(ReportUpdateModel model)
    {
        try
        {
            var newReport = model.ToEntity();
            model.PlannedEfficiencie.ReportId = newReport.Id;
            var efficiencyUpdate = await _efficiencyService.Update(model.PlannedEfficiencie);
            newReport.Id = efficiencyUpdate.Id;
            await _reportRepository.UpdateReport(newReport);
            return new ReportModel().MapFromEntity(newReport);

        }
        catch
        {
            throw new Suv_Xojaligi_ApiException(400, "report_can_not_be_update");
        }
    }
    public async ValueTask<ReportModel> Edit(AddetionalDataModel model)
    {
        try
        {
            var newReport = new Report();

            newReport.Id = Guid.NewGuid();
          
            newReport.Explain = model.Explain;
            var documentCreate = await _fileMetadataService.Update(model.FileUpdate);
            newReport.FileId = documentCreate.Id;
            var efficiencyPlanned = await _efficiencyService.CreateEfficiency(model.PlannedEfficiencie, newReport.Id);
            var efficiencyReal = await _efficiencyService.CreateEfficiency(model.RealEffeciency, newReport.Id);
            await _reportRepository.UpdateReport(newReport);
            return new ReportModel().MapFromEntity(newReport);

        }
        catch
        {
            throw new Suv_Xojaligi_ApiException(400, "report_can_not_be_create");
        }
    }
}
