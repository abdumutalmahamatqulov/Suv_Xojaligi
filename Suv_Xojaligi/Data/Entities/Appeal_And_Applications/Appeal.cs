using System.ComponentModel.DataAnnotations.Schema;
using Suv_Xojaligi.Data.Entities.Commons;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;

namespace Suv_Xojaligi.Data.Entities.Appeal_And_Applications;

public class Appeal : Auditable
{
    public string Name_Organization { get; set; }
    public string Appeal_Number { get; set; }
    public string Take_Location { get; set; }
    public string STIR { get; set; }
    public string Title { get; set; }
    public string Email_Organization { get; set; }
    public string Bank_Account_Number { get; set; }
    public OrderStatus Status { get; set; }
    public Guid FileId { get; set; }
    [ForeignKey("FileId")]
    public FileMetadata DocumentDown { get; set; }

}
