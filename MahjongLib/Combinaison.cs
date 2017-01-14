using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  /// <summary>
  /// Une combinaison : classe de base
  /// </summary>
  public abstract class Combinaison
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Combinaison"/>
    /// </summary>
    /// <param name="typeCombi">Le type de combinaison (pour détecter 4 combinaisons et une paire !)</param>
    /// <param name="nom">Son nom</param>
    /// <param name="pointVisible">le nombre de points apportés si elle est visible</param>
    /// <param name="pointMasque">le nombre de points apportés si elle est masquée</param>
    /// <param name="nombreTuiles">le nombre de tuiles attendues</param>
    /// <param name="nombreTuilesComptees">Le nombre de tuiles comptées pour cette combinaison</param>
    public Combinaison(ETypeCombinaison typeCombi, string nom, int pointVisible, int pointMasque, int nombreTuiles, int nombreTuilesComptees)
    {
      this.TypeCombinaison = typeCombi;
      this.Nom = nom;
      this.NombrePointsSiVisible = pointVisible;
      this.NombrePointsSiMasque = pointMasque;
      this.NombreTuiles = nombreTuiles;
      this.NombreTuilesComptees = nombreTuilesComptees;
    }

    #region Properties
    /// <summary>
    /// Le type de combinaison (pour détecter 4 combinaisons et une paire !)
    /// </summary>
    public ETypeCombinaison TypeCombinaison { get; private set; }

    /// <summary>
    /// Le nom
    /// </summary>
    public string Nom { get; private set; }

    /// <summary>
    /// Le nombre de points apportés si elle est visible
    /// </summary>
    public int NombrePointsSiVisible { get; private set; }

    /// <summary>
    /// Le nombre de points apportés si elle est masquée
    /// </summary>
    public int NombrePointsSiMasque { get; private set; }

    /// <summary>
    /// Le nombre de tuiles attendues
    /// </summary>
    public int NombreTuiles { get; private set; }

    /// <summary>
    /// le nombre de tuiles comptant pour cette combinaison
    /// </summary>
    public int NombreTuilesComptees { get; private set; }

    /// <summary>
    /// La famille des tuiles de la combinaison
    /// </summary>
    public EFamille? Famille { get; protected set; }

    /// <summary>
    /// le nombre de combinaisons 
    /// </summary>
    public PointsBase TypeDeCombinaison
    {
      get
      {
        return new PointsBase()
        {
          NombreCombinaison = this.NombreTuiles >= 3 ? 1 : 0,
          NombrePaire = this.NombreTuiles == 2 ? 1 : 0
        };
      }
    }
    #endregion

    /// <summary>
    /// Indique si la combinaison est un brelan ou carré de tuiles majeur (1 ou 9 d'une famille ordinaire)
    /// </summary>
    /// <param name="combi">la combinaison a anlyser</param>
    /// <returns>true si brelan ou carré majeur</returns>
    public static bool IsBrelanOuCarreMajeur(Combinaison combi)
    {
      return combi is PungMajeur || combi is KongMajeur;
    }

    /// <summary>
    /// Renvoie le nombre de points
    /// </summary>
    /// <param name="expose">si la combinaison est exposée ou pas</param>
    /// <returns>le nombre de points</returns>
    public int NombrePoint(bool expose)
    {
      return expose ? this.NombrePointsSiVisible : this.NombrePointsSiMasque;
    }

    /// <summary>
    /// La combinaison correspond elle à la liste des tuiles transmis
    /// </summary>
    /// <param name="tuiles">la liste des tuiles</param>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>true si cela matche</returns>
    public abstract bool Match(List<Tuile> tuiles, AnalyseParam param);

    /// <summary>
    /// Renvoie le nombre de double obtenu pour cette combinaison
    /// </summary>
    /// <param name="tuiles">la liste des tuiles</param>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>Le nombre de double</returns>
    public abstract DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param);

    /// <summary>
    /// duplique la combinaison
    /// </summary>
    /// <returns>la combinaison clonée</returns>
    public abstract Combinaison Clone();

    /// <summary>
    /// Renvoie les points obtenus pour cette combinaison
    /// </summary>
    /// <param name="tuiles">la liste des tuiles</param>
    /// <param name="param">les paramètres d'analyse</param>
    /// <returns>les points obtenus</returns>
    public Points Points(List<Tuile> tuiles, AnalyseParam param)
    {
      return new Points()
                    {
                      Nombre = this.NombrePoint(param.Expose),
                      DoublesMotif = this.NombreDouble(tuiles, param),
                      NombreCombinaison = this.NombreTuiles >= 3 ? 1 : 0,
                      NombrePaire = this.NombreTuiles == 2 ? 1 : 0
                    };
    }

    /// <summary>
    /// la combinaison est un honneur suprème seul
    /// </summary>
    public class HonneurSupreme : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="HonneurSupreme"/>
      /// </summary>
      public HonneurSupreme() :
        base(ETypeCombinaison.Honneur, "Fleur ou Saison", 4, 4, 1, 0)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
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

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        if (tuiles[0].Rang == param.RangVentJoueur)
        { // fleur ou saison du joueur
          return new DoubleMotif() { Double = 1, Motif = "1 double : Fleur ou Saison" };
        }

        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new HonneurSupreme() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// La combinaison est un honneur du même niveau que le joueur
    /// </summary>
    public class HonneurDuJoueur : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="HonneurDuJoueur"/>
      /// </summary>
      public HonneurDuJoueur() :
        base(ETypeCombinaison.Honneur, "Fleur et Saison du joueur", 0, 0, 2, 0)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
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

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return new DoubleMotif() { Double = 2, Motif = "2 doubles : Fleur et Saison du joueur" };
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new HonneurDuJoueur() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// Paire du vent du joueur
    /// </summary>
    public class PaireVentJoueur : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="PaireVentJoueur"/>
      /// </summary>
      public PaireVentJoueur() :
        base(ETypeCombinaison.Paire, "Paire de vents du joueur", 2, 2, 2, 2)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
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

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new PaireVentJoueur() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// Paire du vent dominant
    /// </summary>
    public class PaireVentDominant : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="PaireVentDominant"/>
      /// </summary>
      public PaireVentDominant() :
        base(ETypeCombinaison.Paire, "Paire de vents dominant", 2, 2, 2, 2)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
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

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new PaireVentDominant() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// Paire du vent du tour
    /// </summary>
    public class PaireVentDuTour : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="PaireVentDuTour"/>
      /// </summary>
      public PaireVentDuTour() :
        base(ETypeCombinaison.Paire, "Paire de vents du tour", 2, 2, 2, 2)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
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

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new PaireVentDuTour() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// Paire de dragons
    /// </summary>
    public class PaireDragon : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="PaireDragon"/>
      /// </summary>
      public PaireDragon() :
        base(ETypeCombinaison.Paire, "Paire de dragons", 0, 2, 2, 2)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
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

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new PaireDragon() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// Paire simple
    /// </summary>
    public class PaireSimple : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="PaireSimple"/>
      /// </summary>
      public PaireSimple() :
        base(ETypeCombinaison.Paire, "Paire", 0, 0, 2, 2)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
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

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new PaireSimple() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// Show de 3 tuiles
    /// </summary>
    public class Show : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="Show"/>
      /// </summary>
      public Show() :
        base(ETypeCombinaison.Combinaison, "Show", 0, 0, 3, 3)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
      public override bool Match(List<Tuile> tuiles, AnalyseParam param)
      {
        if (tuiles != null && tuiles.Count == this.NombreTuiles)
        { // y a des tuiles dans le bon nombre
          int n = tuiles.Select(x => x.Famille).Distinct().Count();
          if (n == 1)
          { // c'est les mêmes famille
            if (tuiles[0].Famille.IsOrdinaire() || tuiles[0].Famille == EFamille.Dragon)
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

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new Show() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// pung de tuile mineures
    /// </summary>
    public class PungMineure : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="PungMineure"/>
      /// </summary>
      public PungMineure() :
        base(ETypeCombinaison.Combinaison, "Pung (de tuiles mineures)", 2, 4, 3, 3)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
      public override bool Match(List<Tuile> tuiles, AnalyseParam param)
      {
        if (tuiles != null && tuiles.Count == this.NombreTuiles)
        { // y a des tuiles dans le bon nombre
          if (tuiles[0].Equals(tuiles[1]) && tuiles[1].Equals(tuiles[2]))
          { // c'est les mêmes
            Tuile t0 = tuiles[0];
            bool ok = t0.Rang > 1 && t0.Rang < 9 && t0.Famille.IsOrdinaire();
            if (ok)
            {
              this.Famille = tuiles[0].Famille;
            }

            return ok;
          }
        }

        return false;
      }

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new PungMineure() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// pung de tuiles majeures, vents ou dragon
    /// </summary>
    public class PungMajeur : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="PungMajeur"/>
      /// </summary>
      public PungMajeur() :
        base(ETypeCombinaison.Combinaison, "Pung (de tuiles majeures, vents ou dragons)", 4, 8, 3, 3)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
      public override bool Match(List<Tuile> tuiles, AnalyseParam param)
      {
        if (tuiles != null && tuiles.Count == this.NombreTuiles)
        { // y a des tuiles dans le bon nombre
          if (tuiles[0].Equals(tuiles[1]) && tuiles[1].Equals(tuiles[2]))
          { // c'est les mêmes
            Tuile t0 = tuiles[0];
            bool ok = ((t0.Rang == 1 || t0.Rang == 9) && t0.Famille.IsOrdinaire()) || t0.Famille == EFamille.Dragon || t0.Famille == EFamille.Vent;
            if (ok)
            {
              this.Famille = tuiles[0].Famille;
            }

            return ok;
          }
        }

        return false;
      }

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        if (tuiles[0].Famille == EFamille.Dragon)
        { // Dragon : Doublé une fois
          return new DoubleMotif() { Double = 1, Motif = "1 double : Pung de dragons" };
        }
        else if (tuiles[0].Famille == EFamille.Vent && tuiles[0].Rang == param.RangVentJoueur)
        { // vent du joueur : doublé 1x si aussi vent dominant x2
          return new DoubleMotif()
                      {
                        Double = tuiles[0].Rang == param.RangVentDominant ? 2 : 1,
                        Motif = tuiles[0].Rang == param.RangVentDominant ? "2 doubles : Pung du vent du joueur et dominant" : "1 double : Pung du vent du joueur"
                      };
        }
        else if (tuiles[0].Famille == EFamille.Vent && tuiles[0].Rang == param.RangVentDominant)
        { // vent dominant : doublé 1x
          return new DoubleMotif() { Double = 1, Motif = "1 double : Pung du vent dominant" };
        }

        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new PungMajeur() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// Kong de tuiles mineures
    /// </summary>
    public class KongMineur : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="KongMineur"/>
      /// </summary>
      public KongMineur() :
        base(ETypeCombinaison.Combinaison, "Kong (de tuiles mineures)", 8, 16, 4, 3)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
      public override bool Match(List<Tuile> tuiles, AnalyseParam param)
      {
        if (tuiles != null && tuiles.Count == this.NombreTuiles)
        { // y a des tuiles dans le bon nombre
          if (tuiles[0].Equals(tuiles[1]) && tuiles[1].Equals(tuiles[2]) && tuiles[2].Equals(tuiles[3]))
          { // c'est les mêmes
            Tuile t0 = tuiles[0];
            bool ok = t0.Rang > 1 && t0.Rang < 9 && t0.Famille.IsOrdinaire();
            if (ok)
            {
              this.Famille = tuiles[0].Famille;
            }

            return ok;
          }
        }

        return false;
      }

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new KongMineur() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// Kong de tuiles majeures, vents ou dragon
    /// </summary>
    public class KongMajeur : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="KongMajeur"/>
      /// </summary>
      public KongMajeur() :
        base(ETypeCombinaison.Combinaison, "Kong (de tuiles majeures, vents ou dragons)", 16, 32, 4, 3)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
      public override bool Match(List<Tuile> tuiles, AnalyseParam param)
      {
        if (tuiles != null && tuiles.Count == this.NombreTuiles)
        { // y a des tuiles dans le bon nombre
          if (tuiles[0].Equals(tuiles[1]) && tuiles[1].Equals(tuiles[2]) && tuiles[2].Equals(tuiles[3]))
          { // c'est les mêmes
            Tuile t0 = tuiles[0];
            bool ok = ((t0.Rang == 1 || t0.Rang == 9) && t0.Famille.IsOrdinaire()) || t0.Famille == EFamille.Dragon || t0.Famille == EFamille.Vent;
            if (ok)
            {
              this.Famille = tuiles[0].Famille;
            }

            return ok;
          }
        }

        return false;
      }

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        if (tuiles[0].Famille == EFamille.Dragon)
        { // Dragon : Doublé une fois
          return new DoubleMotif() { Double = 1, Motif = "1 double : Kong de dragons" };
        }
        else if (tuiles[0].Famille == EFamille.Vent && tuiles[0].Rang == param.RangVentJoueur)
        { // vent du joueur : doublé 1x si aussi vent dominant x2
          return new DoubleMotif()
          {
            Double = tuiles[0].Rang == param.RangVentDominant ? 2 : 1,
            Motif = tuiles[0].Rang == param.RangVentDominant ? "2 doubles : Kong du vent du joueur et dominant" : "1 double : Kong du vent du joueur"
          };
        }
        else if (tuiles[0].Famille == EFamille.Vent && tuiles[0].Rang == param.RangVentDominant)
        { // vent dominant : doublé 1x
          return new DoubleMotif() { Double = 1, Motif = "1 double : Kong du vent dominant" };
        }

        return null;
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new KongMajeur() { Famille = this.Famille };
      }
    }

    /// <summary>
    /// les 4 fleurs ou les 4 saisons
    /// </summary>
    public class Bouquet : Combinaison
    {
      /// <summary>
      /// Initialise une nouvelle instance de la classe <see cref="Bouquet"/>
      /// </summary>
      public Bouquet() :
        base(ETypeCombinaison.Honneur, "Bouquet", 0, 0, 4, 0)
      {
      }

      /// <summary>
      /// La combinaison correspond elle à la liste des tuiles transmis
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>true si cela matche</returns>
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

      /// <summary>
      /// Renvoie le nombre de double obtenu pour cette combinaison
      /// </summary>
      /// <param name="tuiles">la liste des tuiles</param>
      /// <param name="param">les paramètres d'analyse</param>
      /// <returns>Le nombre de double</returns>
      public override DoubleMotif NombreDouble(List<Tuile> tuiles, AnalyseParam param)
      {
        return new DoubleMotif() { Double = 4, Motif = "4 doubles : Bouquet de fleurs ou saisons" };
      }

      /// <summary>
      /// Duplique la combinaison
      /// </summary>
      /// <returns>la combinaison clonée</returns>
      public override Combinaison Clone()
      {
        return new Bouquet() { Famille = this.Famille };
      }
    }
  }
}
