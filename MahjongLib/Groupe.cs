using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MahjongLib
{
  /// <summary>
  /// Un groupe de tuiles d'une main
  /// </summary>
  public class Groupe
  {
    /// <summary>
    /// Les tuiles sont exposées ou masquées
    /// </summary>
    private bool expose;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Groupe"/>
    /// </summary>
    public Groupe()
    {
      this.Tuiles = new List<Tuile>();
      this.Combinaison = null;
      this.Expose = true; // par défaut c'est exposé
    }

    #region Properties
    /// <summary>
    /// La liste des tuiles qui composent le groupe
    /// </summary>
    public List<Tuile> Tuiles { get; private set; }

    /// <summary>
    /// La combinaison obtenue
    /// </summary>
    public Combinaison Combinaison { get; private set; }

    /// <summary>
    /// Les tuiles sont exposées ou masquées
    /// </summary>
    public bool Expose 
    {
      get
      {
        return this.expose;
      }
      
      set
      {
        this.expose = value;
        this.Tuiles.ForEach(x => x.Exposee = value);
      }
    }

    /// <summary>
    /// Le nombre de tuiles à prendre en compte pour compter si la main est ok
    /// </summary>
    public int NombreTuilePriseEnCompte
    {
      get
      {
        if (this.Combinaison == null)
        {
          return this.Tuiles.Count;
        }
        else
        {
          return Math.Min(this.Combinaison.NombreTuilesComptees, 3);
        }
      }
    }
    #endregion

    #region Computed Properties
    /// <summary>
    /// La combinaison est complète ou pas
    /// </summary>
    public bool Complet
    {
      get
      {
        return this.Tuiles.Count >= 3;
      }
    }

    /// <summary>
    /// renvoie le total des points
    /// </summary>
    public int TotalPoint
    {
      get
      {
        return this.Combinaison == null ? 0 : this.Combinaison.NombrePoint(this.Expose);
      }
    }

    /// <summary>
    /// Type de combinaison du groupe
    /// </summary>
    public PointsBase TypeDeCombinaison
    {
      get
      {
        if (this.Combinaison != null)
        {
          return this.Combinaison.TypeDeCombinaison;
        }

        return MahjongLib.PointsBase.Empty;
      }
    }
    #endregion

    /// <summary>
    /// Renvoie les points du groupe
    /// </summary>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>Les points</returns>
    public Points Points(AnalyseParam param)
    {
      if (this.Combinaison != null)
      {
        param.Expose = this.Expose;
        return this.Combinaison.Points(this.Tuiles, param);
      }

      return MahjongLib.Points.Empty;
    }

    /// <summary>
    /// Pour affichage
    /// </summary>
    /// <returns>le texte a afficher</returns>
    public override string ToString()
    {
      if (this.Tuiles.Any())
      {
        if (this.Combinaison != null)
        {
          string s;
          if (this.Expose)
          {
            s = this.Tuiles.Select(x => x.Code).Aggregate((x, y) => x + " " + y);
          }
          else
          { // masque la dernière tuile : on l'utilise pas Linq ici car les tuiles sont souvent identiques !
            StringBuilder res = new StringBuilder();
            for (int i = 0; i <= this.Tuiles.Count - 2; i++)
            {
              res.AppendFormat("{0} ", this.Tuiles[i].Code);
            }

            res.Append(TuileHelper.HidenTuile);
            s = res.ToString();
          }

          int n = this.Combinaison.NombrePoint(this.Expose);
          return string.Format("{0} {1}", s, n);
        }
        else
        {
          return this.Tuiles.Select(x => x.Code).Aggregate((x, y) => x + " " + y);
        }
      }
      else
      {
        return string.Empty;
      }
    }

    /// <summary>
    /// Le libellé décriptif
    /// </summary>
    /// <returns>le texte a afficher</returns>
    public string Libelle()
    {
      if (this.Tuiles.Any())
      {
        if (this.Combinaison != null)
        {
          int n = this.Combinaison.NombrePoint(this.Expose);
          return string.Format("{0} {1} : {2} {3}", this.Combinaison.Nom, this.Expose ? "Exposée" : "Cachée", n, n > 1 ? "points" : "point");
        }
        else
        {
          return this.Tuiles.Select(x => x.Code).Aggregate((x, y) => x + " " + y);
        }
      }
      else
      {
        return string.Empty;
      }
    }

    /// <summary>
    /// indique si l'on peut ajouter le tuile
    /// </summary>
    /// <param name="tuile">la tuile</param>
    /// <param name="param">les paramètres de l'analyseur</param>
    /// <param name="avecShow">Autorise les show</param>
    /// <returns>true si l'on peut</returns>
    public bool CanAdd(Tuile tuile, AnalyseParam param, bool avecShow = true)
    {
      if (tuile == null)
      {
        return false;
      }

      if (this.Tuiles.Count == 4)
      { // combinaison pas pleine
        return false;
      }

      if (this.Tuiles.Count == 0)
      { // pas de tuile on peut donc toujours en ajouter une
        return true;
      }

      Tuile t = this.Tuiles.First();
      if (t.Famille != tuile.Famille)
      { // pas la même famille ==> pas de combinaison possible
        return false;
      }

      Combinaison cb = this.Compute(tuile, param);
      if (cb != null)
      { // l'ajout de la tuile amène à une combinaison
        return true;
      }

      if (this.Tuiles.Count >= 2)
      { // l'ajout d'une 3ième ou 4ième tuile qui n'amène pas à une combinaison ==> on refuse
        return false;
      }

      if (this.Combinaison != null)
      { // l'ajout de la tuile fait perdre la combinaison
        return false;
      }

      // on a 1 seule tuile et pas encore de combinaison : on laisse faire
      // seul cas possibles : paire ou début d'une suite soit [x, x+1] ou [x, x+2]
      if (t.Rang == tuile.Rang)
      { // paire non valorisée
        return true;
      }

      if (avecShow)
      {
        if (t.Rang == tuile.Rang + 1 || t.Rang == tuile.Rang - 1 || t.Rang == tuile.Rang + 2 || t.Rang == tuile.Rang - 2)
        { // début de suite
          return true;
        }
      }

      return false;
    }

    /// <summary>
    /// tente d'ajouter une tuile au groupe et indique si c'est fait
    /// </summary>
    /// <param name="tuile">La tuile</param>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>true si la tuile a été ajoutée</returns>
    public bool Add(Tuile tuile, AnalyseParam param)
    {
      if (this.CanAdd(tuile, param))
      { // on peut l'ajouter
        if (this.Tuiles.Count == 0 || this.Tuiles.First().Famille == tuile.Famille)
        {
          tuile.Exposee = this.Expose;
          this.Tuiles.Add(tuile);
          this.Combinaison = this.Compute(null, param);
          if (this.Combinaison != null)
          {
            this.Tuiles = this.Tuiles.OrderBy(x => x.Rang).ToList();
          }

          return true;
        }
      }

      return false;
    }

    /// <summary>
    /// tente de retirer la tuile du groupe et indique si c'est fait
    /// </summary>
    /// <param name="tuile">La tuile</param>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>True si la tuile a été retrouvée</returns>
    public bool Remove(Tuile tuile, AnalyseParam param)
    {
      if (this.Tuiles.Contains(tuile))
      {
        this.Tuiles.Remove(tuile);
        tuile.Exposee = false;
        this.Combinaison = this.Compute(null, param);
        return true;
      }

      return false;
    }

    /// <summary>
    /// Met à jour la combinaison avec les nouveaux paramètres d'analyse
    /// </summary>
    /// <param name="param">les nouveaux paramètres d'analyse</param>
    public void UpdateCombinaison(AnalyseParam param)
    {
      this.Combinaison = this.Compute(null, param);
    }

    /// <summary>
    /// Renvoie Le Json de l'objet
    /// </summary>
    /// <returns>Le Json de l'objet</returns>
    public string ToJson()
    {
      StringBuilder res = new StringBuilder();
      res.Append("{");
      res.AppendFormat("\"expose\":{0}", this.Expose ? "true" : "false");
      if (this.Tuiles.Any())
      {
        res.Append(",\"tuiles\":[");
        res.Append(this.Tuiles.GroupBy(x => x).Select(x => x.Key.ToJson(x.Count())).Aggregate((x, y) => x + "," + y));
        res.Append("]");
      }

      res.Append("}");
      return res.ToString();
    }
    
    /// <summary>
    /// Calcule la combinaison possible
    /// </summary>
    /// <param name="tuile">La tuiles supplémentaire à prendre en compte</param>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>la combinaison trouvée</returns>
    private Combinaison Compute(Tuile tuile, AnalyseParam param)
    {
      List<Tuile> lst = new List<Tuile>();
      lst.AddRange(this.Tuiles);
      if (tuile != null)
      {
        lst.Add(tuile);
      }

      param.Expose = this.Expose;
      return AnalyseCombinaison.Compute(lst, param);
    }
  }
}
