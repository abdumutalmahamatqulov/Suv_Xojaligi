using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suv_Xojaligi.V1.Auth.Models;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.Auth.Services.Interfaces;

namespace Suv_Xojaligi.V1.Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("Login")]
    public async ValueTask<IActionResult> Login([FromForm] LoginModel model)
    {
        try
        {

            return Ok(await _authService.Login(model));
        }
        catch (Suv_Xojaligi_ApiException ex)
        {
            return BadRequest(new
            {
                global = ex.Message,
            });
        }
    }
    [HttpPost("register")]
    public async ValueTask<IActionResult> Register([FromForm] RegisterModel model)
    {
        try
        {

            return Ok(await _authService.Registration(model));
        }
        catch (Suv_Xojaligi_ApiException ex)
        {
            return BadRequest(new
            {
                global = ex.Message,
            });
        }
    }
}
