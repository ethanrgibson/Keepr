namespace keeper_final.Repositories;

public class VaultKeepsRepository
{

private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }


}