using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Abstracts;

public interface ICategoryRepository
{
    void Add(Category category);
    void Update(Category category);
    void Delete(Category category);

    Category? GetById(int id);

    List<Category> GetAll();


}
