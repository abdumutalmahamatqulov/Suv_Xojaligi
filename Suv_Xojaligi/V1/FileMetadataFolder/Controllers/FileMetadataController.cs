using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suv_Xojaligi.V1.Auth.Services.Exceptions;
using Suv_Xojaligi.V1.FileMetadataFolder.Model;
using Suv_Xojaligi.V1.FileMetadataFolder.Services.Interfaces;

namespace Suv_Xojaligi.V1.FileMetadataFolder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileMetadataController : ControllerBase
{
    private readonly IFileMetadataService _fileMetadataService;

    public FileMetadataController(IFileMetadataService fileMetadataService)
    {
        _fileMetadataService = fileMetadataService;
    }

    [HttpPost]
    //[Authorize(Roles = "SuperAdmin,Admin")]

    public async ValueTask<IActionResult> Create(CreateFileMetadataModel model)
    {
        return Ok(await _fileMetadataService.CreateAsync(model));
    }
    [HttpDelete]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public async ValueTask<IActionResult> Delete(Guid id)
    {
        try
        {
            return Ok(await _fileMetadataService.Delete(id));
        }
        catch (Suv_Xojaligi_ApiException ex)
        {
            return BadRequest(new
            {
                global = ex.Message,
            });
        }

    }
    [HttpPut]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public async ValueTask<IActionResult> Update(UpdateFileMetadataModel update)
    {
        try
        {
            return Ok(await _fileMetadataService.Update(update));

        }
        catch (Suv_Xojaligi_ApiException ex)
        {
            return BadRequest(new
            {
                global = ex.Message
            });
        }
    }
    [HttpGet("GetAll")]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(await _fileMetadataService.GetAll());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBase64(Guid id)
    {
        return Ok(await _fileMetadataService.GetAsync(id));
    }

    [HttpGet("{id:guid}/static")]
    public async Task<Stream> GetStaticFile(Guid id)
    {
        var (stream, contentType, fileName) = await _fileMetadataService.GetAsStream(id);

        return stream;
    }
}


