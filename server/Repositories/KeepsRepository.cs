



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

  internal Keep GetKeepById(int keepId)
  {
    string sql = @"

SELECT 
keeps.*,
accounts.*
FROM keeps
INNER JOIN accounts ON accounts.id = keeps.creator_id
WHERE keeps.id = @keepId;";


    Keep keep = _db.Query(sql, (Keep keep, Profile account) =>
    {
      keep.Creator = account;
      return keep;
    }, new { keepId }).SingleOrDefault();
    return keep;
  }

  internal void UpdateKeep(Keep keep)
  {
    string sql = @"

UPDATE keeps
SET 
name = @Name,
description = @Description
WHERE id = @id
Limit 1;";

    int rowsAffected = _db.Execute(sql, keep);


    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows were affected. And that's a problem!");
    }
  }

  internal void DeleteKeep(int keepId)
  {
    string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";


    int rowsAffected = _db.Execute(sql, new { keepId });

    if (rowsAffected == 0)
    {
      throw new Exception("No rows affected, nothing deleted");
    }

    if (rowsAffected > 1)
    {
      throw new Exception(rowsAffected + " rows were affected. And that's a problem!");
    }
  }

  internal void IncreaseViews(Keep keep)
  {
    string sql = @"
UPDATE keeps
SET views = @Views
WHERE id = @Id LIMIT 1;";


    int rowsAffected = _db.Execute(sql, keep);

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows were affected. And that's a problem!");
    }
  }

 internal List<Keep> GetUsersKeeps(string profileId)
  {
    string sql = @"

SELECT
keeps.*, 
accounts.*
FROM keeps
INNER JOIN accounts ON accounts.id = keeps.creator_id
WHERE keeps.creator_id = @ProfileId;";


    List<Keep> keeps = _db.Query(sql, (Keep keep, Profile account) =>
      {
        keep.Creator = account;

        return keep;
      }, new { profileId }).ToList();

    return keeps;
  }
}
