namespace Suv_Xojaligi.V1.Auth.Models
{
    public class RemoveRoleFromUserModel
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
