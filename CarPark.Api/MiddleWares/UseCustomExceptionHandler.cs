using CarPark.Core.DTOs;
using CarPark.ServiceCopy.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarPark.Copy.Api.MiddleWares
{
    public static class UseCustomExceptionHandler 
    {
        public static void UseCustomException (this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statuscode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                    };
                    context.Response.StatusCode = statuscode;

                    var response = CustomResponseDto<NoContenDto>.Fail(statuscode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
