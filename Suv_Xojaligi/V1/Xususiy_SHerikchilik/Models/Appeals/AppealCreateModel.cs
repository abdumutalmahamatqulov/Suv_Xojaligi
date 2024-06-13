using System.ComponentModel.DataAnnotations;
using Suv_Xojaligi.Data.Entities.Appeal_And_Applications;
using Suv_Xojaligi.Data.Entities.Commons;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Appeals;

public class AppealCreateModel
{
    public CreateFileMetadataModel document_down { get; set; }
    [Required]
    public string Name_Organization { get; set; }
    [Required]
    public string Appeal_Number { get; set; }
    [Required]
    public string Take_Location { get; set; }
    [Required]
    public string STIR { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Email_Organization { get; set; }
    [Required]
    public string Bank_Account_Number { get; set; }
    [Required]
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
