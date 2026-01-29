using System.Diagnostics;

namespace ApiBootcampClt.Api.Extensions;

public sealed class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        context.Response.OnCompleted(() =>
        {
            stopwatch.Stop();

            var query = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : "";
            logger.LogInformation(
                "HTTP {Method} {Path}{Query} -> {StatusCode} in {ElapsedMs} ms",
                context.Request.Method,
                context.Request.Path,
                query,
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds
            );

            return Task.CompletedTask;
        });

        await next(context);
    }
}
