using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Concretes;

public class CategoryRepository : ICategoryRepository
{
    
    BaseDbContext context = new BaseDbContext();


    public void Add(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
    }

    public void Delete(Category category)
    {
        context.Categories.Remove(category);
        context.SaveChanges();
    }

    public List<Category> GetAll()
    {
        return context.Categories.ToList();
    }

    public Category? GetById(int id)
    {
        return context.Categories.Find(id);
    }

    public void Update(Category category)
    {
        context.Categories.Update(category);
        context.SaveChanges();
    }
}
