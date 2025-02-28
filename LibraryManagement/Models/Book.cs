namespace LibraryManagement.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public string Category { get; set; }
    public string Author { get; set; }

    public int Page { get; set; }
    public double Price { get; set; }
}
