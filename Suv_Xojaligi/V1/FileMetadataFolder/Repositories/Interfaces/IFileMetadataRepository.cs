using Suv_Xojaligi.Data.Entities;

namespace Suv_Xojaligi.V1.FileMetadataFolder.Repositories.Interfaces;

public interface IFileMetadataRepository
{
    ValueTask<FileMetadata> Create(FileMetadata entity);
    ValueTask<FileMetadata> Update(FileMetadata entity);
    ValueTask<FileMetadata> Delete(Guid id);
    ValueTask<FileMetadata> Get(Guid id);
    List<FileMetadata> GetAll();
}
