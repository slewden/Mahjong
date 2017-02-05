using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using MahjongWS.Core;

namespace MahjongWS.Services
{
  /// <summary>
  /// Un utilisateur connecté et authentifié
  /// </summary>
  [Alias("utilisateur")]
  public class Utilisateur
  {
    /// <summary>
    /// Les utilisateurs logés
    /// </summary>
    private static List<Utilisateur> lesUsers = null;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Utilisateur"/>
    /// </summary>
    public Utilisateur()
    {
      this.Actif = true;
    }

    #region Properties
    /// <summary>
    /// La clé d'authentification
    /// </summary>
    [Alias("ut_api_key")]
    public Guid ApiKey { get; set; }
    ////public string ApiKeyTxt { get; set; }

    /// <summary>
    /// Utilisateur activé ou pas
    /// </summary>
    [Alias("ut_actif")]
    public bool Actif { get; set; }

    /// <summary>
    /// Le nom de l'utilisateur
    /// </summary>
    [Alias("ut_nom")]
    public string Nom { get; set; }

    /// <summary>
    /// L'image associée à l'utilisateur
    /// </summary>
    [Alias("ut_picto")]
    public string Logo { get; set; }

    /// <summary>
    /// L'url d'accès à la photo
    /// </summary>
    [Ignore]
    public string LogoUrl
    {
      get
      {
        return Folder.RelativeUrl(Folder.EFolder.Utilisateur, this.Logo);
      }
    }

    ///// <summary>
    ///// La clé d'API Typé
    ///// </summary>
    //[Ignore]
    //public Guid ApiKey
    //{
    //  get
    //  {
    //    Guid g;
    //    if (!Guid.TryParse(this.ApiKeyTxt, out g))
    //    { // pas de guid on en crée un
    //      g = Guid.NewGuid();
    //      this.ApiKeyTxt = g.ToString();
    //    }

    //    return g;
    //  }

    //  set
    //  {
    //    this.ApiKeyTxt = value.ToString();
    //  }
    //}
    #endregion

    #region static methods
    /// <summary>
    /// Retrouve un utilisateur depuis sur cokkie
    /// </summary>
    /// <param name="db">Connexion à la base de données</param>
    /// <param name="apiKey">le guid d'authentification</param>
    /// <returns></returns>
    public static Utilisateur Get(IDbConnection db, string apiKey)
    {
      Guid g;
      if (Guid.TryParse(apiKey, out g))
      {
        return db.Select<Utilisateur>(x => x.ApiKey == g && x.Actif).FirstOrDefault();
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// Authentifie si le guidTxt est un utilisateur logé
    /// </summary>
    /// <param name="apiKey">Le guid en texte</param>
    /// <returns>L'utlisateur s'il est trouvé dans la liste des users authentifiés</returns>
    public static Utilisateur IsAuthentified(string apiKey)
    {
      if (string.IsNullOrWhiteSpace(apiKey) || Utilisateur.lesUsers == null || !Utilisateur.lesUsers.Any())
      { // pas d'info valide ou pas de user logé !
        return null;
      }

      Guid g;
      if (!Guid.TryParse(apiKey, out g))
      {
        return null;
      }

      return Utilisateur.lesUsers.Where(x => x.ApiKey == g).FirstOrDefault();
    }

    /// <summary>
    /// Ajoute un user à l'application
    /// </summary>
    /// <param name="user">L'utilisateur à ajouter</param>
    public static void Add(Utilisateur user)
    {
      if (Utilisateur.lesUsers == null)
      {
        Utilisateur.lesUsers = new List<Utilisateur>();
      }

      var u = Utilisateur.lesUsers.Where(x => x.ApiKey == user.ApiKey);
      if (!u.Any())
      {
        Utilisateur.lesUsers.Add(user);
      }
    }

    /// <summary>
    /// Retire un user de l'application
    /// </summary>
    /// <param name="user">L'utilisateur à retirer</param>
    public static void Remove(Utilisateur user)
    {
      if (Utilisateur.lesUsers == null || !Utilisateur.lesUsers.Any())
      { // on a rien à faire c'est vide
        return;
      }

      Utilisateur.lesUsers.Remove(user);
    }

    /// <summary>
    /// Met à jour l'utilisateur
    /// </summary>
    /// <param name="user">l'utilisateur à mettre à jour</param>
    public static void Update(IDbConnection db, Utilisateur user)
    {
      db.Update<Utilisateur>(user);
      Utilisateur.Remove(user);
      Utilisateur.Add(user);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Renvoie le code de hash
    /// </summary>
    /// <returns>le code de hash</returns>
    public override int GetHashCode()
    {
      return this.ApiKey.GetHashCode();
    }

    /// <summary>
    /// Pour les comparaisons
    /// </summary>
    /// <param name="obj">l'objet à comparer</param>
    /// <returns>True si c'est les même apikey</returns>
    public override bool Equals(object obj)
    {
      Utilisateur u = obj as Utilisateur;
      if ((object)u == null)
      {
        return false;
      }

      return this.ApiKey.Equals(u.ApiKey);
    }

    /// <summary>
    /// Renvoie le nom du user
    /// </summary>
    /// <returns>le nom du user</returns>
    public override string ToString()
    {
      if (string.IsNullOrEmpty(this.Nom))
      {
        return this.ApiKey.ToString();
      }
      else
      {
        return this.Nom;
      }
    }
    #endregion
  }
}
