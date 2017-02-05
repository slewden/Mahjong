using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongWS.Services.User
{
  /// <summary>
  /// Classe response pour le get ou la mise à jour d'un user
  /// </summary>
  public class UtilisateurResponse
  {
    /// <summary>
    /// Les infos sur l'utilisateur
    /// </summary>
    public Utilisateur Utilisateur { get; set; }
  }
}
