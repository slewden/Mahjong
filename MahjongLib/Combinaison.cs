using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  public abstract class Combinaison
  {
    public Combinaison(ETypeCombinaison typeCombi, string nom, int pointVisible, int pointMasque, int nbTuiles)
    {
      this.TypeCombinaison = typeCombi;
      this.Nom = nom;
      this.NombrePointsSiVisible = pointVisible;
      this.NombrePointsSiMasque = pointMasque;
      this.NombreTuiles = nbTuiles;
    }

    public string Nom { get; private set; }
    public int NombrePointsSiVisible { get; private set; }
    public int NombrePointsSiMasque { get; private set; }
    public int NombreTuiles { get; private set; }
    public ETypeCombinaison TypeCombinaison { get; set; }
    public EFamille? Famille { get; protected set; }

    public int NombrePoint(bool expose)
    {
      return expose ? this.NombrePointsSiVisible : this.NombrePointsSiMasque;
    }

    public abstract bool Match(List<Tuile> tuiles, AnalyseParam param);
    ////public virtual Point MatchPoint(List<Tuile> tuiles, AnalyseParam param)
    ////{
    ////  if (this.Match(tuiles, param))
    ////  {
    ////    Point p = new Point();
    ////    p.Nombre = param.Expose ? this.NombrePointsSiVisible : this.NombrePointsSiMasque;
    ////    p.Double = NombreDouble(tuiles, param);
    ////    return p;
    ////  }

    ////  return Point.Empty;
    ////}
    public abstract int NombreDouble(List<Tuile> tuiles, AnalyseParam param);

    public Points Points(List<Tuile> tuiles, AnalyseParam param)
    {
      return new Points()
      {
        Nombre = this.NombrePoint(param.Expose),
        Doubles = this.NombreDouble(tuiles, param),
        NombreCombinaison = this.NombreTuiles >= 3 ? 1 : 0,
        NombrePaire = this.NombreTuiles == 2 ? 1 : 0
      };
    }

    public static bool IsBrelanOuCarreMajeur(Combinaison combi)
    {
      return combi is PungMajeur || combi is KongMajeur;
    }
  }

  public class HonneurSupreme : Combinaison
  {
    public HonneurSupreme() :
      base(ETypeCombinaison.Honneur, "Fleur ou Saison", 4, 4, 1)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Any())
      { // y a une tuile
        if (tuiles[0].Famille.IsHonneur())
        { // c'est la bonne famille
          this.Famille = tuiles[0].Famille;
          return true;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles[0].Rang == param.RangVentJoueur)
      { // fleur ou saison du joueur
        return 1;
      }

      return 0;
    }
  }

  public class HonneurDuJoueur : Combinaison
  {
    public HonneurDuJoueur() :
      base(ETypeCombinaison.Honneur, "Fleur et Saison du joueur", 0, 0, 2)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count >= this.NombreTuiles)
      { // y a les tuiles
        Tuile t1 = tuiles.Where(x => x.Famille == EFamille.Saison && x.Rang == param.RangVentJoueur).FirstOrDefault();
        Tuile t2 = tuiles.Where(x => x.Famille == EFamille.Fleur && x.Rang == param.RangVentJoueur).FirstOrDefault();
        if (t1 != null && t2 != null)
        { // c'est les bonnes
          this.Famille = tuiles[0].Famille;
          return true;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 2;
    }
  }
  public class PaireVentJoueur : Combinaison
  {
    public PaireVentJoueur() :
      base(ETypeCombinaison.Paire, "Paire de vents du joueur", 2, 2, 2)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == 2)
      { // y a des tuiles dans le bon nombre
        if (tuiles[0].Equals(tuiles[1]))
        { // c'est les mêmes
          Tuile t0 = tuiles[0];
          bool ok = t0.Rang == param.RangVentJoueur && t0.Famille == EFamille.Vent;
          if (ok)
          {
            this.Famille = tuiles[0].Famille;
          }

          return ok;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 0;
    }
  }
  public class PaireVentDominant : Combinaison
  {
    public PaireVentDominant() :
      base(ETypeCombinaison.Paire, "Paire de vents dominant", 2, 2, 2)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == this.NombreTuiles)
      { // y a des tuiles dans le bon nombre
        if (tuiles[0].Equals(tuiles[1]))
        { // c'est les mêmes
          Tuile t0 = tuiles[0];
          bool ok = t0.Rang == param.RangVentDominant && t0.Famille == EFamille.Vent;
          if (ok)
          {
            this.Famille = tuiles[0].Famille;
          }

          return ok;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 0;
    }
  }
  public class PaireVentDuTour : Combinaison
  {
    public PaireVentDuTour() :
      base(ETypeCombinaison.Paire, "Paire de vents du tour", 2, 2, 2)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == this.NombreTuiles)
      { // y a des tuiles dans le bon nombre
        if (tuiles[0].Equals(tuiles[1]))
        { // c'est les mêmes
          Tuile t0 = tuiles[0];
          bool ok = t0.Rang == param.RangVentDuTour && t0.Famille == EFamille.Vent;
          if (ok)
          {
            this.Famille = tuiles[0].Famille;
          }

          return ok;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 0;
    }
  }
  public class PaireDragon : Combinaison
  {
    public PaireDragon() :
      base(ETypeCombinaison.Paire, "Paire de dragons", 0, 2, 2)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == this.NombreTuiles)
      { // y a des tuiles dans le bon nombre
        if (tuiles[0].Equals(tuiles[1]))
        { // c'est les mêmes
          Tuile t0 = tuiles[0];
          bool ok = t0.Famille == EFamille.Dragon;
          if (ok)
          {
            this.Famille = tuiles[0].Famille;
          }

          return ok;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 0;
    }
  }
  public class PaireSimple : Combinaison
  {
    public PaireSimple() :
      base(ETypeCombinaison.Paire, "Paire", 0, 0, 2)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == 2)
      { // y a des tuiles dans le bon nombre
        if (tuiles[0].Equals(tuiles[1]))
        { // c'est les mêmes
          this.Famille = tuiles[0].Famille;
          return true;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 0;
    }
  }
  public class Show : Combinaison
  {
    public Show() :
      base(ETypeCombinaison.Combinaison, "Show", 0, 0, 3)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == this.NombreTuiles)
      { // y a des tuiles dans le bon nombre
        int n = tuiles.Select(x => x.Famille).Distinct().Count();
        if (n == 1)
        { // c'est les mêmes famille
          if (tuiles[0].Famille.IsCommon() || tuiles[0].Famille == EFamille.Dragon)
          { // famille correcte
            var tls = tuiles.OrderBy(x => x.Rang).ToList();
            Tuile t0 = tls[0];
            Tuile t1 = tls[1];
            Tuile t2 = tls[2];
            if ((t0.Rang + 1) == t1.Rang && (t1.Rang + 1) == t2.Rang)
            { // 3 tuiles se suivent
              this.Famille = tuiles[0].Famille;
              return true;
            }
          }
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 0;
    }
  }

  public class PungMineure : Combinaison
  {
    public PungMineure() :
      base(ETypeCombinaison.Combinaison, "Pung (de tuiles mineures)", 2, 4, 3)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == this.NombreTuiles)
      { // y a des tuiles dans le bon nombre
        if (tuiles[0].Equals(tuiles[1]) && tuiles[1].Equals(tuiles[2]))
        { // c'est les mêmes
          Tuile t0 = tuiles[0];
          bool ok = t0.Rang > 1 && t0.Rang < 9 && t0.Famille.IsCommon();
          if (ok)
          {
            this.Famille = tuiles[0].Famille;
          }

          return ok;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 0;
    }
  }
  public class PungMajeur : Combinaison
  {
    public PungMajeur() :
      base(ETypeCombinaison.Combinaison, "Pung (de tuiles majeures, vents ou dragons)", 4, 8, 3)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == this.NombreTuiles)
      { // y a des tuiles dans le bon nombre
        if (tuiles[0].Equals(tuiles[1]) && tuiles[1].Equals(tuiles[2]))
        { // c'est les mêmes
          Tuile t0 = tuiles[0];
          bool ok = ((t0.Rang == 1 || t0.Rang == 9) && t0.Famille.IsCommon()) || t0.Famille == EFamille.Dragon || t0.Famille == EFamille.Vent;
          if (ok)
          {
            this.Famille = tuiles[0].Famille;
          }

          return ok;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles[0].Famille == EFamille.Dragon)
      { // Dragon : Doublé une fois
        return 1;
      }
      else if (tuiles[0].Famille == EFamille.Vent && tuiles[0].Rang == param.RangVentJoueur)
      { // vent du joueur : doublé 1x si aussi vent dominant x2
        return tuiles[0].Rang == param.RangVentDominant ? 2 : 1;
      }
      else if (tuiles[0].Famille == EFamille.Vent && tuiles[0].Rang == param.RangVentDominant)
      { // vent dominant : doublé 1x
        return 1;
      }

      return 0;
    }
  }

  public class KongMineure : Combinaison
  {
    public KongMineure() :
      base(ETypeCombinaison.Combinaison, "Kong (de tuiles mineures)", 8, 16, 4)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == this.NombreTuiles)
      { // y a des tuiles dans le bon nombre
        if (tuiles[0].Equals(tuiles[1]) && tuiles[1].Equals(tuiles[2]) && tuiles[2].Equals(tuiles[3]))
        { // c'est les mêmes
          Tuile t0 = tuiles[0];
          bool ok = t0.Rang > 1 && t0.Rang < 9 && t0.Famille.IsCommon();
          if (ok)
          {
            this.Famille = tuiles[0].Famille;
          }

          return ok;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 0;
    }
  }
  public class KongMajeur : Combinaison
  {
    public KongMajeur() :
      base(ETypeCombinaison.Combinaison, "Kong (de tuiles majeures, vents ou dragons)", 16, 32, 4)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == this.NombreTuiles)
      { // y a des tuiles dans le bon nombre
        if (tuiles[0].Equals(tuiles[1]) && tuiles[1].Equals(tuiles[2]) && tuiles[2].Equals(tuiles[3]))
        { // c'est les mêmes
          Tuile t0 = tuiles[0];
          bool ok = ((t0.Rang == 1 || t0.Rang == 9) && t0.Famille.IsCommon()) || t0.Famille == EFamille.Dragon || t0.Famille == EFamille.Vent;
          if (ok)
          {
            this.Famille = tuiles[0].Famille;
          }

          return ok;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles[0].Famille == EFamille.Dragon)
      { // Dragon : Doublé une fois
        return 1;
      }
      else if (tuiles[0].Famille == EFamille.Vent && tuiles[0].Rang == param.RangVentJoueur)
      { // vent du joueur : doublé 1x
        return 1;
      }
      else if (tuiles[0].Famille == EFamille.Vent && tuiles[0].Rang == param.RangVentDominant)
      { // vent dominant : doublé 1x
        return 1;
      }

      return 0;
    }
  }
  public class Bouquet : Combinaison
  {
    public Bouquet() :
      base(ETypeCombinaison.Honneur, "Bouquet", 0, 0, 4)
    {
    }

    public override bool Match(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles != null && tuiles.Count == this.NombreTuiles)
      { // y a des tuiles dans le bon nombre
        if (tuiles.Select(x => x.Famille).Count() == 1 && tuiles[0].Famille.IsHonneur())
        { // c'est les mêmes famille et c'est un honneur
          // vu qu'il n'y a que 4 tuiles dans les fleurs ou les saison par besoin de plus de vérifications
          this.Famille = tuiles[0].Famille;
          return true;
        }
      }

      return false;
    }
    public override int NombreDouble(List<Tuile> tuiles, AnalyseParam param)
    {
      return 4;
    }
  }
}
