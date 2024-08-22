using Suv_Xojaligi.Data.Entities.News;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;
using System.ComponentModel.DataAnnotations;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Models;

public class NewCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public CreateFileMetadataModel ImageUrlDown { get; set; }
    public DateOnly DateTime { get; set; }
    public New ToEntity()
    {
        var newCreate = new New();
        newCreate.Name = this.Name;
        newCreate.Description = this.Description;
        newCreate.Title = this.Title;
        newCreate.DateTime = this.DateTime;
        return newCreate;
    }
}
