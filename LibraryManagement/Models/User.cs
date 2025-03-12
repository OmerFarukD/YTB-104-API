using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryManagement.Models;

public class User
{

    [BsonId]
    public ObjectId Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
