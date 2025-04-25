

namespace keeper_final.Repositories;

public class KeepsRepository
{

  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    string sql = @"

    INSERT INTO 
      keeps(name, description, img, creator_id)
      VALUES(@Name, @Description, @Img, @CreatorId);

    SELECT 
      keeps.*,
      accounts.*
      FROM keeps
      INNER JOIN accounts ON accounts.id = keeps.creator_id
      WHERE keeps.id = LAST_INSERT_ID();";

    Keep createdKeep = _db.Query(sql, (Keep keep, Profile account) =>
    {

      keep.Creator = account;
      return keep;
    }, keepData).SingleOrDefault();

    return createdKeep;
  }

  internal List<Keep> GetKeeps()
  {
    string sql =
@"SELECT 
  keeps.*,
  accounts.* 
  FROM keeps
  INNER JOIN accounts ON accounts.id = keeps.creator_id;";

    List<Keep> keeps = _db.Query(sql, (Keep keeps, Profile account) =>
    {

      keeps.Creator = account;
      return keeps;

    }).ToList();

    return keeps;

  }
}