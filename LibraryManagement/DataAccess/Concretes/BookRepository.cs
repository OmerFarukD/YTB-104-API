using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Contexts;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DataAccess.Concretes;


// Single Responsibility
// Open Closed 
// Liskov un dönüşebilirlik prensibi
// Interface ayrışması 
public class BookRepository : IBookRepository
{
    private BaseDbContext context;

    public BookRepository(BaseDbContext context)
    {
        this.context = context;
    }

    public void Add(Book book)
    {
        
        context.Books.Add(book);
        context.SaveChanges();
    }

    public int CountByIsbn(string isbn)
    {
        return context.Books.Count(x => x.Isbn == isbn);
    }

    public int CountByTitle(string title)
    {
        return context.Books.Count(x=>x.Title==title);
    }

    public void Delete(Book book)
    {
        context.Books.Remove(book);
        context.SaveChanges();
    }

    public List<Book> GetAll()
    {
        List<Book> books = context.Books.Include(x=>x.Category).Include(z=>z.Author).ToList();
        return books;
    }

    public List<Book> GetAllByPriceRange(double min, double max)
    {
        List<Book> books = context.Books.Where(x => x.Price <= max && x.Price >= min).ToList();

        return books;
    }

    public Book? GetById(int id)
    {
        Book? book = context.Books.Include(x => x.Category).Include(z => z.Author).SingleOrDefault(X => X.Id == id);
        return book;
    }

    public Book? GetByIsbn(string isbn)
    {
        Book? book = context.Books.FirstOrDefault(x=>x.Isbn==isbn);
        return book;
    }

    public void Update(Book book)
    {
        context.Books.Update(book);
        context.SaveChanges();
    }

    public bool IsPresentByIsbn(string isbn)
    {
        return context.Books.Any(x => x.Isbn == isbn);
    }

    public bool IsPresentByTitle(string title)
    {
        return context.Books.Any(x=>x.Title == title);
    }
}
