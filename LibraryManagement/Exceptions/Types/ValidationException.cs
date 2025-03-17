namespace LibraryManagement.Exceptions.Types;

public class ValidationException : Exception
{


    public List<string> Errors { get; set; }
    public ValidationException(string message) : base(message)
    {
       
    }

    public ValidationException(List<string> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }


    private static string BuildErrorMessage(List<string> errors) 
    {
        return string.Join("\n", errors);
    }

    // "Başlık alanı boş olamaz", " Başlık Alanı minimum 2 haneli olmalıdır."
}
