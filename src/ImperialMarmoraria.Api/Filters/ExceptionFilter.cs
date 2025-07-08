using ImperialMarmoraria.Communication.Responses.Orcamento;
using ImperialMarmoraria.Exception;
using ImperialMarmoraria.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ImperialMarmoraria.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is ImperialMarmorariaException)
        {
            HandleProjectException(context);
        } else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var imperialMarmorariaException = (ImperialMarmorariaException)context.Exception;
        var errorResponse = new ResponseErrorJson(imperialMarmorariaException.GetErrors());

        context.HttpContext.Response.StatusCode = imperialMarmorariaException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new BadRequestObjectResult(errorResponse);
    }
}
