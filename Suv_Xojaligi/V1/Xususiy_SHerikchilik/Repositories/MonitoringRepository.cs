using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities.Monitorings;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories
{
    public class MonitoringRepository : IMonitoringRepository
    {
        private readonly AppDbContext _appDbContext;

        public MonitoringRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Monitoring> AddMonitoringAsync(Monitoring monitoring)
        {
            var monitoryCreate = new Monitoring()
            {
                Project_Name = monitoring.Project_Name,
                Private_Partner = monitoring.Private_Partner,
                Time_of_period = monitoring.Time_of_period,
                Registry_Number_And_Date = DateTime.UtcNow,
                Submission_And_Acceptance_Date = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Project_Value = monitoring.Project_Value,
                Private_Partner_Investment = monitoring.Private_Partner_Investment,
                Operating_Costs = monitoring.Operating_Costs
            };
            _appDbContext.Monitorings.Add(monitoryCreate);
            await _appDbContext.SaveChangesAsync();
            return monitoryCreate;
        }

        public async Task<Monitoring> DeleteMonitoringAsync(Guid id)
        {
            var deleteMonitoring = await _appDbContext.Monitorings.FirstOrDefaultAsync(m => m.Id == id);
            _appDbContext?.Monitorings.Remove(deleteMonitoring);
            await _appDbContext.SaveChangesAsync();
            return deleteMonitoring;
        }

        public async Task<List<Monitoring>> GetByFilter(MonitoringFilterModel model, string[] includes = null)
        {
            var query = GetQuery(model);

            if(includes is not null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            model.EnsureOrSetDefaults();
            query = query.Skip(model.PageSize * (model.PageIndex - 1)).Take(model.PageSize);

            return query.ToList();
        }

        //DRY- don't repeat yourself

        private IQueryable<Monitoring> GetQuery(MonitoringFilterModel model)
        {
            var query = _appDbContext.Monitorings.AsNoTracking();

            if (model.Id.HasValue && model.Id.Value != Guid.Empty)
            {
                query = query.Where(x => x.Id == model.Id.Value);
            }
            if (model.MinProjectValue.HasValue && model.MinProjectValue.Value > 0)
            {
                query = query.Where(x => x.Project_Value >= model.MinProjectValue.Value);

            }
            if (model.MaxProjectValue.HasValue && model.MaxProjectValue > 0)
            {
                query = query.Where(x => x.Project_Value <= model.MaxProjectValue.Value);
            }

            if (!string.IsNullOrEmpty(model.Project_Name) && !string.IsNullOrWhiteSpace(model.Project_Name))
            {
                query = query.Where(x => x.Project_Name.ToLower() == $"%{model.Project_Name.Trim().ToLower()}%");
            }


            if (!string.IsNullOrEmpty(model.Private_Partner) && !string.IsNullOrWhiteSpace(model.Private_Partner))
            {
                query = query.Where(x => x.Private_Partner.ToLower() == $"%{model.Private_Partner.Trim().ToLower()}%");
            }

            return query;
        }

        public async Task<int> GetCount(MonitoringFilterModel model) 
        {
            var query = GetQuery(model);

            return await query.CountAsync();
        }

        public async Task<List<Monitoring>> GetAllMonitoringsAsync(bool includeMonitory)
        {
            return _appDbContext.Monitorings.ToList();
        }

        public async Task<Monitoring> GetMonitoringByIdAsync(Guid id)
        {
            return await _appDbContext.Monitorings.FirstOrDefaultAsync(m=>m.Id==id);
        }

        public async Task<Monitoring> UpdateMonitoringAsync(Monitoring monitoring)
        {
            _appDbContext.Monitorings.Where(m => m.Id == monitoring.Id)
                .ExecuteUpdate(
                p => p.SetProperty(m => m.Project_Name, m => monitoring.Project_Name)
                .SetProperty(m => m.Private_Partner, m => monitoring.Private_Partner)
                .SetProperty( m=> m.UpdatedAt, m => DateTime.UtcNow)
                .SetProperty(m => m.CreatedAt, m=>monitoring.CreatedAt)
                .SetProperty(m => m.Time_of_period,m=> monitoring.Time_of_period)
                .SetProperty(m => m.Registry_Number_And_Date, m => DateTime.UtcNow)
                .SetProperty(m => m.Submission_And_Acceptance_Date,m => DateTime.UtcNow)
                .SetProperty(m => m.Project_Value, m => monitoring.Project_Value)
                .SetProperty(m => m.Private_Partner_Investment, m =>monitoring.Private_Partner_Investment)
                .SetProperty(m => m.Operating_Costs, m => monitoring.Operating_Costs)
                );
            return await _appDbContext.Monitorings.AsNoTracking().FirstOrDefaultAsync(m => m.Id == monitoring.Id);

        }



    }
}
