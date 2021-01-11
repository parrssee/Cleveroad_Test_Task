using Cleveroad_Test_Task.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Cleveroad_Test_Task.Extensions
{
    public static class ExceptionExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
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
                        var responseModel = new Response<string>();
                        if (contextFeature.Error is Models.WebException)
                        {
                            context.Response.StatusCode = (contextFeature.Error as Models.WebException).StatusCode;
                            responseModel.Errors.Add(new Error()
                            {
                                StatusCode = context.Response.StatusCode.ToString(),
                                Message = contextFeature.Error.Message
                            });
                        }
                        responseModel.Result = false;
                        await context.Response.WriteAsync(responseModel.ToString());
                    }
                });
            });
        }
    }
}
