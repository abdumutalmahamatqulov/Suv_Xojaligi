using Suv_Xojaligi.Data.Page;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.FileMetadataFolder.Services.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Models;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Repositories.Interfaces;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Services.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Services;

public class NewService : INewService
{
    private readonly INewRepository _newRepository;
    private readonly IFileMetadataService _fileMetadataService;
    private readonly ILogger<NewService> _logger;
    public NewService(INewRepository newRepository, IFileMetadataService fileMetadataService, ILogger<NewService> logger)
    {
        _newRepository = newRepository;
        _fileMetadataService = fileMetadataService;
        _logger = logger;
    }
    public async ValueTask<NewModel> Get(Guid id)
    {
        return new NewModel().MapFromEntity(await _newRepository.GetByIdAsync(id));
    }
    public async ValueTask<PagedResult<NewModel>> GetAll(NewFilterModel filter)
    {
        var count = await _newRepository.GetCount(filter);
        var list = await _newRepository.GetByFilter(filter);
        return PagedResult.Create(list.Select(a=>new NewModel().MapFromEntity(a)).ToList(),filter.PageIndex,filter.PageSize,count);
    }
    public async ValueTask<bool> DeleteNew(Guid id)
    {
        await _newRepository.Delete(id);
        return true;
    }
    public async ValueTask<NewModel > CreateNew(NewCreateModel model)
    {
        try
        {
            var newCreate = model.ToEntity();
            var imageUrl = await _fileMetadataService.CreateAsync(model.ImageUrlDown);
            newCreate.ImageId = imageUrl.Id;
            await _newRepository.AddNew(newCreate);
            return new NewModel().MapFromEntity(newCreate);
        }
        catch
        {
            throw new Suv_Xojaligi_ApiException(400, "new_can_not_be_create");
        }
    }
    public async ValueTask<NewModel> UpdateNew(NewUpdateModel model)
    {
        try
        {
            var newCreate = model.ToEntity();
            var imageUrl = await _fileMetadataService.Update(model.ImageUrlDown);
            newCreate.ImageId = imageUrl.Id;
            await _newRepository.UpdateNew(newCreate);
            return new NewModel().MapFromEntity(newCreate);
        }
        catch
        {
            throw new Suv_Xojaligi_ApiException(400, "new_can_not_be_update");
        }
    }
}
