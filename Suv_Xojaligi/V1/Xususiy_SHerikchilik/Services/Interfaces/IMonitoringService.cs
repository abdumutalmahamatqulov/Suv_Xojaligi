using Suv_Xojaligi.Data.Contexts.Configurations;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services.Interfaces
{
    public interface IMonitoringService
    {
        ValueTask<MonitoringModel> Get(Guid id);
        ValueTask<PagedResult<MonitoringModel>> GetByFilter(MonitoringFilterModel filter);
        ValueTask<MonitoringModel> CreateMonitoring(MonitoringCreateModel model);
        ValueTask<MonitoringModel> Update(MonitoringUpdateModel model);
        ValueTask<bool> Delete(Guid id);
    }
}
