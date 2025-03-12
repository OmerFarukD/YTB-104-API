using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Contexts;
using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Concretes;

public class UserRepository : IUserRepository
{
    MongoDbContext context = new MongoDbContext();
    public void Add(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }
}
