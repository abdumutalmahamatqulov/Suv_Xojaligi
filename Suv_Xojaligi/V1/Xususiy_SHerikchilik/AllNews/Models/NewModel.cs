using System.ComponentModel.DataAnnotations;
using Suv_Xojaligi.Data.Entities.News;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Models;

public class NewModel
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Title { get; set; }
    public DateOnly Date { get; set; }
    public Guid? ImageId { get; set; }
    public FileMetadataModel ImageUrlDown { get; set; }
    [Required]
    public DateOnly DateTime { get; set; }
    public NewModel MapFromEntity(New entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Description = entity.Description;
        Title = entity.Title;
        Date = DateOnly.MaxValue;
        ImageId = entity.ImageId;
        ImageUrlDown = entity.ImageUrl is null ? null : new FileMetadataModel().MapFromEntity(entity.ImageUrl);
        return this;
    }
}
