using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBooks.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is MyRecipeBookException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowException(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValdiationException)
        {
            var exception = context.Exception as ErrorOnValdiationException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception._ErrorMessages));
        }
    }
    
    private void ThrowUnknowException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValdiationException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Result = new ObjectResult(new ResponseErrorJson("An unknow error happens"));
        }
    }
}