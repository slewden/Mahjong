namespace MahjongWS.Services
{
  /// <summary>
  /// Classe de base pour toutes les requetes
  /// </summary>
  public abstract class RequestBase
  {
    /// <summary>
    /// Clé d'autentification
    /// </summary>
    public string ApiKey { get; set; }
  }
}
