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

    /// <summary>
    /// Le nom du joueur
    /// </summary>
    public string Nom { get; private set; }

    /// <summary>
    /// Position du joueur dans les mains de chaque manche
    /// </summary>
    public int Position { get; private set; }

    public Vent? VentDuJoueurPourLeTour { get; set; }

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
  }
}
