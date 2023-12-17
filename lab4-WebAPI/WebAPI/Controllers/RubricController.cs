using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.HelpClasses;

namespace WebAPI.Controllers;

[Route("/rubrics")]
public class RubricController(IRubricService rubricService) : Controller
{
    private readonly IRubricService _service = rubricService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rubrics = await _service.GetAll();
        return Ok(rubrics);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var rubric = await _service.GetById(id);
            return Ok(rubric);
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostRubric([FromBody] RubricDTO rubric)
    {
        try
        {
            await _service.Create(rubric);
            return Created();
        }
        catch (Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRubric(int id, [FromBody] RubricDTO rubric)
    {
        try
        {
            await _service.Update(id, rubric);
            return Ok();
        }
        catch(Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRubric(int id)
    {
        try
        {
            await _service.Delete(id);
            return Ok();
        }
        catch(Exception ex)
        {
            return ExceptionHandler.OnException(ex);
        }
    }
}
