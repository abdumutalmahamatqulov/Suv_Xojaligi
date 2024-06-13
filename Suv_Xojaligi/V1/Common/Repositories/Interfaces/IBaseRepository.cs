using Suv_Xojaligi.Data.Entities.Commons;
using Suv_Xojaligi.Data.Page;

namespace Suv_Xojaligi.V1.Common.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity, TFilter> where TEntity : Auditable where TFilter : PaginationParams
    {
        Task<List<TEntity>> GetByFilter(TFilter model, string[] includes = null);
    }
}
