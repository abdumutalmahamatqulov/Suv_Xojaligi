using Suv_Xojaligi.Data.Entities.Appeal_And_Applications;
using Suv_Xojaligi.Data.Entities.Commons;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Appeals;

public class AppealModel
{
    public Guid Id { get; set; }
    public string Document_Dowenloud { get; set; }
    public string Name_Organization { get; set; }
    public string Appeal_Number { get; set; }
    public string Take_Location { get; set; }
    public string STIR { get; set; }
    public string Title { get; set; }
    public string Email_Organization { get; set; }
    public string Bank_Account_Number { get; set; }
    public OrderStatus Status { get; set; }
    public AppealModel MapFromEntity(Appeal entity)
    {
        Id = entity.Id;
        Document_Dowenloud = entity.Document_Dowenloud;
        Name_Organization = entity.Name_Organization;
        Appeal_Number = entity.Appeal_Number;
        Take_Location = entity.Take_Location;
        STIR = entity.STIR;
        Title = entity.Title;
        Email_Organization = entity.Email_Organization;
        Bank_Account_Number = entity.Bank_Account_Number;
        return this;

    }
}
