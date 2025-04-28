
namespace keeper_final.Repositories;

public class VaultsRepository
{

  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    string sql = @"

INSERT INTO 
vaults(name, description, img, is_private, creator_id)
VALUES(@Name, @Description, @Img, @IsPrivate, @CreatorId);

SELECT
vaults.*,
accounts.*
FROM vaults
INNER JOIN accounts ON accounts.id = vaults.creator_id
WHERE vaults.id =  LAST_INSERT_ID();";

    Vault createdVault = _db.Query(sql, (Vault vault, Profile account) =>
    {
      vault.Creator = account;
      return vault;
    }, vaultData).SingleOrDefault();

    return createdVault;


  }
}