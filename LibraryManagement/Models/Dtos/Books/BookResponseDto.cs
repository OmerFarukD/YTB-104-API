namespace LibraryManagement.Models.Dtos.Books;

public class BookResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }

    public int Page { get; set; }
    public double Price { get; set; }

    public int CategoryId { get; set; }

    public int AuthorId { get; set; }

    public string AuthorName { get; set; }

    public string CategoryName { get; set; }
}
