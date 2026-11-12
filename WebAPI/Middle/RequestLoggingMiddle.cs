using System.Net;

namespace WebAPI.Middle;

public class RequestLoggingMiddle(
    RequestDelegate next,
    ILogger<RequestLoggingMiddle> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestLoggingMiddle> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"Request: {context.Request.Path} {DateTime.Now}");
        await _next(context);
        _logger.LogInformation($"Request: {context.Response.StatusCode} {DateTime.Now}");
    }
}
