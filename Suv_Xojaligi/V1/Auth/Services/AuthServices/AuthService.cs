using Microsoft.AspNetCore.Identity;
using Suv_Xojaligi.Data.Entities;
using Suv_Xojaligi.V1.Auth.Models;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.Auth.Services.Interfaces;

namespace Suv_Xojaligi.V1.Auth.Services.AuthServices;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenRepository _tokenGenerator;
    private readonly SignInManager<User> _signInManager;
    public AuthService(ITokenRepository tokenGenerator, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _tokenGenerator = tokenGenerator;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async ValueTask<TokenModel> Login(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            throw new Suv_Xojaligi_ApiException(400, "user_not_Found");
        }
        var checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);
        var roles = await _userManager.GetRolesAsync(user);
        if (!checkPassword)
        {
            throw new Suv_Xojaligi_ApiException(401, "Email or password is incorrect");
        }
        //var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
        var token = _tokenGenerator.CreateToken(user, roles);
        return new TokenModel { Token = token };

    }

    public async ValueTask<UserModel> Registration(RegisterModel user)
    {
        User newUser = new User()
        {
            UserName = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDate = user.BirthDate

        };
        var registerUser = await _userManager.CreateAsync(newUser, user.Password);
        if (!registerUser.Succeeded)
        {
            throw new Suv_Xojaligi_ApiException(400, string.Join(", ", registerUser.Errors.Select(x => x.Description)));
        }
        return new UserModel().MapFromEntity(newUser);
    }
}
