using MayraPlatform.Application.Common.Exceptions;
using MayraPlatform.Application.Common.Models;
using MayraPlatform.Application.Constants;
using System.Net;
using System.Text.Json;

namespace MayraPlatform.WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");

                context.Response.ContentType = "application/json";

                var (statusCode, message, errors) = ex switch
                {
                    BadRequestException badEx when badEx.Errors is not null && badEx.Errors.Length > 0 =>
                        ((int)HttpStatusCode.BadRequest, Constant.InvalidRequestMsg, badEx.Errors.ToList()),

                    BadRequestException =>
                        ((int)HttpStatusCode.BadRequest, Constant.InvalidRequestMsg, new List<string> { ex.Message }),

                    NotFoundException =>
                        ((int)HttpStatusCode.NotFound, Constant.NotFoundMsg, new List<string> { ex.Message }),

                    OperationCanceledException =>
                        ((int)HttpStatusCode.ServiceUnavailable, Constant.OperationCancelled, new List<string>()),

                    _ =>
                        ((int)HttpStatusCode.InternalServerError, Constant.UnexpectedError, new List<string> { ex.Message })
                };

                context.Response.StatusCode = statusCode;

                var response = ApiResponse.Fail(errors, message, statusCode);

                var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                await context.Response.WriteAsync(json);
            }
        }
    }
}

