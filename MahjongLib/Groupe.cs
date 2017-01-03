using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  public class Groupe
  {
    public Groupe()
    {
      this.Tuiles = new List<Tuile>();
      this.Combinaison = null;
      this.Expose = true; // par défaut c'est exposé
    }

    public List<Tuile> Tuiles { get; private set; }
    public Combinaison Combinaison { get; private set; }
    public bool Expose { get; set; }

    public bool Complet
    {
      get
      {
        return this.Tuiles.Count >= 3;
      }
    }

    public int TotalPoint
    {
      get
      {
        return this.Combinaison == null ? 0 : this.Combinaison.NombrePoint(this.Expose);
      }
    }

    public Points Points(AnalyseParam param)
    {
      if (this.Combinaison != null)
      {
        param.Expose = this.Expose;
        return this.Combinaison.Points(this.Tuiles, param);
      }

      return MahjongLib.Points.Empty;
    }

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

    public void Compute(AnalyseParam param)
    {
      param.Expose = this.Expose;
      this.Combinaison = AnalyseCombinaison.Compute(this.Tuiles, param);
    }

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
  }
}
