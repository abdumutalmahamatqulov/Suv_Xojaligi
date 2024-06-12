using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities.Appeal_And_Applications;
using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Common.Repositories;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Appeals;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories;

public class AppealRepository: BaseRepository<Appeal, AppealFilterModel>, IAppealRepository
{
    private readonly AppDbContext _appDbContext;

    public AppealRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Appeal> CreateAppeal(Appeal appeal)
    {
        appeal.CreatedAt = DateTime.UtcNow;
        appeal.UpdatedAt = DateTime.UtcNow;
        appeal.FileId = appeal.FileId;
        _appDbContext.Appeals.Add(appeal);
        await _appDbContext.SaveChangesAsync();
        return appeal;
    }
    public async Task<Appeal> DeleteAppeal(Guid id)
    {

        await _appDbContext.Appeals.Where(a => a.Id == id)
            .ExecuteDeleteAsync();
        return await _appDbContext.Appeals
            .Include(x => x.DocumentDown)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Appeal> UpdateAppeal(Appeal appeal)
    {
        _appDbContext.Appeals.Where(a => a.Id == appeal.Id)
            .ExecuteUpdate(
            a=>a.SetProperty(a => a.DocumentDown.Id, a => appeal.DocumentDown.Id)
            .SetProperty(a => a.Name_Organization, a => appeal.Name_Organization)
            .SetProperty(a => a.Appeal_Number, a => appeal.Appeal_Number)
            .SetProperty(a => a.Take_Location, a => appeal.STIR)
            .SetProperty(a => a.Title, a => appeal.Title)
            .SetProperty(a => a.Email_Organization, a => appeal.Email_Organization)
            .SetProperty(a => a.Bank_Account_Number, a => appeal.Bank_Account_Number)
            .SetProperty(a => a.UpdatedAt, a => DateTime.UtcNow)
            .SetProperty(a => a.Status,a => appeal.Status)
            );
        return await _appDbContext.Appeals.AsNoTracking().FirstOrDefaultAsync(a => a.Id == appeal.Id);
    }

    public async Task<Appeal> GetAppealByIdAsync(Guid id)
    {
        return await _appDbContext.Appeals.AsNoTracking().Include(x => x.DocumentDown).FirstOrDefaultAsync(a => a.Id == id);
    }

    protected override IQueryable<Appeal> GetQuery(AppealFilterModel model)
    {
        var query = _appDbContext.Appeals.AsNoTracking();
        if(model.Id.HasValue && model.Id.Value != Guid.Empty)
        {
            query = query.Where(x=>x.Id == model.Id);
        }
        if(!string.IsNullOrEmpty(model.Name_Organization)&& !string.IsNullOrWhiteSpace(model.Name_Organization))
        {
            query = query.Where(x => x.Name_Organization.ToLower() == $"%{model.Name_Organization.Trim().ToLower()}%");
        }
        return query;
    }
    
}
/*    protected SetPropertyCalls<Appeal> GetUpdateExpression(SetPropertyCalls<Appeal> set, Appeal entity)
    {
        return set.SetProperty(a => a.DocumentDown.Id, a => entity.DocumentDown.Id)
            .SetProperty(a => a.Name_Organization, a => entity.Name_Organization)
            .SetProperty(a => a.Appeal_Number, a => entity.Appeal_Number)
            .SetProperty(a => a.Take_Location, a => entity.STIR)
            .SetProperty(a => a.Title, a => entity.Title)
            .SetProperty(a => a.Email_Organization, a => entity.Email_Organization)
            .SetProperty(a => a.Bank_Account_Number, a => entity.Bank_Account_Number)
            .SetProperty(a => a.UpdatedAt, a => DateTime.UtcNow);
    }*/