using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  /// <summary>
  /// Infos de base pour compter les combinaisons
  /// </summary>
  public class PointsBase
  {
    /// <summary>
    /// Renvoie un point vide
    /// </summary>
    public static PointsBase Empty
    {
      get
      {
        return new PointsBase();
      }
    }

    /// <summary>
    /// Le nombre de combinaisons trouvées dans la main d'un joueur
    /// </summary>
    public int NombreCombinaison { get; set; }

    /// <summary>
    /// Le nombre de paires trouvées dans la main d'un joueur
    /// </summary>
    public int NombrePaire { get; set; }

    /// <summary>
    /// le nombre de tuiles compatibilisées
    /// </summary>
    public int NombreTuileComptees { get; set; }

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
  }
}
