using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  /// <summary>
  /// Mémorise une main d'un joueur
  /// </summary>
  public class MainJoueur
  {

    public MainJoueur(Joueur j, int numTour, int numManche)
    {
      this.Joueur = j;
      this.NumeroTour = numTour;
      this.NumeroManche = numManche;
      this.Groupes = new List<Groupe>();
    }

    public Joueur Joueur { get; private set; }
    public int NumeroTour { get; private set; }
    public int NumeroManche { get; private set; }
    public List<Groupe> Groupes { get; private set; }

    public bool Complete
    {
      get
      {
        return this.Groupes.Select(x => x.Tuiles.Count()).Sum() >= 13;
      }
    }

    public Points TotalPoints(AnalyseParam param)
    {
      if (this.Groupes.Any())
      {
        Points pts = this.Groupes.Select(x => x.Points(param)).Sum();

        if (pts.Mahjong)
        { // mahjong détecté ==> points supplémentaires
          pts.NombreMahjong += 20; // +20 pour mahjong
          if (this.Groupes.Where(x => x.Combinaison != null && x.Combinaison is Show).Count() == 4)
          { // le mahjong est entièrement composé de séquences et d'une paire
            pts.NombreMahjong += 10;
          }

          if (param.MahjongAvecTuileDuMur)
          { // mahjong avec une tuile du mur +5
            pts.NombreMahjong += 5;
          }

          if (this.Groupes.Where(x => x.Combinaison != null && x.Combinaison is Show).Count() == 0)
          { // aucune séquence
            pts.DoublesMahjong += 1;
          }

          if (param.MahjongAvecDerniereTuileDuMur)
          { // mahjong avec derniere tuile du mur
            pts.DoublesMahjong += 1;
          }

          if (param.MahjongEnVolantKongExpose)
          { // mahjong en vollant un kong exposé
            pts.DoublesMahjong += 1; 
          }

          if (this.Groupes.Where(x => x.Combinaison != null && Combinaison.IsBrelanOuCarreMajeur(x.Combinaison)).Count() == 4)
          { // 4 brelans ou carré de tuiles majeures
            pts.DoublesMahjong += 1;
          }

          if (this.Groupes.Where(x => x.Combinaison != null && x.Combinaison.Famille.HasValue).Select(x => x.Combinaison.Famille.Value).Where(f => f.IsCommon()).Distinct().Count() == 1)
          { // main pure
            pts.DoublesMahjong += 3;
          }
        }

        return pts;
      }

      return Points.Empty;
    }
  }
}
