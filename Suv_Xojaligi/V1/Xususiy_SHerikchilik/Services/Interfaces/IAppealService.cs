using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Appeals;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services.Interfaces
{
    public interface IAppealService
    {
        ValueTask<AppealModel> Get(Guid id);
        ValueTask<PagedResult<AppealModel>> GetAll(AppealFilterModel filter);
        ValueTask<bool> DeleteAppeal(Guid id);
        ValueTask<AppealModel> CreateAppeal(AppealCreateModel model);
        ValueTask<AppealModel> Update(AppealUpdateModel model);
    }
}
