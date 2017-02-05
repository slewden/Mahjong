using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using MahjongWS.Core;
using System.IO;

namespace MahjongWS.Services.User
{
  /// <summary>
  /// Classe pour l'édition des propriété d'un utilisateur
  /// </summary>
  public class UtilisateurService : ServiceBase
  {
    /// <summary>
    /// Renvoie les infos sur l'utilisateur
    /// </summary>
    /// <param name="request">la requete</param>
    /// <returns>la réponse</returns>
    public object Get(UtilisateurRequest request)
    {
      var err = this.Verification(request);
      if (err != null)
      {
        return err;
      }

      return new UtilisateurResponse() { Utilisateur = this.Utilisateur };
    }

    /// <summary>
    /// Post = mise à jour des données d'un user
    /// </summary>
    /// <param name="request">La requete</param>
    /// <returns>la réponse</returns>
    public object Post(UtilisateurRequest request)
    {
      var err = this.Verification(request);
      if (err != null)
      {
        return err;
      }

      bool needSave = false;

      if (!string.IsNullOrWhiteSpace(request.Nom))
      { // Y a un nom
        if (this.Utilisateur.Nom != request.Nom)
        { // il est différent de celui du user
          needSave = true;
          this.Utilisateur.Nom = request.Nom;
        }
      }

      if (request.DesactiveMoi)
      { // le user veut être désactivé
        needSave = true;
        this.Utilisateur.Actif = false;
      }

      if (request.EffacePhoto)
      { // le user veux effacer la photo actuelle
        needSave = true;
        UtilisateurService.DeleteFile(request.ApiKey);
        this.Utilisateur.Logo = string.Empty;
      }

      // Upload de la photo si elle est la
      var uploadedFile = Request.Files.Where(x => x.ContentLength > 0).FirstOrDefault();
      if (uploadedFile != null)
      {
        needSave = true;
        // Pas besoin d'effacer l'ancienne la nouvelle l'écrasera
        this.Utilisateur.Logo = UtilisateurService.WriteFile(uploadedFile.InputStream, request.ApiKey);
      }
      
      if (needSave)
      { // mise à jour du user en Base de dans l'application
        MahjongWS.Services.Utilisateur.Update(this.Db, this.Utilisateur);
      }

      return new UtilisateurResponse() { Utilisateur = this.Utilisateur };
    }

    #region Static utils
    /// <summary>
    /// Attibue un nom à la photo et la sauve sur dique
    /// </summary>
    /// <param name="ms">le flux à sauver</param>
    /// <param name="apiKey">La clé de l'utilisateur</param>
    /// <returns>le nom attribué sans le chemin</returns>
    private static string WriteFile(Stream ms, string apiKey)
    {
      string fileName = string.Format("Photo-{0}.png", apiKey);
      string fullFileName = Folder.FullPath(Folder.EFolder.Utilisateur, fileName);
      using (var fich = File.Create(fullFileName))
      {
        ms.Position = 0;
        ms.CopyTo(fich);
      }

      return fileName;
    }

    /// <summary>
    /// Supprime la photo d'un utilisateur
    /// </summary>
    /// <param name="apiKey">La clé de l'utilisateur</param>
    private static void DeleteFile(string apiKey)
    {
      string fileName = string.Format("Photo-{0}.png", apiKey);
      string fullFileName = Folder.FullPath(Folder.EFolder.Utilisateur, fileName);
      if (File.Exists(fullFileName))
      {
        try
        {
          File.Delete(fullFileName);
        }
        catch
        {
        }
      }
    }
    #endregion
  }
}
