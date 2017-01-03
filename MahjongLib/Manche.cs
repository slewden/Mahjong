using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  public class Manche
  {
    public Manche(int ventTour, Vent ventDom, bool withHonnors, int numTour, int numManche)
    {
      this.VentTour = ventTour;
      this.VentDominant = ventDom;
      this.Mains = new MainJoueur[4];
      this.NumeroTour = numTour;
      this.NumeroManche = numManche;
      this.Tuiles = new TuileHelper(withHonnors);
    }

    public int VentTour { get; private set; }
    public Vent VentDominant { get; private set; }
    public MainJoueur[] Mains { get; private set; }
    public int NumeroTour { get; private set; }
    public int NumeroManche { get; private set; }
    public TuileHelper Tuiles { get; private set; }

    public bool Complete { get; set; }

    public bool CanComplete
    {
      get
      {
        return this.Mains.Where(x => x != null).Select(x => x.Groupes.Select(y => y.Tuiles.Count).Sum()).Sum() > 13 * 4;  // celui qui fait mahjong à au moins 14 tuiles !
      }
    }

    public MainJoueur Main(Joueur joueur)
    {
      if (this.Mains[joueur.Position] == null)
      {
        this.Mains[joueur.Position] = new MainJoueur(joueur, this.NumeroTour, this.NumeroManche);
      }

      return this.Mains[joueur.Position];
    }

    public AnalyseParam Parametre(Joueur j)
    {
      return new AnalyseParam() 
                  { 
                    RangVentJoueur = j.Position,
                    RangVentDominant = (int)this.VentDominant,
                    RangVentDuTour = this.VentTour,
                  };
    }

    /// <summary>
    /// Ajoute au groupe du joueur la tuile
    /// </summary>
    /// <param name="joueur">Le joueur</param>
    /// <param name="groupe">Le groupe</param>
    /// <param name="tuile">La tuile</param>
    /// <returns>renvoie le groupe</returns>
    public Groupe AddTuile(Joueur joueur, Groupe groupe, Tuile tuile, bool? expose = null)
    {
      if (joueur == null || tuile == null)
      { // y a pas ce qu'il faut pour bosser !
        return null;
      }

      MainJoueur m = this.Main(joueur);
      if (groupe == null)
      { // pas de groupe on en ajoute un
        groupe = new Groupe();
        m.Groupes.Add(groupe);
      }

      if (expose.HasValue)
      { // la combinaison est visible ou masquée
        groupe.Expose = expose.Value;
      }

      AnalyseParam param = this.Parametre(joueur);

      if (!groupe.Add(tuile, param))
      { // le groupe est plein on en crée un autre
        groupe = new Groupe();
        m.Groupes.Add(groupe);
        groupe.Add(tuile, param);
      }

      this.Tuiles.Remove(tuile);
      return groupe;
    }

    /// <summary>
    /// Retire au groupe du joueur la tuile
    /// </summary>
    /// <param name="joueur">Le joueur</param>
    /// <param name="groupe">Le groupe</param>
    /// <param name="tuile">La tuile</param>
    public bool RemoveTuile(Joueur joueur, Groupe groupe, Tuile tuile)
    {
      if (joueur != null && groupe != null && tuile != null)
      { // y a ce qu'il faut pour bosser !
        AnalyseParam param = this.Parametre(joueur);
        
        if (groupe.Remove(tuile, param))
        { // la tuile est bien retirée du groupe
          if (!groupe.Tuiles.Any())
          {
            MainJoueur m = this.Main(joueur);
            m.Groupes.Remove(groupe);
          }

          this.Tuiles.Add(tuile);
          return true;
        }
      }

      return false;
    }
  }
}
