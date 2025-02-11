//using System.ComponentModel.DataAnnotations;
using System.Net;
using Newtonsoft.Json;
using SuperReich.API.Errors;
using SuperReich.Application.Exceptions;

namespace SuperReich.API.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;
        private readonly IHostEnvironment _env = env;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                string result;

                switch (ex)
                {
                    case NotFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        result = CreateErrorResponse(ex, statusCode);
                        break;
                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationDetails = JsonConvert.SerializeObject(validationException.Errors);
                        result = CreateErrorResponse(ex, statusCode, validationDetails);
                        break;
                    case BadRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        result = CreateErrorResponse(ex, statusCode);
                        break;
                    case UnauthorizedAccessException:
                        statusCode = (int)HttpStatusCode.Unauthorized;
                        result = CreateErrorResponse(ex, statusCode);
                        break;
                    default:
                        result = CreateErrorResponse(ex, statusCode, ex.StackTrace);
                        break;
                }

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(result);
            }
        }

        private string CreateErrorResponse(Exception ex, int statusCode, string? details = null)
        {
            return JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, details));
        }
    }
}
