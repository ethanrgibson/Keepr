


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


  internal List<VaultKeepKept> GetKeepsByVaultId(int vaultId)
  {
    string sql = @"
SELECT
keeps.*, 
vaultkeeps.id AS vault_keep_id,
accounts.*
FROM vaultkeeps
INNER JOIN accounts ON accounts.id = vaultkeeps.creator_id
INNER JOIN keeps ON keeps.id = vaultkeeps.keep_id
WHERE vaultkeeps.vault_id = @VaultId;";

    List<VaultKeepKept> vaultKeepsKept = _db.Query(sql, (VaultKeepKept vaultKeepKept, Profile account) =>
    {
      vaultKeepKept.Creator = account;

      return vaultKeepKept;
    }, new { vaultId }).ToList();

    return vaultKeepsKept;
  }

  internal VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    string sql = "SELECT * FROM vaultkeeps WHERE id = @VaultKeepId LIMIT 1;";

    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { vaultKeepId }).SingleOrDefault();

    return vaultKeep;
  }

  internal void DeleteVaultById(int vaultKeepId)
  {
    string sql = "DELETE FROM vaultkeeps WHERE id = @VaultKeepId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { vaultKeepId });

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows were affected, and that is no good!");
    }
  }
}