using Serilog;

namespace DefaultProject.Middlewares;

public class WriteDateQueryMiddleware : IMiddleware
{
    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Log.Information(context.Request.Path);
        await next(context);
    }
}