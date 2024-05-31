using Suv_Xojaligi.Data.Entities;

namespace Suv_Xojaligi.V1.Auth.Services.Interfaces
{
    public interface ITokenRepository
    {
        string CreateToken(User user, IList<string> roles);
    }
}
