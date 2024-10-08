﻿using Suv_Xojaligi.Data.Entities.Monitorings;
using Suv_Xojaligi.V1.Common.Repositories.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories.Interfaces
{
    public interface IMonitoringRepository:IBaseRepository<Monitoring,MonitoringFilterModel>
    {
        Task<Monitoring> GetMonitoringByIdAsync(Guid id);
        Task<Monitoring> AddMonitoringAsync(Monitoring monitoring);
        Task<int> GetCount(MonitoringFilterModel model);
        Task<List<Monitoring>> GetByFilter(MonitoringFilterModel model, string[] includes = null);
        Task<Monitoring> UpdateMonitoringAsync(Monitoring monitoring);
        Task<Monitoring> DeleteMonitoringAsync(Guid id);
    }
}
