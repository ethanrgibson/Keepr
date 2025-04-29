namespace keeper_final.Services;

public class VaultKeepsService
{
private readonly VaultKeepsRepository _vaultKeepRepository;

  public VaultKeepsService(VaultKeepsRepository vaultKeepRepository)
  {
    _vaultKeepRepository = vaultKeepRepository;
  }
}