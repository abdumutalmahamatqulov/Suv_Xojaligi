using Microsoft.EntityFrameworkCore;
using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.Common.Repositories;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories.Interfaces;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories;

public class ReportRepository : BaseRepository<Report,ReportFilterModel>,IReportRepository
{
    private readonly AppDbContext _appDbcontext;

    public ReportRepository(AppDbContext appDbcontext)
    {
        _appDbcontext = appDbcontext;
    }
    public async Task<Report> Get(Guid id)
    {
        return await _appDbcontext.Reports.AsNoTracking().FirstOrDefaultAsync(x => id == x.Id);
    }
    public async Task<Report> DeleteReport(Guid id)
    {
        await _appDbcontext.Reports.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
        return await _appDbcontext.Reports.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Report> CreateReport(Report report)
    {
        report.CreatedAt = DateTime.UtcNow;
        report.RegistrationDate = DateTime.UtcNow;
        report.UpdatedAt = DateTime.UtcNow;
        await _appDbcontext.Reports.AddAsync(report);
        await _appDbcontext.SaveChangesAsync();
        return report;
    }

    public async Task<Report> UpdateReport(AddetionalDataModel model, Guid? fileId)
    {
        if(fileId.HasValue && fileId.Value != Guid.Empty)
        {
            await _appDbcontext.Reports.Where(x => x.Id == model.ReportId)
            .ExecuteUpdateAsync(
                x => x.SetProperty(a => a.Explain, a => model.Explain)
                .SetProperty(a => a.FileId, a => fileId.Value)
                .SetProperty(r => r.UpdatedAt, r => DateTime.UtcNow)
            );
        }
        else
        {
            await _appDbcontext.Reports.Where(x => x.Id == model.ReportId)
                .ExecuteUpdateAsync(x => x.SetProperty(a => a.Explain, a => model.Explain));
        }

        return await _appDbcontext.Reports.FirstOrDefaultAsync(x => x.Id == model.ReportId);
    }

    public async Task<Report> UpdateReport(Report report)
    {
        await _appDbcontext.Reports.Where(x => x.Id == report.Id)
            .ExecuteUpdateAsync(
            r => r.SetProperty(r => r.NameObject, r => report.NameObject)
            .SetProperty(r=>r.PrivatePartner,r=>report.PrivatePartner)
            .SetProperty(r=>r.RegistrationDate,r=>report.RegistrationDate)
            .SetProperty(r=>r.InvestmentAmount,r=>report.InvestmentAmount)
            .SetProperty(r=>r.ProjectDuration,r=>report.ProjectDuration)
            .SetProperty(r=>r.ProjectValue,r=>report.ProjectValue)
            .SetProperty(r=>r.Explain,r=>report.Explain)
            .SetProperty(r=>r.FileId,r=>report.FileId)
            .SetProperty(r=>r.UpdatedAt,r=>DateTime.UtcNow)
            );
        return await _appDbcontext.Reports.AsNoTracking().FirstOrDefaultAsync(r => r.Id == report.Id);
    }
    protected override IQueryable<Report> GetQuery(ReportFilterModel model)
    {
        var query = _appDbcontext.Reports.AsNoTracking();
        if(model.Id.HasValue && model.Id.Value != Guid.Empty)
        {
            query = query.Where(x=>x.Id ==model.Id.Value);
        }
        if (model.MinProjectValue.HasValue && model.MinProjectValue.Value > 0)
        {
            query = query.Where(x => x.ProjectValue >= model.MinProjectValue.Value);

        }
        if (model.MaxProjectValue.HasValue && model.MaxProjectValue > 0)
        {
            query = query.Where(x => x.ProjectValue <= model.MaxProjectValue.Value);
        }

        if (!string.IsNullOrEmpty(model.NameObject) && !string.IsNullOrWhiteSpace(model.NameObject))
        {
            query = query.Where(x => EF.Functions.Like(x.NameObject.ToLower(), $"%{model.NameObject.Trim().ToLower()}%"));
        }


        if (!string.IsNullOrEmpty(model.PrivatePartner) && !string.IsNullOrWhiteSpace(model.PrivatePartner))
        {
            query = query.Where(x => EF.Functions.Like(x.PrivatePartner.ToLower(), $"%{model.PrivatePartner.Trim().ToLower()}%"));
        }
        return query;
    }
}