using Suv_Xojaligi.Data.Entities.Appeal_And_Applications;
using Suv_Xojaligi.V1.Common.Repositories.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Appeals;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories.Interfaces
{
    public interface IAppealRepository : IBaseRepository<Appeal, AppealFilterModel>
    {
        Task<Appeal> CreateAppeal(Appeal appeal);
        Task<Appeal> DeleteAppeal(Guid id);
        Task<Appeal> UpdateAppeal(Appeal appeal);
        Task<Appeal> GetAppealByIdAsync(Guid id);
        Task<List<Appeal>> GetByFilter(AppealFilterModel model, string[] includes = null);
        Task<int> GetCount(AppealFilterModel model);
    }
}
