using MahjongWS.Core;
using MahjongWS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MahjongWeb
{
  /// <summary>
  /// Classe globale de l'application
  /// </summary>
  public class Global : System.Web.HttpApplication
  {
    /// <summary>
    /// Démarrage de l'application
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    protected void Application_Start(object sender, EventArgs e)
    {
      // s'assure que tous les dossiers sont opérationnels
      Folder.RegisterFolders(this.Server.MapPath("/"));

      // démarre les Web services
      var app = new AppHost();
      app.Init();
    }

    ////protected void Session_Start(object sender, EventArgs e)
    ////{

    ////}

    ////protected void Application_BeginRequest(object sender, EventArgs e)
    ////{

    ////}

    ////protected void Application_AuthenticateRequest(object sender, EventArgs e)
    ////{

    ////}

    ////protected void Application_Error(object sender, EventArgs e)
    ////{

    ////}

    ////protected void Session_End(object sender, EventArgs e)
    ////{

    ////}

    ////protected void Application_End(object sender, EventArgs e)
    ////{

    ////}
  }
}