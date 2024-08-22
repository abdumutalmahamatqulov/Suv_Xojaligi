using Suv_Xojaligi.Data.Entities.News;
using Suv_Xojaligi.V1.Common.Repositories.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Models;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Repositories.Interfaces;

public interface INewRepository:IBaseRepository<New,NewFilterModel>
{
    Task<New> AddNew(New entity);
    Task<New> Delete(Guid id);
    Task<New> UpdateNew(New entity);
    Task<New> GetByIdAsync(Guid id);
    Task<List<New>> GetByFilter(NewFilterModel model, string[] include = null);
    Task<int> GetCount(NewFilterModel model);
}
