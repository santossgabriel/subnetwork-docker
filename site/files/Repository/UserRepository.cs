using System.Collections.Generic;
using Site.Config;
using Site.Models;

namespace Site.Repository
{
  public class UserRepository : BaseRepository<UserModel>
  {
    public UserRepository(AppConfig config) : base(config) { }

    public UserModel FindByEmail(string email) => FirstOrDefault($"SELECT ID, NAME, EMAIL, PASSWORD FROM \"USER\" WHERE EMAIL = '{email}'");

    public UserModel GetById(int id) => FirstOrDefault($"SELECT * FROM USER WHERE Id = @Id", new { Id = id });

    public IEnumerable<UserModel> GetAll() => Query("SELECT * FROM USER");
  }
}