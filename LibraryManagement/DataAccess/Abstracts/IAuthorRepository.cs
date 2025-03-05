using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Abstracts;

public interface IAuthorRepository
{

    void Add(Author author);
    void Update(Author author);
    void Delete(Author author);

    Author? GetById(int id);

    List<Author> GetAll();

}
