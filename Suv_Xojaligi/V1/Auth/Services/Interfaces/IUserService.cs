using Suv_Xojaligi.V1.Auth.Models;

namespace Suv_Xojaligi.V1.Auth.Services.Interfaces;

public interface IUserService
{
    ValueTask<UsersModel> RemoveRoleUserAsync(RemoveRoleFromUserModel removeRoleFromUserModel);
    ValueTask<UsersModel> UserRoleAsync(UserRoleCreateModel userRoleCreateModel);
    ValueTask<bool> DeleteUserAsync(Guid Id);
    ValueTask<IList<UsersModel>> GetAllUsersAsync();
}
