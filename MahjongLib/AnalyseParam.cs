using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  /// <summary>
  /// Paramètre pour une analyse de main
  /// </summary>
  public class AnalyseParam
  {
    /// <summary>
    /// Le rang du vent du joueur concerné
    /// </summary>
    public int RangVentJoueur { get; set; }

    /// <summary>
    /// Le rang du vent dominant
    /// </summary>
    public int RangVentDominant { get; set; }

    /// <summary>
    /// Le rang du vent du tour
    /// </summary>
    public int RangVentDuTour { get; set; }

    /// <summary>
    /// la combinaison courante est exposée ou masquée
    /// </summary>
    public bool Expose { get; set; }

    /// <summary>
    /// le joueur qui a fait majhong l'a fait avec une tuile du mur
    /// </summary>
    public bool MahjongAvecTuileDuMur { get; set; }

    /// <summary>
    /// le joueur qui a fait majhong l'a fait avec la dernière tuile du mur
    /// </summary>
    public bool MahjongAvecDerniereTuileDuMur { get; set; }

    /// <summary>
    /// le joueur qui a fait majhong l'a fait en vollant un kong exposé
    /// </summary>
    public bool MahjongEnVolantKongExpose { get; set; }
  }
}
