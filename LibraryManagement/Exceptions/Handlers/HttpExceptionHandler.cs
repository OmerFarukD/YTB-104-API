using LibraryManagement.Exceptions.HttpProblemDetails;
using LibraryManagement.Exceptions.Types;
using System.Text.Json;

namespace LibraryManagement.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        public HttpResponse Response { get; set; }
        protected override Task HandleException(NotFoundException notFoundException)
        {
            Response.StatusCode = 404;
            NotFoundProblemDetails details = new NotFoundProblemDetails(notFoundException.Message);
            string serialize = JsonSerializer.Serialize(details);

           return Response.WriteAsync(serialize);
        }

        protected override Task HandleException(BusinessException businessException)
        {
            Response.StatusCode = 400;
            var details = new BusinessException(businessException.Message);
            string serialize = JsonSerializer.Serialize(details);

            return Response.WriteAsync(serialize);
        }

        protected override Task HandleException(ValidationException validationException)
        {
            Response.StatusCode = 400;
            var details = new ValidationProblemDetails(validationException.Errors);
            string serialize = JsonSerializer.Serialize(details);

            return Response.WriteAsync(serialize);
        }

        protected override Task HandleException(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
