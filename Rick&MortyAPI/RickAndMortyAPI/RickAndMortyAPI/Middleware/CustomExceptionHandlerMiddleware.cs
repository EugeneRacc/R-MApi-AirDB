using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using RickAndMortyBLL.Exceptions;

namespace RickAndMortyAPI.Middleware;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
        _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var message = string.Empty;
        switch (exception)
        {
            case RickAndMortyException:
                code = HttpStatusCode.NotFound;
                message = exception.Message;
                break;
            default:
                message = exception.Message;
                break;
        }
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(
            JsonSerializer.Serialize(
                new
                {
                    StatusCode = (int)code, 
                    Message = message
                }));
    }
}