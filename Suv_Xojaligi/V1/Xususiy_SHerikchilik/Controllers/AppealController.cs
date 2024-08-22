using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Appeals;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppealController : ControllerBase
{
    private readonly IAppealService _appealService;

    public AppealController(IAppealService appealService)
    {
        _appealService = appealService;
    }
    [HttpGet("GetById")]
    public async ValueTask<IActionResult> GetById([FromForm]Guid id)
    {
        return Ok(await _appealService.Get(id));
    }
    [HttpGet("GetFilter")]
    public async ValueTask<IActionResult> GetFilter([FromForm] AppealFilterModel model)
    {
        try
        {

            return Ok(await _appealService.GetAll(model));
        }
        catch (Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }
    [HttpPost("create_appeal")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public async ValueTask<IActionResult> Create([FromForm] AppealCreateModel model)
    {
        try
        {

            return Ok(await _appealService.CreateAppeal(model));
        }
        catch (Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }
    [HttpPut("Update")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public async ValueTask<IActionResult> Update([FromForm]AppealUpdateModel model)
    {
        try
        {

            return Ok(await _appealService.Update(model));
        }
        catch (Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }
    [HttpDelete("Delete_Appeal_By_id")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public async ValueTask<IActionResult> Delete([FromForm]Guid id)
    {
        try
        {

            return Ok(await _appealService.DeleteAppeal(id));
        }
        catch (Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }
}
