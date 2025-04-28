


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


  internal Vault GetVaultById(int vaultId)
  {
    string sql = @"

SELECT 
vaults.*,
accounts.*
FROM vaults
INNER JOIN accounts ON accounts.id = vaults.creator_id
WHERE vaults.id = @VaultId;";

    Vault foundVault = _db.Query(sql, (Vault vault, Profile account) =>
    {
      vault.Creator = account;
      return vault;
    }, new { vaultId }).SingleOrDefault();

    return foundVault;
  }

  internal void UpdateVault(Vault vaultUpdated)
  {
    string sql = @"

UPDATE vaults
SET
name = @Name,
is_private = @isPrivate
WHERE id = @Id 
LIMIT 1;";

    int rowsAffected = _db.Execute(sql, vaultUpdated);

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows affected, and that is not good!");

    }
  }
  internal void DeleteVault(int vaultId)
  {
    string sql = "DELETE FROM vaults WHERE id = @VaultId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { vaultId });

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows affected, and that is not good!");

    }
  }


}