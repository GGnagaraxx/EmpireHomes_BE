using log4net;
using EmpireHomes_BE.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using log4net.Repository.Hierarchy;

namespace EmpireHomes_BE.Extensions
{
    public static class ExceptionMiddlewareExtension
    {

        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger _logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        _logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
