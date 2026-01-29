using ApiBootcampClt.Api.Contracts.Common;
using Microsoft.AspNetCore.Diagnostics;

namespace ApiBootcampClt.Api.Extensions;

public static class ExceptionHandlingExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerFeature>();
                if (feature is null)
                    return;

                var exception = feature.Error;

                var logger = context.RequestServices
                    .GetRequiredService<ILoggerFactory>()
                    .CreateLogger("GlobalExceptionHandler");

                logger.LogError(exception, "Unhandled exception");

                context.Response.ContentType = "application/json";

                var statusCode = exception is InvalidOperationException
                    ? StatusCodes.Status400BadRequest
                    : StatusCodes.Status500InternalServerError;

                var message = exception is InvalidOperationException
                    ? exception.Message
                    : "Ocurrió un error inesperado al procesar la solicitud";

                context.Response.StatusCode = statusCode;

                var error = new ErrorResponse(statusCode, message);

                await context.Response.WriteAsJsonAsync(error);
            });
        });

        return app;
    }
}
