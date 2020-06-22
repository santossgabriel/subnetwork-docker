using System.Collections.Generic;
using Site.Config;
using Site.Models;

namespace Site.Repository
{
  public class UserRepository : BaseRepository<UserModel>
  {
    private const string SELECT_COLUMNS = "Id, Name, Email, Password, Role, Document";

    public UserRepository(AppConfig config) : base(config) { }

    public long Add(UserModel user)
    {
      var query = $"INSERT INTO \"{TableName}\" (Name, Email, Password, Role, Document) VALUES (@Name, @Email, @Password, @Role, @Document)";
      Execute(query, user);
      return CurrentId(user);
    }

    public long Update(UserModel user)
    {
      var query = $"UPDATE \"{TableName}\" SET Name = @Name, Email = @Email, Password = @Password, Document = @Document WHERE Id = @Id";
      Execute(query, user);
      return CurrentId(user);
    }

    public UserModel FindByEmail(string email) => FirstOrDefault($"SELECT {SELECT_COLUMNS} FROM \"{TableName}\" WHERE EMAIL = '{email}'");

    public UserModel GetById(long id) => FirstOrDefault($"SELECT {SELECT_COLUMNS} FROM \"{TableName}\" WHERE Id = @Id", new { Id = id });

    public IEnumerable<UserModel> GetAll() => Query($"SELECT {SELECT_COLUMNS} FROM \"{TableName}\"");
  }
}