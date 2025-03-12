using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Contexts;
using LibraryManagement.Models;
using MongoDB.Bson;

namespace LibraryManagement.DataAccess.Concretes;

public class UserRepository : IUserRepository
{
    MongoDbContext context = new MongoDbContext();
    public void Add(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public List<User> GetAll()
    {
        return context.Users.ToList();
    }

    public User GetById(Guid id)
    {
        return context.Users.Find(id);
    }
}
