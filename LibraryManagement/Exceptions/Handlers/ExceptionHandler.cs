using LibraryManagement.Exceptions.Types;

namespace LibraryManagement.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public HttpResponse Response { get; set; }



    public Task HandleExceptionAsync(Exception exception)
    {
        return exception switch
        {
            NotFoundException notFoundException => HandleException(notFoundException),
            BusinessException businessException => HandleException(businessException),
            ValidationException validationException => HandleException(validationException),
            _=> HandleException(exception)
        };
    }



    protected abstract Task HandleException(NotFoundException notFoundException);
    protected abstract Task HandleException( BusinessException businessException);
    protected abstract Task HandleException(ValidationException validationException);
    protected abstract Task HandleException(Exception exception);
}
