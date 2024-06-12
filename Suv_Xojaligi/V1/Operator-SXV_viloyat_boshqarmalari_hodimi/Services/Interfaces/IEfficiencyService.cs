using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Efficiencies;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Hisobotlar;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services.Interfaces;

public interface IEfficiencyService
{
    ValueTask<EfficiencyModel> GetEfficiency(Guid id);
    ValueTask<PagedResult<EfficiencyModel>> GetAllEfficiencies(EfficiencyFilterModel filter);
    ValueTask<bool> Delete(Guid id);
    ValueTask<EfficiencyModel> CreateEfficiency(EfficiencyCreateModel model,Guid reportId);
    ValueTask<EfficiencyModel> Update(EfficiencyUpdateModel model);

}
