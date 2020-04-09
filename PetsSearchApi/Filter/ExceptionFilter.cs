using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using PetsSearchCommon;

namespace PetsSearchApi.Filter
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            ObjectResult result;
            switch (context.Exception)
            {
                case InvalidUrlException invalidUrlException:
                    _logger.LogError(context.Exception, "Invalid Url Exception");
                    result = new ObjectResult(invalidUrlException.ErrorMessage) { StatusCode = (int)invalidUrlException.Code };
                    break;
                default:
                    _logger.LogError(context.Exception, "Uncaught exception");
                    result = new ObjectResult("Uncaught exception") { StatusCode = (int)code };
                    break;
            }

            context.Result = result;
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;

            return Task.CompletedTask;
        }
    }
}