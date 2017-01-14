using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  /// <summary>
  /// Pour comptabiliser les point
  /// </summary>
  public class Points
  {
    /// <summary>
    /// Renvoie un point vide
    /// </summary>
    public static Points Empty
    {
      get
      {
        return new Points();
      }
    }

    #region ^Properties
    /// <summary>
    /// Nombre de points (avant mahjong)
    /// </summary>
    public int Nombre { get; set; }

    /// <summary>
    /// Nombre double (avant mahjong)
    /// </summary>
    public int Doubles { get; set; }

    /// <summary>
    /// Nombre de points (appliqués après mahjong)
    /// </summary>
    public int NombreMahjong { get; set; }

    /// <summary>
    /// Nombre de doubles (appliqués après mahjong)
    /// </summary>
    public int DoublesMahjong { get; set; }

    /// <summary>
    /// Le nombre de combinaisons trouvées dans la main d'un joueur
    /// </summary>
    public int NombreCombinaison { get; set; }

    /// <summary>
    /// Le nombre de paires trouvées dans la main d'un joueur
    /// </summary>
    public int NombrePaire { get; set; }
    #endregion

    #region Computed properties
    /// <summary>
    /// Renvoie le nombre total de points
    /// </summary>
    public int Total
    {
      get
      {
        return ((this.Nombre * Convert.ToInt32(Math.Pow(2, this.Doubles))) + this.NombreMahjong) * Convert.ToInt32(Math.Pow(2, this.DoublesMahjong));
      }
    }

    /// <summary>
    /// Renvoie true si le total correspond à un mahjong
    /// </summary>
    public bool Mahjong
    {
      get
      {
        return this.NombreCombinaison == 4 && this.NombrePaire == 1;
      }
    }
    #endregion
  }
}
