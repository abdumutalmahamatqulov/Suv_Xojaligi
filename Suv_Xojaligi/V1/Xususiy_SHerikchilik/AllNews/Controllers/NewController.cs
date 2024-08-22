using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Models;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Services.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.AllNews.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewController : ControllerBase
{
    private readonly INewService _newsService;

    public NewController(INewService newsService)
    {
        _newsService = newsService;
    }
    [HttpGet("GetByIdNew")]
    public async ValueTask<IActionResult> GetById( [FromQuery]Guid id)
    {
        return Ok(await _newsService.Get(id));
    }
    [HttpGet("GetByFilter")]
    public async ValueTask<IActionResult> GetByFilter([FromForm]NewFilterModel model)
    {
        return Ok(await _newsService.GetAll(model));
    }
    [HttpPost("CreateNew")]
    public async ValueTask<IActionResult> Create([FromForm]NewCreateModel model)
    {
        try
        {
            return Ok(await _newsService.CreateNew(model));
        }
        catch(Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }
    [HttpPut("UpdateNew")]
    public async ValueTask<IActionResult> Edit([FromForm]NewUpdateModel model)
    {
        try
        {
            return Ok(await _newsService.UpdateNew(model));
        }
        catch(Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }
    [HttpDelete("DeleteNew")]
    public async ValueTask<IActionResult> Delete([FromForm]Guid id)
    {
        try
        {
            return Ok(await _newsService.DeleteNew(id));
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
