using System.Collections.Generic;

namespace MahjongLib.JsonLoader
{
  /// <summary>
  /// Classe pour comparer la présences d'attributs
  /// </summary>
  public class AttributLoadComparer : IEqualityComparer<JsonAttribut>
  {
    /// <summary>
    /// Pour les comparaisons
    /// </summary>
    /// <param name="x">premier élément à comparer</param>
    /// <param name="y">second élément à comparer</param>
    /// <returns>true si c'est le même</returns>
    public bool Equals(JsonAttribut x, JsonAttribut y)
    {
      if (x == null)
      {
        return y == null;
      }
      else if (y == null)
      {
        return false;
      }
      else
      {
        return x.Nom.Equals(y.Nom) && x.Type.Equals(y.Type);
      }
    }

    /// <summary>
    /// Renvoie le code de hash d'un attribut pour la comparaison
    /// </summary>
    /// <param name="obj">l'attribut a hasher</param>
    /// <returns>le code de hash</returns>
    public int GetHashCode(JsonAttribut obj)
    {
      if (obj == null)
      {
        return int.MinValue;
      }
      else
      {
        return (obj.Nom + "-" + obj.Type.ToString()).GetHashCode();
      }
    }
  }
}
