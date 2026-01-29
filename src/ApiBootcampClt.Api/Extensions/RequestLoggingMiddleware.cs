using System.Diagnostics;

namespace ApiBootcampClt.Api.Extensions;

public sealed class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        await next(context);
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
    }
}
