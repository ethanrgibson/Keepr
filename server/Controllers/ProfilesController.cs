
using System.Threading.Tasks;

namespace keeper_final.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{

  private readonly ProfilesService _profileService;
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;

  public ProfilesController(ProfilesService profileService, Auth0Provider auth0Provider, VaultKeepsService vaultKeepsService, KeepsService keepsService, VaultsService vaultsService)
  {
    _profileService = profileService;
    _auth0Provider = auth0Provider;
    _vaultKeepsService = vaultKeepsService;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }


  [HttpGet("{profileId}")]

  public ActionResult<Profile> GetUsersProfile(string profileId)

  {
    try
    {
      Profile profile = _profileService.GetUsersProfile(profileId);
      return profile;
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{profileId}/keeps")]

  public ActionResult<List<Keep>> GetUsersKeeps(string profileId)

  {
    try
    {
      List<Keep> keeps = _keepsService.GetUsersKeeps(profileId);
      return keeps;

    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]

  public async Task<ActionResult<List<Vault>>> GetUsersVaults(string profileId)

  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.GetVaultsByAccountId(profileId, userInfo);
      return vaults;

    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }



}