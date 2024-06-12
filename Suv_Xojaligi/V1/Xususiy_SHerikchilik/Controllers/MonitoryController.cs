using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Models.Monitories;
using Suv_Xojaligi.V1.Xususiy_SHerikchilik.Services.Interfaces;

namespace Suv_Xojaligi.V1.Xususiy_SHerikchilik.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MonitoryController : ControllerBase
{
    private readonly IMonitoringService _monitoringService;

    public MonitoryController(IMonitoringService monitoringService)
    {
        _monitoringService = monitoringService;
    }
    [HttpGet("GetById")]
    public async ValueTask<IActionResult> Get([FromForm]Guid id)
    {
        return Ok(await _monitoringService.Get(id));
    }
    [HttpGet("GetAllFilter")]
    public async ValueTask<IActionResult> GetAllFilter([FromForm]MonitoringFilterModel filter)
    {
        return Ok(await _monitoringService.GetByFilter(filter));
    }
    [HttpPost("createMonitory")]
    public async ValueTask<IActionResult> CreateMonitory([FromForm]MonitoringCreateModel model)
    {
        return Ok(await _monitoringService.CreateMonitoring(model));
    }
    [HttpPut("updateMonitory")]
    public async ValueTask<IActionResult> UpdateMonitory([FromForm]MonitoringUpdateModel model)
    {
        return Ok(await _monitoringService.Update(model));
    }
    [HttpDelete("deleteMonitory")]
    public async ValueTask<IActionResult> DeleteMonitory([FromForm]Guid id)
    {
        return Ok(await _monitoringService.Delete(id));
    }
}
