using System.Collections.Generic;
using Site.Config;
using Site.Models;

namespace Site.Repository
{
  public class UserRepository : BaseRepository<UserModel>
  {
    private const string SELECT_COLUMNS = "Id, Name, Email, Password, Role";

    public UserRepository(AppConfig config) : base(config) { }

    public long Add(UserModel user)
    {
      var query = "INSERT INTO \"USER\" (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, @Role)";
      Execute(query, user);
      return CurrentId(user);
    }

    public long Update(UserModel user)
    {
      var query = "UPDATE \"USER\" SET Name = @Name, Email = @Email, Password = @Password WHERE Id = @Id";
      Execute(query, user);
      return CurrentId(user);
    }

    public UserModel FindByEmail(string email) => FirstOrDefault($"SELECT {SELECT_COLUMNS} FROM \"USER\" WHERE EMAIL = '{email}'");

    public UserModel GetById(int id) => FirstOrDefault($"SELECT {SELECT_COLUMNS} FROM \"User\" WHERE Id = @Id", new { Id = id });

    public IEnumerable<UserModel> GetAll() => Query($"SELECT {SELECT_COLUMNS} FROM USER");
  }
}