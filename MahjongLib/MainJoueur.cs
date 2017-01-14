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
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="MainJoueur"/>
    /// </summary>
    /// <param name="j">le joueur</param>
    /// <param name="numTour">le numero du tour</param>
    /// <param name="numManche">le numero de la manche</param>
    public MainJoueur(Joueur j, int numTour, int numManche)
    {
      this.Joueur = j;
      this.NumeroTour = numTour;
      this.NumeroManche = numManche;
      this.Groupes = new List<Groupe>();
    }

    #region Properties
    /// <summary>
    /// Le joueur concerné
    /// </summary>
    public Joueur Joueur { get; private set; }

    /// <summary>
    /// Le numero du tour
    /// </summary>
    public int NumeroTour { get; private set; }

    /// <summary>
    /// Le numero de la manche
    /// </summary>
    public int NumeroManche { get; private set; }

    /// <summary>
    /// Les groupes de tuiles
    /// </summary>
    public List<Groupe> Groupes { get; private set; }
    #endregion 

    #region Computed properties
    /// <summary>
    /// la saisie est complète
    /// </summary>
    public bool Complete
    {
      get
      {
        return this.Groupes.Select(x => x.Tuiles.Count()).Sum() >= 13;
      }
    }
    #endregion

    /// <summary>
    /// Renvoie le total des points de la main
    /// </summary>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>le total des points</returns>
    public Points TotalPoints(AnalyseParam param)
    {
      if (this.Groupes.Any())
      {
        Points pts = this.Groupes.Select(x => x.Points(param)).Sum();

        if (pts.Mahjong)
        { // mahjong détecté ==> points supplémentaires
          pts.NombreMahjong += 20; // +20 pour mahjong
          if (this.Groupes.Where(x => x.Combinaison != null && x.Combinaison is Combinaison.Show).Count() == 4)
          { // le mahjong est entièrement composé de séquences et d'une paire
            pts.NombreMahjong += 10;
          }

          if (param.MahjongAvecTuileDuMur)
          { // mahjong avec une tuile du mur +5
            pts.NombreMahjong += 5;
          }

          if (this.Groupes.Where(x => x.Combinaison != null && x.Combinaison is Combinaison.Show).Count() == 0)
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

          if (this.Groupes.Where(x => x.Combinaison != null && x.Combinaison.Famille.HasValue).Select(x => x.Combinaison.Famille.Value).Where(f => f.IsOrdinaire()).Distinct().Count() == 1)
          { // main pure
            pts.DoublesMahjong += 3;
          }
        }

        return pts;
      }

      return Points.Empty;
    }

    /// <summary>
    /// Renvoie Le Json de l'objet
    /// </summary>
    /// <returns>Le Json de l'objet</returns>
    internal string ToJson()
    {
      StringBuilder res = new StringBuilder();
      res.Append("{");
      res.AppendFormat("\"idxJoueur\":{0}", this.Joueur.Position);
      ////res.AppendFormat(",\"numeroTour\":{0}", this.NumeroTour);
      ////res.AppendFormat(",\"numeroManche\":{0}", this.NumeroManche);
      if (this.Groupes.Any())
      {
        res.AppendFormat(",\"groupes\":[{0}]", this.Groupes.Select(x => x.ToJson()).Aggregate((x, y) => x + "," + y));
      }

      res.Append("}");
      return res.ToString();
    }
  }
}
