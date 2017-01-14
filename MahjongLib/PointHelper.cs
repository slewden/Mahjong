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
      Points pts = new Points()
                          {
                            Nombre = points.Select(x => x.Nombre).Sum(),
                            DoublesMotif = new DoubleMotif() { Double = points.Select(x => x.Doubles).Sum() },
                            NombreCombinaison = points.Select(x => x.NombreCombinaison).Sum(),
                            NombrePaire = points.Select(x => x.NombrePaire).Sum(),
                            DoublesMahjong = points.Select(x => x.DoublesMahjong).Sum(),
                            NombreMahjong = points.Select(x => x.NombreMahjong).Sum()
                          };
      pts.Motifs.Clear();
      if (pts.Nombre > 0)
      {
        pts.Motifs.Add(string.Format("+{0} Points", pts.Nombre));
      }
      else 
      {
        pts.Motifs.Add("Aucun point");
      }

      points.Select(x => x.Motifs).ToList().ForEach(s => pts.Motifs.AddRange(s));

      return pts;
    }
  }
}
