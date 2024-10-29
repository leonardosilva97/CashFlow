using CashFlow.Communication.Responses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;
//vamos criar nosso proprio filtro de excessões 


public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
       if(context.Exception is CashFlowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException)
        {
            var ex = (ErrorOnValidationException)context.Exception;

            var erroResponse = new ResponseErrosJson(ex.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(erroResponse);
        }
        else
        {
            var erroResponse = new ResponseErrosJson(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(erroResponse);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var erroResponse = new ResponseErrosJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(erroResponse);

      
    }
}
