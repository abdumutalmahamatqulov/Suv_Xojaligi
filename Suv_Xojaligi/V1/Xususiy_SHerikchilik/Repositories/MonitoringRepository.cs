using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities.Monitorings;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.Common.Repositories;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories
{
    public class MonitoringRepository :BaseRepository<Monitoring,MonitoringFilterModel> ,IMonitoringRepository
    {
        private readonly AppDbContext _appDbContext;

        public MonitoringRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Monitoring> AddMonitoringAsync(Monitoring monitoring)
        {
            try
            {
                monitoring.UpdatedAt = DateTime.UtcNow;
                monitoring.CreatedAt = DateTime.UtcNow;
                _appDbContext.Monitorings.Add(monitoring);
                await _appDbContext.SaveChangesAsync();
            return monitoring;
            }
            catch (Exception ex)
            {
                throw new Suv_Xojaligi_ApiException(400, "can_not_be_Create");
            }
        }

        public async Task<Monitoring> DeleteMonitoringAsync(Guid id)
        {
            await _appDbContext.Monitorings.Where(m => m.Id == id)
                .ExecuteDeleteAsync();
            /*            var deleteMonitoring = await _appDbContext.Monitorings.FirstOrDefaultAsync(m => m.Id == id);
                        _appDbContext?.Monitorings.Remove(deleteMonitoring);
                        await _appDbContext.SaveChangesAsync();
                        return deleteMonitoring;*/
            return await _appDbContext.Monitorings.FirstOrDefaultAsync(x => x.Id == id);
        }


        //DRY- don't repeat yourself

        protected override IQueryable<Monitoring> GetQuery(MonitoringFilterModel model)
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
                query = query.Where(x =>EF.Functions.Like( x.Project_Name.ToLower() , $"%{model.Project_Name.Trim().ToLower()}%"));
            }


            if (!string.IsNullOrEmpty(model.Private_Partner) && !string.IsNullOrWhiteSpace(model.Private_Partner))
            {
                query = query.Where(x =>EF.Functions.Like( x.Private_Partner.ToLower() , $"%{model.Private_Partner.Trim().ToLower()}%"));
            }

            return query;
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
                .SetProperty(m => m.CreatedAt, m=>monitoring.CreatedAt)
                .SetProperty(m => m.Time_of_period,m=> monitoring.Time_of_period)
                .SetProperty(m => m.Registry_Number_And_Date, m => DateTime.UtcNow)
                .SetProperty(m => m.Submission_And_Acceptance_Date,m => DateTime.UtcNow)
                .SetProperty(m => m.Project_Value, m => monitoring.Project_Value)
                .SetProperty(m => m.Private_Partner_Investment, m =>monitoring.Private_Partner_Investment)
                .SetProperty(m => m.Operating_Costs, m => monitoring.Operating_Costs)
                .SetProperty(m => m.UpdatedAt,m => DateTime.UtcNow)
                );
            return await _appDbContext.Monitorings.AsNoTracking().FirstOrDefaultAsync(m => m.Id == monitoring.Id);

        }



    }
}
