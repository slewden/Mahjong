using System.Text;

namespace MahjongLib
{
  /// <summary>
  /// Définition d'un tuile du jeu
  /// </summary>
  public class Tuile
  {
    /// <summary>
    /// Le code de la tuile pour affichage
    /// </summary>
    private string leCode;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Tuile"/>
    /// </summary>
    /// <param name="nom">Le nom en français</param>
    /// <param name="code">Le code UNICODE étendu de la tuile</param>
    /// <param name="rang">Le rang (de 1 à 9 pour les common, de 1 à 4 pour les vents, fleurs ou saisons, de 1 à 3 pour les dragons</param>
    /// <param name="famille">La famille de la tuile</param>
    internal Tuile(string nom, string code, int rang, EFamille famille)
    {
      this.Nom = nom;
      this.leCode = code;
      this.Rang = rang;
      this.Famille = famille;
    }

    /// <summary>
    /// Le nom de la tuile
    /// </summary>
    public string Nom { get; private set; }

    /// <summary>
    /// Le code affichable de la tuile
    /// </summary>
    public string Code
    {
      get
      {
        return System.Text.RegularExpressions.Regex.Unescape(this.leCode);
      }
    }

    /// <summary>
    /// Le rang (de 1 à 9 pour les common, de 1 à 4 pour les vents, fleurs ou saisons, de 1 à 3 pour les dragons
    /// </summary>
    public int Rang { get; private set; }

    /// <summary>
    /// La famille de la tuile
    /// </summary>
    public EFamille Famille { get; private set; }

    /// <summary>
    /// La tuile est exposée
    /// </summary>
    public bool Exposee { get; set; }

    /// <summary>
    /// Pour affichage
    /// </summary>
    /// <returns>Le texte de la tuile</returns>
    public override string ToString()
    {
      return this.Code; ////+ " " + this.Nom;
    }

    /// <summary>
    /// Pour les coparaisions
    /// </summary>
    /// <param name="obj">L'objet à coparer</param>
    /// <returns>True si c'est les mêmes</returns>
    public override bool Equals(object obj)
    {
      Tuile t = obj as Tuile;
      if ((object)t != null)
      {
        return this.Famille == t.Famille && this.Rang == t.Rang;
      }

      return false;
    }

    /// <summary>
    /// Pour les tris
    /// </summary>
    /// <returns>Le code de hash</returns>
    public override int GetHashCode()
    {
      return string.Format("{0:d}-{1}", this.Famille, this.Rang).GetHashCode();
    }

    /// <summary>
    /// Renvoie Le Json de l'objet
    /// </summary>
    /// <param name="nombre">Nombre de fois ou l'on a cette tuile</param>
    /// <returns>Le Json de l'objet</returns>
    internal string ToJson(int nombre)
    {
      StringBuilder res = new StringBuilder();
      res.Append("{");
      res.AppendFormat("\"famille\":\"{0}\"", this.Famille);
      res.AppendFormat(",\"rang\":{0}", this.Rang);
      if (nombre > 1)
      {
        res.AppendFormat(",\"nombre\":{0}", nombre);
      }

      res.Append("}");
      return res.ToString();
    }
  }
}
