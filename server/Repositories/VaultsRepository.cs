namespace keeper_final.Repositories;

public class VaultsRepository
{

private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }
}