namespace keeper_final.Services;

public class ProfilesService
{

private readonly ProfilesRepository _repository;

  public ProfilesService(ProfilesRepository repository)
  {
    _repository = repository;
  }
}