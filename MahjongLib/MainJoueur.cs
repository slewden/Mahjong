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
    /// Le nombre de tuiles (à comptabiliser) dans la main
    /// </summary>
    public int NombreTuilePriseEnCompte
    {
      get
      {
        return this.Groupes.Select(x => x.NombreTuilePriseEnCompte).Sum();
      }
    }

    /// <summary>
    /// Renvoie les combinaisons de la main
    /// </summary>
    public PointsBase TypeDeCombinaison
    {
      get
      {
        if (this.Groupes.Any())
        {
          return this.Groupes.Select(x => x.TypeDeCombinaison).Sum();
        }
        else
        {
          return PointsBase.Empty;
        }
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
      return MainJoueur.TotalPointsInternal(this.Groupes, param);
    }

    /// <summary>
    /// Essaie des combinaisons différentes
    /// </summary>
    /// <param name="param">Paramètres d'analyse</param>
    public void Shake(AnalyseParam param)
    {
      this.Shake(param, false);
      this.Shake(param, true);
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
      if (this.Groupes.Any())
      {
        res.AppendFormat(",\"groupes\":[{0}]", this.Groupes.Select(x => x.ToJson()).Aggregate((x, y) => x + "," + y));
      }

      res.Append("}");
      return res.ToString();
    }

    /// <summary>
    /// Calcul le total des point de la liste de combinaisons
    /// </summary>
    /// <param name="groupes">la liste des groupes de combinaisons a anlyser</param>
    /// <param name="param">Paramètres d'analyse</param>
    /// <returns>les points</returns>
    private static Points TotalPointsInternal(List<Groupe> groupes, AnalyseParam param)
    {
      if (groupes.Any())
      {
        Points pts = groupes.Select(x => x.Points(param)).Sum();

        if (pts.Mahjong)
        { // mahjong détecté ==> points supplémentaires
          pts.NombreMahjong += 20; // +20 pour mahjong
          pts.Motifs.Add("+20 Mahjong");

          if (groupes.Where(x => x.Combinaison != null && x.Combinaison is Combinaison.Show).Count() == 4)
          { // le mahjong est entièrement composé de séquences et d'une paire
            pts.NombreMahjong += 10;
            pts.Motifs.Add("+10 que des show");
          }

          if (param.MahjongAvecTuileDuMur)
          { // mahjong avec une tuile du mur +5
            pts.NombreMahjong += 5;
            pts.Motifs.Add("+5 Mahjong avec une tuile du mur");
          }

          if (groupes.Where(x => x.Combinaison != null && x.Combinaison is Combinaison.Show).Count() == 0)
          { // aucune séquence
            pts.DoublesMahjong += 1;
            pts.Motifs.Add("1 double : Aucun show");
          }

          if (param.MahjongAvecDerniereTuileDuMur)
          { // mahjong avec derniere tuile du mur
            pts.DoublesMahjong += 1;
            pts.Motifs.Add("1 double : Mahjong avec la dernière tuile du mur");
          }

          if (param.MahjongEnVolantKongExpose)
          { // mahjong en vollant un kong exposé
            pts.DoublesMahjong += 1;
            pts.Motifs.Add("1 double : Mahjong en volant un kong exposé");
          }

          if (groupes.Where(x => x.Combinaison != null && Combinaison.IsBrelanOuCarreMajeur(x.Combinaison)).Count() == 4)
          { // 4 brelans ou carré de tuiles majeures
            pts.DoublesMahjong += 1;
            pts.Motifs.Add("1 double : 4 Pung ou Kong de tuiles majeures");
          }

          if (groupes.Where(x => x.Combinaison != null && x.Combinaison.Famille.HasValue).Select(x => x.Combinaison.Famille.Value).Where(f => f.IsOrdinaire()).Distinct().Count() <= 1)
          { // main pure
            pts.DoublesMahjong += 3;
            pts.Motifs.Add("3 doubles : Main pure");
          }
        }

        return pts;
      }

      return Points.Empty;
    }

    /// <summary>
    /// Mélange les groupes pour trouver les meilleures combinaisons
    /// </summary>
    /// <param name="param">Les paramètres d'analyse</param>
    /// <param name="avecShow">avec les show</param>
    private void Shake(AnalyseParam param, bool avecShow)
    {
      Points pt = this.TotalPoints(param);
      List<Tuile> list = new List<Tuile>();
      foreach (Groupe g in this.Groupes)
      {
        list.AddRange(g.Tuiles);
      }

      List<Groupe> grps = new List<Groupe>();
      Groupe grp = null;
      foreach (Tuile t in list.OrderBy(x => x.Famille).ThenBy(x => x.Rang))
      {
        if (grp != null && grp.CanAdd(t, param, avecShow))
        {
          grp.Expose |= t.Exposee;
          grp.Tuiles.Add(t);
        }
        else
        {
          grp = new Groupe();
          grps.Add(grp);
          grp.Expose = t.Exposee;
          grp.Tuiles.Add(t);
        }
      }

      foreach (var grp2 in grps.Where(x => x.Tuiles.Any()))
      {
        grp2.UpdateCombinaison(param);
      }

      if (avecShow)
      { // on a le droit aux show
        // phase un on récupère les tuiles des groupes qui sont incomplet
        list = new List<Tuile>();
        foreach (Groupe g in grps.Where(x => x.Combinaison == null))
        {
          list.AddRange(g.Tuiles);
          g.Tuiles.Clear();
        }

        grp = null;
        foreach (Tuile t in list.OrderBy(x => x.Famille).ThenBy(x => x.Rang))
        {
          grp = grps.Where(x => x.CanAdd(t, param, false)).FirstOrDefault();
          if (grp != null)
          {
            grp.Expose |= t.Exposee;
            grp.Tuiles.Add(t);
          }
          else
          {
            grp = new Groupe();
            grps.Add(grp);
            grp.Expose = t.Exposee;
            grp.Tuiles.Add(t);
          }
        }

        foreach (var grp2 in grps.Where(x => x.Tuiles.Any()))
        {
          grp2.UpdateCombinaison(param);
        }
      }

      Points pt2 = MainJoueur.TotalPointsInternal(grps, param);
      if (pt2 > pt)
      { // y a un gain on fait
        this.Groupes = grps.Where(x => x.Tuiles.Any()).ToList();
      }
    }
  }
}
