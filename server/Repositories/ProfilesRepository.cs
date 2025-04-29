
namespace keeper_final.Repositories;

public class ProfilesRepository
{


  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetUsersProfile(string profileId)
  {
    string sql = "SELECT * FROM accounts WHERE id = @ProfileId;";

    Profile profile = _db.Query<Profile>(sql, new { profileId }).SingleOrDefault();

    return profile;

  }
}