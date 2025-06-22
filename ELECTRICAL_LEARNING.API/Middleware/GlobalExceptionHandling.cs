
using System.Text.Json;

namespace ElectricalLearning.Api.Middleware
{
    public class GlobalExceptionHandling : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = 400;
            var response = new
            {
                title = "Server Error",
                statusCode = statusCode,
                message = exception.Message,
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
