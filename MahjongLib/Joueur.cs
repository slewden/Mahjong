using System.Text;

namespace MahjongLib
{
  /// <summary>
  /// Un joueur
  /// </summary>
  public class Joueur
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Joueur"/>
    /// </summary>
    /// <param name="nom">Le nom</param>
    /// <param name="position">la position du joueur dans les mains</param>
    internal Joueur(string nom, int position)
    {
      this.Nom = nom;
      this.Position = position;
      this.VentDuJoueurPourLeTour = null;
    }

    #region Properties
    /// <summary>
    /// Le nom du joueur
    /// </summary>
    public string Nom { get; private set; }

    /// <summary>
    /// Position du joueur dans le stockage des mains de chaque manche
    /// </summary>
    public int Position { get; private set; }

    /// <summary>
    /// Renvoie le vent du joueur pour le tour en cours
    /// </summary>
    public Vent? VentDuJoueurPourLeTour { get; set; }
    #endregion

    /// <summary>
    /// Pour affichage
    /// </summary>
    /// <returns>le nom du joueur</returns>
    public override string ToString()
    {
      if (this.VentDuJoueurPourLeTour == null)
      {
        return this.Nom;
      }
      else
      {
        return string.Format("{0} ({1})", this.Nom, this.VentDuJoueurPourLeTour);
      }
    }

    /// <summary>
    /// Pour les comparaisons
    /// </summary>
    /// <param name="obj">l'objet à comparer</param>
    /// <returns>true si c'est les même</returns>
    public override bool Equals(object obj)
    {
      Joueur j = obj as Joueur;
      if ((object)j != null)
      {
        return this.Nom.Equals(j.Nom);
      }

      return false;
    }

    /// <summary>
    /// Pour les tris
    /// </summary>
    /// <returns>le code de hash</returns>
    public override int GetHashCode()
    {
      return this.Nom.GetHashCode();
    }

    /// <summary>
    /// Renvoie Le Json de l'objet
    /// </summary>
    /// <returns>Le Json de l'objet</returns>
    internal string ToJson()
    {
      StringBuilder res = new StringBuilder();
      res.Append("{");
      res.AppendFormat("\"nom\":\"{0}\"", this.Nom.Replace("\"", "\\\""));
      res.AppendFormat(", \"position\":{0}", this.Position);
      ////if (this.VentDuJoueurPourLeTour != null)
      ////{
      ////  res.AppendFormat(",\"ventDuJoueurPourLeTour\":{0}", (int)this.VentDuJoueurPourLeTour.Value);
      ////}

      res.Append("}");
      return res.ToString();
    }
  }
}
