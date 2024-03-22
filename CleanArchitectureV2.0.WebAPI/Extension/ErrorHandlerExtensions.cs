using CleanArchitectureV2._0.Application.Common.Exception;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CleanArchitectureV2._0.WebAPI.Extension
{
    public static class ErrorHandlerExtensions
    {
        public static void UserErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is null)
                    {
                        return;
                    }
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.ContentType = "application/json";

                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        BadRequestException => (int)HttpStatusCode.BadRequest,
                        OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
                        NotFoundException => (int)HttpStatusCode.NotFound,
                        _ => (int)HttpStatusCode.InternalServerError
                    };
                    var errorResponse = new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    };
                    await context.Response.WriteAsJsonAsync(errorResponse);
                });
            });
        }
    }
}
