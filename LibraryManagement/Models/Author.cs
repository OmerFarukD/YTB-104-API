namespace LibraryManagement.Models;

public class Author
{

  
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string SurName { get; set; }

    public DateTime BirthDate { get; set; }

    public ICollection<Book> Books { get; set; }



}
