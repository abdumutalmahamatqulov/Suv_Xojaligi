using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities.Appeal_And_Applications;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Repositories;

public class AppealRepository
{
    private readonly AppDbContext _appDbContext;

    public AppealRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
/*    public Task<Appeal> CreateAppeal(Appeal appeal)
    {
        var appealCreate = new Appeal();
        appealCreate.Document_Dowenloud = appeal.Document_Dowenloud;
        appealCreate.Name_Organization = appeal.Name_Organization;
        appealCreate.Appeal_Number = appeal.Appeal_Number;
        appealCreate.Take_Location = appeal.Take_Location;
        appealCreate.STIR = appeal.STIR;
        appealCreate.Title = appeal.Title;
        appealCreate.Email_Organization = appeal.Email_Organization;
        appealCreate.Bank_Account_Number = appeal.Bank_Account_Number;
        appealCreate.Status
    }*/

    /*    public string Document_Dowenloud { get; set; }
        public string Name_Organization { get; set; }
        public string Appeal_Number { get; set; }
        public string Take_Location { get; set; }
        public string STIR { get; set; }
        public string Title { get; set; }
        public string Email_Organization { get; set; }
        public string Bank_Account_Number { get; set; }
        public OrderStatus Status { get; set; }*/
}
