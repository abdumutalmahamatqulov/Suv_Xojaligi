using Microsoft.EntityFrameworkCore;
using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities.News;
using Suv_Xojaligi.V1.Common.Repositories;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Models;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Repositories.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Repositories;

public class NewRepository : BaseRepository<New, NewFilterModel>, INewRepository
{
    private readonly AppDbContext _appDbContext;

    public NewRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<New> AddNew(New entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.ImageId = entity.ImageId;
        _appDbContext.News.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
    protected override IQueryable<New> GetQuery(NewFilterModel model)
    {
        var query = _appDbContext.News.AsNoTracking();
        if(model.Id.HasValue && model.Id.Value != Guid.Empty)
        {
            query = query.Where(x=>x.Id ==model.Id);
        }
        if(!string.IsNullOrEmpty(model.Name)&& !string.IsNullOrWhiteSpace(model.Name))
        {
            query = query.Where(x=> EF.Functions.Like(x.Name.ToLower(),$"%{model.Name.Trim().ToLower()}%"));
        }
        return query;
    }
    public async Task<New> Delete(Guid id)
    {
        await _appDbContext.News.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
        return await _appDbContext.News
            .Include(x => x.ImageUrl)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<New> UpdateNew(New entity)
    {
        await _appDbContext.News.Where(n => n.Id == entity.Id)
            .ExecuteUpdateAsync(
            n => n.SetProperty(n => n.ImageUrl.Id, n => entity.ImageUrl.Id)
            .SetProperty(n=>n.Name,n=>entity.Name)
            .SetProperty(n=>n.Description,n=>entity.Description)
            .SetProperty(n=>n.Title,n=>entity.Title)
            .SetProperty(n=>n.UpdatedAt,n=>DateTime.UtcNow)
            .SetProperty(n=>n.DateTime,n=>DateOnly.MaxValue)
            );
        return await _appDbContext.News.AsNoTracking().FirstOrDefaultAsync(n => n.Id == entity.Id);
    }
    public async Task<New> GetByIdAsync(Guid id)
    {
        return await _appDbContext.News.AsNoTracking().Include(x => x.ImageUrl).FirstOrDefaultAsync(n => n.Id == id);
    }
}
