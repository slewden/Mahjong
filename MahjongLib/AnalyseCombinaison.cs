using System.Collections.Generic;
using System.Linq;

namespace MahjongLib
{
  /// <summary>
  /// Analyse une combinaison
  /// </summary>
  public class AnalyseCombinaison
  {
    /// <summary>
    /// L'analyseur de combinaison
    /// </summary>
    private static AnalyseCombinaison analyseur = null;

    /// <summary>
    /// La liste des combinaison possibles
    /// </summary>
    private List<Combinaison> combinaisons;
     
    /// <summary>
    /// Empêche la création d'une instance par défaut de la classe <see cref="AnalyseCombinaison" />.
    /// </summary>
    private AnalyseCombinaison()
    {
      this.combinaisons = new List<Combinaison>();

      this.combinaisons.Add(new Combinaison.HonneurSupreme());
      this.combinaisons.Add(new Combinaison.HonneurDuJoueur());
      this.combinaisons.Add(new Combinaison.PaireVentJoueur());
      this.combinaisons.Add(new Combinaison.PaireVentDominant());
      this.combinaisons.Add(new Combinaison.PaireVentDuTour());
      this.combinaisons.Add(new Combinaison.PaireDragon());
      this.combinaisons.Add(new Combinaison.PaireSimple());
      this.combinaisons.Add(new Combinaison.Show());
      this.combinaisons.Add(new Combinaison.PungMineure());
      this.combinaisons.Add(new Combinaison.PungMajeur());
      this.combinaisons.Add(new Combinaison.KongMineur());
      this.combinaisons.Add(new Combinaison.KongMajeur());
      this.combinaisons.Add(new Combinaison.Bouquet());
    }

    /// <summary>
    /// Calcule la combinaison possible à partir des tuiles et des paramètres d'analyse
    /// </summary>
    /// <param name="tuiles">les tuiles</param>
    /// <param name="param">les paramétres d'analyse</param>
    /// <returns>la combinaison optimum</returns>
    public static Combinaison Compute(List<Tuile> tuiles, AnalyseParam param)
    {
      if (tuiles == null || !tuiles.Any() || param == null)
      {
        return null;
      }
      
      if (AnalyseCombinaison.analyseur == null)
      {
        AnalyseCombinaison.analyseur = new AnalyseCombinaison();
      }

      return AnalyseCombinaison.analyseur.combinaisons.Where(x => x.NombreTuiles == tuiles.Count).Where(x => x.Match(tuiles, param)).FirstOrDefault();
    }
  }
}
