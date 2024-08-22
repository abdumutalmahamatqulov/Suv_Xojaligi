using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Models;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Services.Interfaces
{
    public interface INewService
    {
        ValueTask<NewModel> Get(Guid id);
        ValueTask<PagedResult<NewModel>> GetAll(NewFilterModel filter);
        ValueTask<bool> DeleteNew(Guid id);
        ValueTask<NewModel> CreateNew(NewCreateModel model);
        ValueTask<NewModel> UpdateNew(NewUpdateModel model);
    }
}
