using Suv_Xojaligi.Data.Entities.Hisobotlar;
using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.FileMetadataFolder.Services.Interfaces;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Efficiencies;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Hisobotlar;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories.Interfaces;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services.Interfaces;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services;

public class EfficiencyService : IEfficiencyService
{
    private readonly IEfficiencyRepository _repository;
    private readonly ILogger<EfficiencyService> _logger;
    public EfficiencyService(IEfficiencyRepository repository, ILogger<EfficiencyService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async ValueTask<EfficiencyModel> GetEfficiency(Guid id)
    {
        return new EfficiencyModel().MapFromEntity(await _repository.Get(id));
    }

    public async ValueTask<PagedResult<EfficiencyModel>> GetAllEfficiencies(EfficiencyFilterModel filter)
    {
        var count = await _repository.GetCount(filter);
        var list = await _repository.GetByFilter(filter);
        return PagedResult.Create(list.Select(e=>new EfficiencyModel().MapFromEntity(e)).ToList(), filter.PageIndex,filter.PageSize, count);
    }
    public async ValueTask<bool> Delete(Guid id)
    {
        await _repository.DeleteEfficiency(id);
        return true;
    }

    public async ValueTask<EfficiencyModel> CreateEfficiency(EfficiencyCreateModel model,Guid reportId)
    {
        try
        {
            var newEfficiency = model.ToEntity();

            newEfficiency.ReportId = reportId;
            await _repository.CreateEfficiency(newEfficiency);
            return new EfficiencyModel().MapFromEntity(newEfficiency);
        }
        catch
        {
            throw new Suv_Xojaligi_ApiException(400, "efficiency_can_not_be_create");
        }
    }
    public async ValueTask<EfficiencyModel> Update(EfficiencyUpdateModel model,Guid id)
    {
        try
        {
            var newEfficiency = model.ToEntity();
            await _repository.UpdateEfficiency(newEfficiency);
            return new EfficiencyModel().MapFromEntity(newEfficiency);
        }
        catch
        {
            throw new Suv_Xojaligi_ApiException(400, "efficiency_can_not_be_upodate");
        }
    }
}
