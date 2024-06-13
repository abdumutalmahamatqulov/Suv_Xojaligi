using Microsoft.Extensions.FileProviders;
using Suv_Xojaligi.Data.Entities.Appeal_And_Applications;
using Suv_Xojaligi.Data.Entities.Commons;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Appeals;

public class AppealUpdateModel
{
    public Guid Id { get; set; }
    public Guid FileMetadataId { get; set; }
    public UpdateFileMetadataModel File_document { get; set; }
    public string Name_Organization { get; set; }
    public string Appeal_Number { get; set; }
    public string Take_Location { get; set; }
    public string STIR { get; set; }
    public string Title { get; set; }
    public string Email_Organization { get; set; }
    public string Bank_Account_Number { get; set; }
    public OrderStatus Status { get; set; }
    public Appeal ToEntity()
    {
        var appealCreate = new Appeal();
        appealCreate.Id = Guid.NewGuid();
        appealCreate.Name_Organization = this.Name_Organization;
        appealCreate.Appeal_Number = this.Appeal_Number;
        appealCreate.Take_Location = this.Take_Location;
        appealCreate.STIR = this.STIR;
        appealCreate.Title = this.Title;
        appealCreate.Email_Organization = this.Email_Organization;
        appealCreate.Bank_Account_Number = this.Bank_Account_Number;
        appealCreate.Status = this.Status;
        return appealCreate;
    }
}
