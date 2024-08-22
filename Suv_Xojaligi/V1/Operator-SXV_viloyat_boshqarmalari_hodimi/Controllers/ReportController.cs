using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Efficiencies;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Models.Reports;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Repositories;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services;
using Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Services.Interfaces;

namespace Suv_Xojaligi.V1.Operator_SXV_viloyat_boshqarmalari_hodimi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;
    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    [HttpGet("GetById")]
    public async ValueTask<IActionResult> Get(Guid id)
    {
        return Ok(await _reportService.GetReport(id));
    }
    [HttpGet("GetAllReport")]
    public async ValueTask<IActionResult> GetAllReports([FromQuery]ReportFilterModel model)
    {
        return Ok(await _reportService.GetAllReports(model));
    }

    [HttpPost("CreateEfficiency")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public async ValueTask<IActionResult> CreateEfficiency([FromForm] ReportCreateModel model)
    {
        try
        {
            return Ok(await _reportService.CreateReport(model));
        }
        catch (Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }

    [HttpPut("UpdateReport")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public async ValueTask<IActionResult> UpdateReport([FromForm] ReportUpdateModel model)
    {
        try
        {
            return Ok(await _reportService.UpdateReport(model));
        }
        catch (Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]

    public async ValueTask<IActionResult> Delete(Guid id)
    {
        try
        {
            return Ok(await _reportService.Delete(id));
        }
        catch (Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }
    [HttpPut("Edit")]
    [Authorize(Roles = "SuperAdmin")]

    public async ValueTask<IActionResult> Edit([FromForm]AddetionalDataModel model)
    {
        try
        {

            return Ok(await _reportService.Edit(model));
        }
        catch(Suv_Xojaligi_ApiException suv)
        {
            return BadRequest(new
            {
                global = suv.Message
            });
        }
    }

}
