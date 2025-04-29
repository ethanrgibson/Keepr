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

  [HttpGet]

  public ActionResult<List<Keep>> GetKeeps()
  {
    try
    {
      List<Keep> keeps = _keepService.GetKeeps();
      return Ok(keeps);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }



  [HttpGet("{keepId}")]
  public async Task<ActionResult<Keep>> GetKeepById(int keepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepService.IncreaseViews(keepId);
      return Ok(keep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


  [Authorize]
  [HttpPut("{keepId}")]

  public async Task<ActionResult<Keep>> UpdateKeep(int keepId, [FromBody] Keep keepData)
  {
    try
    {

      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep updatedKeep = _keepService.UpdateKeep(keepId, keepData, userInfo);
      return Ok(updatedKeep);

    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


  [Authorize]
  [HttpDelete("{keepId}")]

  public async Task<ActionResult<string>> DeleteKeep(int keepId)
  {
    try
    {
    Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
    string message = _keepService.DeleteKeep(keepId, userInfo);
    return Ok(message);
      
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }

  }

}

