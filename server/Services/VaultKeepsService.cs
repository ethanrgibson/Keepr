


namespace keeper_final.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepRepository;
  private readonly KeepsService _keepsService;

  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository vaultKeepRepository, KeepsService keepsService, VaultsService vaultsService)
  {
    _vaultKeepRepository = vaultKeepRepository;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, Account userInfo)
  {

    Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId, userInfo);

    if (vault.CreatorId != userInfo.Id)
    {
      throw new Exception("YOU CANNOT VIEW PICTURES FROM A PRIVATE VAULT");
    }

    VaultKeep vaultKeep = _vaultKeepRepository.CreateVaultKeep(vaultKeepData);
    return vaultKeep;
  }

  internal List<VaultKeepKept> GetKeepsByVaultId(int vaultId, Account userInfo)
  {

  _vaultsService.GetVaultById(vaultId, userInfo);


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