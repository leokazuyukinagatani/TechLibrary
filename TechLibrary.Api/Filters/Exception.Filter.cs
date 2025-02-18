using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibrary.Exception.ExceptionsBase;

namespace TechLibrary.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    void IExceptionFilter.OnException(ExceptionContext context)
    {
        if (context.Exception is TechLibraryException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var techLibraryException = (TechLibraryException)context.Exception;
        var errorResponse = new ResponseErrorJson(techLibraryException.GetErrors());

        context.HttpContext.Response.StatusCode = techLibraryException.StatusCode;

        context.Result = new ObjectResult(errorResponse);

    }
    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
