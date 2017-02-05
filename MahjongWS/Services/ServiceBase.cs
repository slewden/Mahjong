using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceInterface;
using System.Net;
using ServiceStack.OrmLite;
using ServiceStack.Common.Web;

namespace MahjongWS.Services
{
  /// <summary>
  /// Classe de base pour les services
  /// </summary>
  public class ServiceBase : ServiceStack.ServiceInterface.Service
  {
    /// <summary>
    /// Utilisateur appellant le service
    /// </summary>
    public Utilisateur Utilisateur { get; set; }

    /// <summary>
    /// Vérifie que l'apiKey existe bien et est valide
    /// </summary>
    /// <param name="request">Les infos du request</param>
    /// <returns>HTTPError si pas bon, null sinon</returns>
    public HttpError Verification(RequestBase request)
    {
      if (string.IsNullOrWhiteSpace(request.ApiKey))
      {
        return new HttpError(HttpStatusCode.Forbidden, "Pas d'identifiant");
      }

      Utilisateur u = Utilisateur.IsAuthentified(request.ApiKey);
      if (u == null)
      { // le user n'est jamais venu depuis que l'application à démarré
        u = Utilisateur.Get(this.Db, request.ApiKey);
        if (u == null)
        { // le user n'existe pas en base
          Guid g;
          if (Guid.TryParse(request.ApiKey, out g))
          {
            u = new Services.Utilisateur() { ApiKey = g };
            this.Db.Insert<Utilisateur>(u);
            Utilisateur.Add(u);
          }
          else
          {
            return new HttpError(HttpStatusCode.Forbidden, "Identifiant invalide");
          }
        }
        else if (!u.Actif)
        { // le user a été désactivé de la base
          return new HttpError(HttpStatusCode.Forbidden, "Uitlisateur désactivé");
        }
      }

      this.Utilisateur = u;
      return null;
    }
  }
}
