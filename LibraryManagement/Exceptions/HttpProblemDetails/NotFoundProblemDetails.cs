using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Exceptions.HttpProblemDetails;

public class NotFoundProblemDetails : ProblemDetails
{
    public NotFoundProblemDetails(string message)
    {
        Title = "Not Found Exception";
        Status = 404;
        Detail = message;
    }
}
