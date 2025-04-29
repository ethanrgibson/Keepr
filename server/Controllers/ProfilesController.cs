
namespace keeper_final.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{

  private readonly ProfilesService _profileService;
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultKeepsService _vaultKeepsService;

  public ProfilesController(ProfilesService profileService, Auth0Provider auth0Provider, VaultKeepsService vaultKeepsService)
  {
    _profileService = profileService;
    _auth0Provider = auth0Provider;
    _vaultKeepsService = vaultKeepsService;
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




}