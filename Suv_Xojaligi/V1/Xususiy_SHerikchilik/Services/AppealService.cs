using Suv_Xojaligi.Data.Entities;
using Suv_Xojaligi.Data.Entities.Appeal_And_Applications;
using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.FileMetadataFolder.Services.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Appeals;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services;

public class AppealService : IAppealService
{
    private readonly IAppealRepository _appealRepository;
    private readonly ILogger<AppealService> _logger;
    private readonly IFileMetadataService _fileMetadataService;
    public AppealService(IAppealRepository appealRepository, ILogger<AppealService> logger, IFileMetadataService fileMetadataService)
    {
        _appealRepository = appealRepository;
        _logger = logger;
        _fileMetadataService = fileMetadataService;
    }
    public async ValueTask<AppealModel> Get(Guid id)
    {
        return new AppealModel().MapFromEntity(await _appealRepository.GetAppealByIdAsync(id));
    }
    public async ValueTask<PagedResult<AppealModel>> GetAll(AppealFilterModel filter)
    {
        var count = await _appealRepository.GetCount(filter);
        var list = await _appealRepository.GetByFilter(filter);
        return PagedResult.Create(list.Select(a => new AppealModel().MapFromEntity(a)).ToList(), filter.PageIndex, filter.PageSize, count);
    }
    public async ValueTask<bool> DeleteAppeal(Guid id)
    {
        await _appealRepository.DeleteAppeal(id);
        return true;
    }
    public async ValueTask<AppealModel> CreateAppeal(AppealCreateModel model)
    {
        try
        {
            var newAppeal = model.ToEntity();
            var documentCrate = await _fileMetadataService.CreateAsync(model.document_down);
            newAppeal.FileId = documentCrate.Id;
            await _appealRepository.CreateAppeal(newAppeal);
            return new AppealModel().MapFromEntity(newAppeal);
        }
        catch
        {
            throw new Suv_Xojaligi_ApiException(400, "appeal_can_not_be_create");
        }
    }
    public async ValueTask<AppealModel> Update(AppealUpdateModel model)
    {
        try
        {
            var newAppeal = model.ToEntity();
            var document = await _fileMetadataService.Update(model.File_document);
            newAppeal.FileId = document.Id;
            await _appealRepository.UpdateAppeal(newAppeal);
            return new AppealModel().MapFromEntity(newAppeal);
        }
        catch
        {
            throw new Suv_Xojaligi_ApiException(400, "appeal_can_not_be_update");

        }
    }
}
