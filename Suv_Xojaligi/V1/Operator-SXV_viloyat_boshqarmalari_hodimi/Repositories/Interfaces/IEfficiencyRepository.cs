using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.V1.Common.Repositories;
using Suv_Xojaligi.V1.Common.Repositories.Interfaces;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories.Interfaces;

public interface IEfficiencyRepository: IBaseRepository<Efficiency,EfficiencyFilterModel>
{
    Task<Efficiency> Get(Guid id);
    Task<Efficiency> DeleteEfficiency(Guid id);
    Task<Efficiency> CreateEfficiency(Efficiency efficiency);
    Task<Efficiency> UpdateEfficiency(Efficiency efficiency);
    Task<List<Efficiency>> GetByFilter(EfficiencyFilterModel model, string[] includes = null);
    Task<int> GetCount(EfficiencyFilterModel model);
}
