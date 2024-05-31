using Suv_Xojaligi.V1.Auth.Models;

namespace Suv_Xojaligi.V1.Auth.Services.Interfaces
{
    public interface IAuthService
    {
        ValueTask<UserModel> Registration(RegisterModel user);
        ValueTask<TokenModel> Login(LoginModel model);
    }
}
