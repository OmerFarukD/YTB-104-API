using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Contexts;
using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Concretes;

public class AuthorRepository : IAuthorRepository
{


    private BaseDbContext context;

    public AuthorRepository(BaseDbContext context)
    {
        this.context = context;
    }


    public void Add(Author author)
    {
        context.Authors.Add(author);
        context.SaveChanges();

    }

    public void Delete(Author author)
    {
        context.Authors.Remove(author);
        context.SaveChanges();
    }

    public List<Author> GetAll()
    {
        List<Author> authors = context.Authors.ToList();
        return authors;
    }

    public Author? GetById(int id)
    {
        return context.Authors.Find(id);
    }

    public void Update(Author author)
    {
        context.Authors.Update(author);
        context.SaveChanges();
    }
}
