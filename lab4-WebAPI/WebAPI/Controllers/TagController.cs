using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.HelpClasses;

namespace WebAPI.Controllers;

[Route("/tags")]
public class TagController(ITagService service) : Controller
{
    private readonly ITagService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tags = await _service.GetAll();
        return Ok(tags);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var tag = await _service.GetById(id);
            return Ok(tag);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> PostTag([FromBody] TagDTO tag)
    {
        try
        {
            await _service.Create(tag);
            return Created();
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTag(int id, [FromBody] TagDTO tag)
    {
        try
        {
            await _service.Update(id, tag);
            return Ok();
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        try
        {
            await _service.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }
}
