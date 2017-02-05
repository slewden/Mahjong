﻿using Funq;
using ServiceStack.Common.Web;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.ServiceHost;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace MahjongWS.Services
{
  /// <summary>
  /// Class pour le host des services
  /// </summary>
  public class AppHost : AppHostBase
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="AppHost" />
    /// </summary>
    public AppHost()
      : base("Mahjong HttpListener", typeof(AppHost).Assembly)
    {
    }

    /// <summary>
    /// Configuration du host
    /// </summary>
    /// <param name="container">COntainer de la config</param>
    public override void Configure(Container container)
    {
      // Configuration du JSON de sortie
      JsConfig.EmitCamelCaseNames = true;
      JsConfig.DateHandler = JsonDateHandler.DCJSCompatible;

      var cnx = System.Configuration.ConfigurationManager.ConnectionStrings["mahjong"];
      if (cnx == null)
      {
        throw new System.Exception("La chaine de connexion 'mahjong' est inexistante dans le fichier de configuration web.config");
      }

      container.Register<IDbConnectionFactory>(new OrmLiteConnectionFactory(
                                                 cnx.ToString(),
                                                 SqlServerOrmLiteDialectProvider.Instance));

      ResponseFilters.Add((httpReq, httpResp, responseDto) =>
      {
        httpResp.AddHeader("Expires", "0");
        httpResp.AddHeader(HttpHeaders.CacheControl, "max-age=0");
      });
    }

    /// <summary>Fonction utilisé pour compresser les flux de réponse</summary>
    /// <typeparam name="TRequest">Type de la request</typeparam>
    /// <param name="actionContext">Context action</param>
    /// <returns>J'en sais rien ?</returns>
    public override IServiceRunner<TRequest> CreateServiceRunner<TRequest>(ActionContext actionContext)
    {
      return new MyServiceRunner<TRequest>(this, actionContext);
    }
  }
}
