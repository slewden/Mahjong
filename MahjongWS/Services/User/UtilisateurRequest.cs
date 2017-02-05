using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongWS.Services.User
{
  /// <summary>
  /// Classe requete pour l'édition d'un utilisateur (par lui même)
  /// </summary>
  [Api("Mahjong")]
  [Route("/utilisateur/{ApiKey}/", Verbs = "POST")]
  [Route("/utilisateur/{ApiKey}/", Verbs = "GET")]
  public class UtilisateurRequest : RequestBase, IReturn<UtilisateurResponse>
  {
    /// <summary>
    /// Le nom de l'utilisateur
    /// </summary>
    public string Nom { get; set; }

    /// <summary>
    /// Désactive l'utilisateur si true
    /// </summary>
    public bool DesactiveMoi { get; set; }

    /// <summary>
    /// Efface la photo de l'utilisateur si true
    /// </summary>
    public bool EffacePhoto { get; set; }
  }
}
