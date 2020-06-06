using System.Collections.Generic;
using Site.Config;
using Site.Models;

namespace Site.Repository
{
  public class UserRepository : BaseRepository<UserModel>
  {
    public UserRepository(AppConfig config) : base(config) { }

    public long Add(UserModel user)
    {
      var query = "INSERT INTO \"USER\" (NAME, EMAIL, PASSWORD, ROLE) VALUES (@Name, @Email, @Password, @Role)";
      Execute(query, user);
      return CurrentId(user);
    }

    public long Update(UserModel user)
    {
      var query = "UPDATE \"USER\" SET NAME = @Name, EMAIL = @Email, PASSWORD = @Password WHERE ID = @Id";
      Execute(query, user);
      return CurrentId(user);
    }

    public UserModel FindByEmail(string email) => FirstOrDefault($"SELECT ID, NAME, EMAIL, PASSWORD, ROLE FROM \"USER\" WHERE EMAIL = '{email}'");

    public UserModel GetById(int id) => FirstOrDefault($"SELECT ID, NAME, EMAIL, PASSWORD, ROLE FROM USER WHERE Id = @Id", new { Id = id });

    public IEnumerable<UserModel> GetAll() => Query("SELECT ID, NAME, EMAIL, PASSWORD, ROLE FROM USER");
  }
}