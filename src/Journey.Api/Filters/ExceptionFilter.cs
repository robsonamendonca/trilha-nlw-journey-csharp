using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is JourneyException)               
            {
                var journeyException = (JourneyException)context.Exception;

                context.HttpContext.Response.StatusCode = (int)journeyException.GetStatusCode();

                var responseErrorsJson = new ResponseErrorsJson(journeyException.GetErrosMessages());

                context.Result = new ObjectResult(responseErrorsJson);
            }

            else 
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                
                var responseErrorsJson = new ResponseErrorsJson(new List<string> { ResourceErrorMessages.ERROR_NOT_KNOW  });

                context.Result = new ObjectResult(responseErrorsJson);
            }
        }
    }
}
