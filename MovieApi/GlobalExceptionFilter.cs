using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieApi.Common.Constant;
using System.Net;

namespace MovieApi
{
    public class GlobalExceptionFilters : IExceptionFilter
    {
        private readonly ILogger _logger;


        public GlobalExceptionFilters(ILogger<GlobalExceptionFilters> logger)
        {
            _logger = logger;
        }


        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var exception = context.Exception;


                int statusCode;


                switch (true)
                {



                    case bool _ when exception is FriendlyException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case bool _ when exception is ArgumentException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }


                _logger.LogError($"GlobalExceptionFilter: Error in {context.ActionDescriptor.DisplayName}. {exception.Message}. Stack Trace: {exception.StackTrace}");


                // Custom Exception message to be returned to the UI
                context.Result = new ObjectResult(exception.Message) { StatusCode = statusCode };
            }
        }
    }
}
