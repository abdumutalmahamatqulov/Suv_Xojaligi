using Suv_Xojaligi.V1.FileMetadataFolder.Model;

namespace Suv_Xojaligi.V1.FileMetadataFolder.Services.Interfaces;

public interface IFileMetadataService
{
    ValueTask<FileMetadataModel> CreateAsync(CreateFileMetadataModel model);
    ValueTask<bool> Delete(Guid id);
    ValueTask<FileMetadataModel> Update(UpdateFileMetadataModel model);
    ValueTask<List<FileMetadataModel>> GetAll();
    ValueTask<FileMetadataModel> GetAsync(Guid id);
    Task<(Stream, string, string)> GetAsStream(Guid id);
}
