using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  public class Tour
  {
    public Tour(int numTour, bool withHonnors, Joueur est, Joueur sud, Joueur ouest, Joueur nord)
    {
      this.NumeroTour = numTour;
      this.WithHonnors = withHonnors;
      this.Joueurs = new Joueur[4];
      this.Joueurs[0] = est;
      this.Joueurs[1] = sud;
      this.Joueurs[2] = ouest;
      this.Joueurs[3] = nord;
      this.Manches = new Manche[4];
    }

    public int NumeroTour { get; private set; }
    public bool WithHonnors { get; private set; }
    public Joueur[] Joueurs { get; private set; }
    public Manche[] Manches { get; private set; }

    public Vent VentTour 
    { 
      get
      {
        return (Vent)this.NumeroTour;
      }
    }


    public Manche AddManche(int numManche, Vent ventDominant)
    {
      if (numManche < 0 || numManche > 3)
      {
        throw new ArgumentException("Numéro de manche invalide", "numManche");
      }

      this.Manches[numManche] = new Manche(this.NumeroTour, ventDominant, this.WithHonnors, this.NumeroTour, numManche);
      return this.Manches[numManche];
    }
  }
}
