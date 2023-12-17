using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.HelpClasses;

public static class ExceptionHandler
{
    public static IActionResult OnException(Exception ex)
    {
        return new BadRequestObjectResult(ex.Message);
    }
}
