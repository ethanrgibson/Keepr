using System.ComponentModel.DataAnnotations;

namespace keeper_final.Models;

public class Keep : RepoItem<int>
{
  public string Name { get; set; }
  public string Description { get; set; }
  [Url] public string Img { get; set; }
  public int Views { get; set; }
  public int Kept { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}