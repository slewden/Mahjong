using System.Collections.Generic;
using System.Linq;

namespace MahjongLib
{
  /// <summary>
  /// Classe statique pour les calculs avec des points
  /// </summary>
  public static class PointHelper
  {
    /// <summary>
    /// Additionne deux points
    /// </summary>
    /// <param name="points">la liste des points a additionner</param>
    /// <returns>le point résultat</returns>
    public static Points Sum(this IEnumerable<Points> points)
    {
      return new Points()
      {
        Nombre = points.Select(x => x.Nombre).Sum(),
        Doubles = points.Select(x => x.Doubles).Sum(),
        NombreCombinaison = points.Select(x => x.NombreCombinaison).Sum(),
        NombrePaire = points.Select(x => x.NombrePaire).Sum(),
        DoublesMahjong = points.Select(x => x.DoublesMahjong).Sum(),
        NombreMahjong = points.Select(x => x.NombreMahjong).Sum()
      };
    }
  }
}
