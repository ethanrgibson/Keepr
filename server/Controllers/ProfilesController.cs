
namespace keeper_final.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{

private readonly ProfilesService _profileService;
private readonly Auth0Provider _auth0Provider;

  public ProfilesController(ProfilesService profileService, Auth0Provider auth0Provider)
  {
    _profileService = profileService;
    _auth0Provider = auth0Provider;
  }
}