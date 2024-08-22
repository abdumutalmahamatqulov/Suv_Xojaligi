using Suv_Xojaligi.Data.Entities.News;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Models;

public class NewUpdateModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public UpdateFileMetadataModel ImageUrlDown { get; set; }
    public DateOnly DateTime { get; set; }
    public New ToEntity()
    {
        var newUpdate = new New();
        newUpdate.Id = this.Id;
        newUpdate.Name = this.Name;
        newUpdate.Description = this.Description;
        newUpdate.Title = this.Title;
        newUpdate.DateTime = this.DateTime;
        return newUpdate;
    }
}
