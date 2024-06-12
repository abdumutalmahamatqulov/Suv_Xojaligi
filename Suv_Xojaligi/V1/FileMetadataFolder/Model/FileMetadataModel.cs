using Suv_Xojaligi.Data.Entities;

namespace Suv_Xojaligi.V1.FileMetadataFolder.Model;

public class FileMetadataModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public string Body { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public FileMetadataModel MapFromEntity(FileMetadata entity)
    {

        Id = entity.Id;
        Name = entity.Name;
        Extension = entity.Extension;
        Body = entity.Body;
        CreatedDate = entity.CreatedDate;
        ModifiedDate = entity.ModifiedDate;
        return this;

    }
}
