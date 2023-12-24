using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.HelpClasses;

namespace WebAPI.Controllers;

[Route("/news")]
public class NewsController(INewsService service) : Controller
{
    private readonly INewsService _newsService = service;

    [HttpGet]
    public async Task<IActionResult> GetAllNews()
    {
        var collection = await _newsService.GetAll();
        return Ok(collection);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNewsById(int id)
    {
        try
        {
            var news = await _newsService.GetById(id);
            return Ok(news);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }

    }

    [HttpGet("authors/{id}")]
    public async Task<IActionResult> GetNewsByAuthorId(int id)
    {
        try
        {
            var news = await _newsService.GetByAuthorId(id);
            return Ok(news);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }

    }

    [HttpGet("rubrics/{id}")]
    public async Task<IActionResult> GetNewsByRubricId(int id)
    {
        try
        {
            var news = await _newsService.GetByRubricId(id);
            return Ok(news);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }

    }

    [HttpGet("dates/{dateFrom}&{dateTo}")]
    public async Task<IActionResult> GetNewsBetweenDates(DateTime dateFrom, DateTime dateTo)
    {
        try
        {
            var news = await _newsService.GetBetweenDates(dateFrom, dateTo);
            return Ok(news);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }

    }

    [HttpGet("tags/{id}")]
    public async Task<IActionResult> GetNewsByTagId(int id)
    {
        try
        {
            var news = await _newsService.GetByTagId(id);
            return Ok(news);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }

    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> PostNews([FromBody] NewsDTO news)
    {
        try
        {
            await _newsService.Create(news);
            return Created($"{Uri.UriSchemeNews}", news);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [Authorize]
    [HttpPut("{newsId}/authors/{authorId}")]
    public async Task<IActionResult> UpdateAuthorsNews(int newsId, int authorId, [FromBody] NewsDTO newsdto)
    {
        try
        {
            await _newsService.UpdateByIdAndAuthorId(newsdto, newsId, authorId);
            return Ok();
        }
        catch(Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [Authorize]
    [HttpDelete("{newsId}/authors/{authorId}")]
    public async Task<IActionResult> DeleteAuthorsNews(int newsId, int authorId)
    {
        try
        {
            await _newsService.DeleteByIdAndAuthorId(newsId, authorId);
            return Ok();
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

}
