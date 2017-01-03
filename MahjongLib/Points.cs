using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  public class Points
  {
    public static Points Empty
    {
      get
      {
        return new Points();
      }
    }

    public int Nombre { get; set; }
    public int Doubles { get; set; }

    public int NombreMahjong { get; set; }
    public int DoublesMahjong { get; set; }

    public int Total
    {
      get
      {
        return (this.Nombre * Convert.ToInt32(Math.Pow(2, this.Doubles)) + this.NombreMahjong) * Convert.ToInt32(Math.Pow(2, this.DoublesMahjong));
      }
    }
    public int NombreCombinaison { get; set; }
    public int NombrePaire { get; set; }
    public bool Mahjong
    {
      get
      {
        return this.NombreCombinaison == 4 && NombrePaire == 1;
      }
    }
  }

  public static class PointHelper
  {
    public static Points Sum(this IEnumerable<Points> points)
    {
      return new Points()
      {
        Nombre = points.Select(x => x.Nombre).Sum(),
        Doubles = points.Select(x => x.Doubles).Sum(),
        NombreCombinaison = points.Select(x => x.NombreCombinaison).Sum(),
        NombrePaire = points.Select(x => x.NombrePaire).Sum()
      };
    }
  }
}
