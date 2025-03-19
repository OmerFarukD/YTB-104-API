using LibraryManagement.Exceptions.Types;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Middlewares
{
    public class ExceptionHandlerConfig : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            httpContext.Response.ContentType = "application/json";

            
            if(exception is NotFoundException notfound)
            {
              await  httpContext.Response.WriteAsync(notfound.Message);
                return false;
            }

            if(exception is BusinessException business)
            {
                await httpContext.Response.WriteAsync(business.Message);

                return false;
            }

            return true;

        }
    }
}
