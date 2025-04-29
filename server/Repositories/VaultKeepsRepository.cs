
namespace keeper_final.Repositories;

public class VaultKeepsRepository
{

  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
INSERT INTO
vaultkeeps(keep_id, vault_id, creator_id)
VALUES(@KeepId, @VaultId, @CreatorId);

SELECT
*
FROM vaultkeeps
WHERE vaultkeeps.id = LAST_INSERT_ID();";

    VaultKeep createdVaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).SingleOrDefault();

    return createdVaultKeep;
  }
}