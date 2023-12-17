using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.HelpClasses;
namespace WebAPI.Controllers;

[Route("/authors")]
public class AuthorController(IAuthorService service) : Controller
{
    private readonly IAuthorService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _service.GetAll();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var author = await _service.GetById(id);
            return Ok(author);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDTO author)
    {
        try
        {
            await _service.Update(id, author);
            return Ok();
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
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
