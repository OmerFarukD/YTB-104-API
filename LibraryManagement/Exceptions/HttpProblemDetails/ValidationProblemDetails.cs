using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Exceptions.HttpProblemDetails;

public class ValidationProblemDetails: ProblemDetails
{
    public List<string> Errors { get; set; }

    public ValidationProblemDetails(List<string> errors)
    {
        Title = "Validation Exception";
        Errors = errors;
        Status = 404;

    }
}
