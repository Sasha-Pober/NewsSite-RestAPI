using BLL.DTO;
using BLL.Interfaces;
using BLL.Request;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.HelpClasses;

namespace WebAPI.Controllers;

public class AuthentificationController : Controller
{
    private readonly IAuthorService _authorService;
    private readonly IAuthService _auth;
    public AuthentificationController(IAuthorService service, IAuthService auth)
    {
        _authorService = service;
        _auth = auth;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> RegisterAuthor([FromBody] AuthorDTO author)
    {
        try
        {
            await _authorService.Create(author);
            return Ok();
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest author)
    {
        try
        {
            var entity = author;
            entity.Password = PasswordHashingService.GetHashedPassword(entity.Password);

            string token = _auth.CreateToken(await _authorService.GetEntity(entity));
            return Ok(token);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }
}
