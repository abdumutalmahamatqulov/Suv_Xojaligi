using Microsoft.EntityFrameworkCore;
using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.FileMetadataFolder.Repositories.Interfaces;

namespace Suv_Xojaligi.V1.FileMetadataFolder.Repositories;

public class FileMetadataRepository: IFileMetadataRepository
{
    private readonly AppDbContext _context;

    public FileMetadataRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<FileMetadata> Create(FileMetadata entity)
    {
        var fileMetadataCreate = new FileMetadata();
        fileMetadataCreate.Id = entity.Id;
        fileMetadataCreate.Name = entity.Name;
        fileMetadataCreate.Extension = entity.Extension;
        fileMetadataCreate.Body = entity.Body;
        fileMetadataCreate.CreatedDate = DateTime.Now;
        fileMetadataCreate.ModifiedDate = DateTime.Now;

        await _context.FileMetadatas.AddAsync(fileMetadataCreate);
        await _context.SaveChangesAsync();

        return fileMetadataCreate;
    }
    public async ValueTask<FileMetadata> Update(FileMetadata entity)
    {
        var fileMetadata = await _context.FileMetadatas.FirstOrDefaultAsync(f => f.Id == entity.Id);
        if (fileMetadata == null)
        {
            throw new Suv_Xojaligi_ApiException(204, "file_is_null");
        }
        fileMetadata.Name = entity.Name;
        fileMetadata.Extension = entity.Extension;
        fileMetadata.Body = entity.Body;
        fileMetadata.CreatedDate = entity.CreatedDate;
        _context.FileMetadatas.Update(fileMetadata);
        await _context.SaveChangesAsync();
        return fileMetadata;
    }
    public async ValueTask<FileMetadata> Delete(Guid id)
    {
        var deleteFile = await _context.FileMetadatas.FirstOrDefaultAsync(f => f.Id == id);
        if (deleteFile is not null)
        {
            _context.FileMetadatas.Remove(deleteFile);
            await _context.SaveChangesAsync();
            return deleteFile;
        }
        throw new Suv_Xojaligi_ApiException(204, "this_file_is_null");

    }
    public async ValueTask<FileMetadata> Get(Guid id)
    {
        return await _context.FileMetadatas.FirstOrDefaultAsync(f => f.Id == id);
    }
    public List<FileMetadata> GetAll()
    {
        return _context.FileMetadatas.ToList();
    }
}


