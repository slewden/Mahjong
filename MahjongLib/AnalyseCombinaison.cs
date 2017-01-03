using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  public class AnalyseCombinaison
  {
    private static AnalyseCombinaison analyseur = null;

    private List<Combinaison> combinaisons;
     
    private AnalyseCombinaison()
    {
      this.combinaisons = new List<Combinaison>();

      this.combinaisons.Add(new HonneurSupreme());
      this.combinaisons.Add(new HonneurDuJoueur());
      this.combinaisons.Add(new PaireVentJoueur());
      this.combinaisons.Add(new PaireVentDominant());
      this.combinaisons.Add(new PaireVentDuTour());
      this.combinaisons.Add(new PaireDragon());
      this.combinaisons.Add(new PaireSimple());
      this.combinaisons.Add(new Show());
      this.combinaisons.Add(new PungMineure());
      this.combinaisons.Add(new PungMajeur());
      this.combinaisons.Add(new KongMineure());
      this.combinaisons.Add(new KongMajeur());
      this.combinaisons.Add(new Bouquet());
    }

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
