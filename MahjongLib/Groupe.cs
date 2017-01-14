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
    public bool Expose { get; set; }
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
    /// Calcule la combinaison possible
    /// </summary>
    /// <param name="param">les paramètres d'analyse</param>
    public void Compute(AnalyseParam param)
    {
      param.Expose = this.Expose;
      this.Combinaison = AnalyseCombinaison.Compute(this.Tuiles, param);
    }

    /// <summary>
    /// tente d'ajouter une tuile au groupe et indique si c'est fait
    /// </summary>
    /// <param name="tuile">La tuile</param>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>true si la tuile a été ajoutée</returns>
    internal bool Add(Tuile tuile, AnalyseParam param)
    {
      if (this.Tuiles.Count < 4)
      {
        bool isCombinaisonAvant = this.Combinaison != null;
        this.Tuiles.Add(tuile);
        this.Compute(param);
        if (this.Combinaison == null && isCombinaisonAvant)
        { // la tuile ajouté fait perdre la combinaison ==> on empèche cela
          this.Tuiles.Remove(tuile);
          this.Compute(param);
          return false;
        }

        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// tente de retirer la tuile du groupe et indique si c'est fait
    /// </summary>
    /// <param name="tuile">La tuile</param>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>True si la tuile a été retrouvée</returns>
    internal bool Remove(Tuile tuile, AnalyseParam param)
    {
      if (this.Tuiles.Contains(tuile))
      {
        this.Tuiles.Remove(tuile);
        this.Compute(param);
        return true;
      }

      return false;
    }

    /// <summary>
    /// Renvoie Le Json de l'objet
    /// </summary>
    /// <returns>Le Json de l'objet</returns>
    internal string ToJson()
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
  }
}
