





namespace keeper_final.Services;

public class KeepsService
{

  private readonly KeepsRepository _repository;

  public KeepsService(KeepsRepository repository)
  {
    _repository = repository;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    Keep keep = _repository.CreateKeep(keepData);
    return keep;
  }


  internal List<Keep> GetKeeps()
  {
    List<Keep> keeps = _repository.GetKeeps();
    return keeps;
  }

  internal Keep GetKeepById(int keepId)
  {
    Keep keep = _repository.GetKeepById(keepId);

    if (keep == null)
    {
      throw new Exception("This Keep does not exist!");
    }


    return keep;
  }

  internal Keep UpdateKeep(int keepId, Keep keepData, Account userInfo)
  {
    Keep keep = GetKeepById(keepId);

    if (keep.CreatorId != userInfo.Id)
    {
      throw new Exception("YOU CANNOT EDIT ANOTHER USER'S KEEP, JERK");
    }

    keep.Name = keepData.Name ?? keep.Name;
    keep.Description = keepData.Description ?? keep.Description;

    _repository.UpdateKeep(keep);

    return keep;


  }

  internal string DeleteKeep(int keepId, Account userInfo)
  {
    Keep keep = GetKeepById(keepId);

    if (keep.CreatorId != userInfo.Id)
    {
      throw new Exception("YOU CANNOT DELETE ANOTHER USERS KEEP, JERK!");
    }

    _repository.DeleteKeep(keepId);

    return $"Your {keep.Name} Keep has been deleted!";



  }

  internal Keep IncreaseViews(int keepId)
  {
    Keep keep = GetKeepById(keepId);

    keep.Views++;
    _repository.IncreaseViews(keep);

    return keep;

  }

internal List<Keep> GetUsersKeeps(string profileId)
  {
    List<Keep> keeps = _repository.GetUsersKeeps(profileId);
    return keeps;
  }

}