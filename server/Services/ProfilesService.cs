
namespace keeper_final.Services;

public class ProfilesService
{

  private readonly ProfilesRepository _repository;

  public ProfilesService(ProfilesRepository repository)
  {
    _repository = repository;
  }

  internal Profile GetUsersProfile(string profileId)
  {
    Profile profile = _repository.GetUsersProfile(profileId);
    return profile;
  }
}