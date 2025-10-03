using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.Utilities;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not FluentValidation.ValidationException ex)
            return;
        
        var errors = ex.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key[4..].ToLower(),
                g => g.Select(e => e.ErrorMessage).ToArray());

        context.Result = new BadRequestObjectResult(new { errors });
        context.ExceptionHandled = true;
    }
}