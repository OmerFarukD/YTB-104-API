using LibraryManagement.Exceptions.Handlers;
using System.Runtime.InteropServices;

namespace LibraryManagement.Exceptions;

public class ExceptionMiddleware
{

    private readonly RequestDelegate _next;
    private readonly ExceptionHandler _exceptionHandler;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _exceptionHandler = new HttpExceptionHandler();
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }catch(Exception ex)
        {

            await HandleExceptionAsync(httpContext.Response,ex);
        }
    }


   private Task HandleExceptionAsync(HttpResponse response,Exception exception)
    {

        response.ContentType = "application/json";
        _exceptionHandler.Response = response;
       return  _exceptionHandler.HandleExceptionAsync(exception);
    }



}
