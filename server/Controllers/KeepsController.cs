using System.Threading.Tasks;

namespace keeper_final.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{

  private readonly KeepsService _keepService;
  private readonly Auth0Provider _auth0Provider;

  public KeepsController(KeepsService keepService, Auth0Provider auth0Provider)
  {
    _keepService = keepService;
    _auth0Provider = auth0Provider;
  }


  [Authorize]
  [HttpPost]

  public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      Keep keep = _keepService.CreateKeep(keepData);
      return Ok(keep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }

  }


}

