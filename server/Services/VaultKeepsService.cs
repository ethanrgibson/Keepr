
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
}