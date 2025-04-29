


namespace keeper_final.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepRepository;

  public VaultKeepsService(VaultKeepsRepository vaultKeepRepository)
  {
    _vaultKeepRepository = vaultKeepRepository;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultKeep = _vaultKeepRepository.CreateVaultKeep(vaultKeepData);
    return vaultKeep;
  }

  internal List<VaultKeepKept> GetKeepsByVaultId(int vaultId)
  {
    List<VaultKeepKept> keeps = _vaultKeepRepository.GetKeepsByVaultId(vaultId);
    return keeps;
  }

  internal void DeleteVaultKeep(int vaultKeepId, Account userInfo)
  {
    VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);

    if (vaultKeep.CreatorId != userInfo.Id)
    {
      throw new Exception("YOU CANNOT DELETE ANOTHER USERS KEPT KEEP");
    }

    _vaultKeepRepository.DeleteVaultById(vaultKeepId);

  }

  private VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    VaultKeep vaultKeep = _vaultKeepRepository.GetVaultKeepById(vaultKeepId);

    if (vaultKeep == null)
    {
      throw new Exception("Invalid ID" + vaultKeepId);
    }

    return vaultKeep;
  }
}