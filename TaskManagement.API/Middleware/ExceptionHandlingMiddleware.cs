using System.Net;
using System.Text.Json;
using TaskManagement.Application.Exceptions;

namespace TaskManagement.API.Middleware;


public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try 
        {
            await _next(context);
        }
        catch(NotFoundException ex)
        {
            _logger.LogInformation(ex,"Resouce not found: {Message}", ex.Message);

            await WriteResponseAsync(context , HttpStatusCode.NotFound, ex.Message);
        }
        catch(BusinessRuleException ex) 
        {
            _logger.LogInformation(ex,"Buisness Rule violation: {Message}", ex.Message);

            await WriteResponseAsync(context , HttpStatusCode.BadRequest, ex.Message);
        }
        catch(Exception ex)
        {
             _logger.LogError(ex,"Unhandled Exception occured ");

            await WriteResponseAsync(context , HttpStatusCode.InternalServerError , "An unexpected error occured");

        }
    }


    private static async Task WriteResponseAsync(HttpContext context, HttpStatusCode statusCode , string message)
    {
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        var response = new {error = message , statusCode = (int)statusCode};
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));


    }

}


