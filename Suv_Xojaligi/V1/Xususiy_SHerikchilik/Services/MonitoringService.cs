﻿using Microsoft.EntityFrameworkCore;
using Suv_Xojaligi.Data.Entities.Monitorings;
using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services;

public class MonitoringService : IMonitoringService
{
    private readonly IMonitoringRepository _monitoringRepository;
    private readonly ILogger<MonitoringService> _logger;

    public MonitoringService(IMonitoringRepository monitoringRepository, ILogger<MonitoringService> logger)
    {
        _monitoringRepository = monitoringRepository;
        _logger = logger;
    }
    
    public async ValueTask<MonitoringModel> Get(Guid id)
    {
        return new MonitoringModel().MapFromEntity(await _monitoringRepository.GetMonitoringByIdAsync(id));
    }
    public async ValueTask<PagedResult<MonitoringModel>> GetByFilter(MonitoringFilterModel filter)
    {
        var count =  await _monitoringRepository.GetCount(filter);
        var list = await _monitoringRepository.GetByFilter(filter);

        return PagedResult.Create(list.Select(x=>new MonitoringModel().MapFromEntityies(x)).ToList(),filter.PageIndex,filter.PageSize,count);
    }

    public async ValueTask<MonitoringModel> CreateMonitoring(MonitoringCreateModel model)
    {
        try
        {
            var newMonitoring = model.ToEntity();

            newMonitoring.Time_of_period = model.Time_of_period.HasValue ? ((int)model.Time_of_period.Value.TotalHours) : null;
            await _monitoringRepository.AddMonitoringAsync(newMonitoring);
            return new MonitoringModel().MapFromEntity(newMonitoring);
        }
        catch (Suv_Xojaligi_ApiException ex)
        {
            throw new Suv_Xojaligi_ApiException(400, $"monitoring_is_null_{ex.Message}");
        }
    }
    public async ValueTask<MonitoringModel> Update(MonitoringUpdateModel model)
    {
        try
        {
            var newMonitoring = model.ToEntity();
            newMonitoring.Time_of_period = model.Time_of_period.HasValue ? ((int)model.Time_of_period.Value.TotalHours) : null;

            await _monitoringRepository.UpdateMonitoringAsync(newMonitoring);
            return new MonitoringModel().MapFromEntity(newMonitoring);
        }
        catch (Suv_Xojaligi_ApiException ex)
        {
            throw new Suv_Xojaligi_ApiException(400, $"monitoring_is_null_{ex.Message}");
        }
    }
    public async ValueTask<bool> Delete(Guid id)
    {
        await _monitoringRepository.DeleteMonitoringAsync(id);
        return true;
    }
        
}
