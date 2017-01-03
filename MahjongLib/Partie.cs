using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  public class Partie
  {
    public Partie(DateTime dt, string comment, List<string> noms, bool withHonnors)
    {
      if (noms == null || noms.Count != 4)
      {
        throw new Exception("Nom des 4 joueurs obligatoire");
      }

      this.Date = dt;
      this.Commentaire = comment;
      this.WithHonnors = withHonnors;

      // les joueurs
      this.Joueurs = new Joueur[4];
      this.Joueurs[0] = new Joueur(noms[0], 0);
      this.Joueurs[1] = new Joueur(noms[1], 1);
      this.Joueurs[2] = new Joueur(noms[2], 2);
      this.Joueurs[3] = new Joueur(noms[3], 3);

      // Les tours
      this.Tours = new Tour[4];
      this.NumeroDeManche = -1;
    }

    public DateTime Date { get; set; }
    public string Commentaire { get; set; }
    public bool WithHonnors { get; private set; }
    public Joueur[] Joueurs { get; private set; }
    public Tour[] Tours { get; private set; }

    public int NumeroDeManche { get; private set; }
    public int IndexTour
    {
      get
      {
        if (this.NumeroDeManche == -1)
        {
          return -1;
        }
        else
        {
          return this.NumeroDeManche / 4;
        }
      }
    }
    public int IndexManche
    {
      get
      {
        if (this.NumeroDeManche == -1)
        {
          return -1;
        }
        else
        {
          return this.NumeroDeManche % 4;
        }
      }
    }
    public Manche Manche
    {
      get
      {
        if (this.NumeroDeManche == -1)
        {
          return null;
        }
        else
        {
          return this.Tours[this.IndexTour].Manches[this.NumeroDeManche];
        }
      }
    }
    public bool MancheComplete
    {
      get
      {
        Manche m = this.Manche;
        if (m == null)
        {
          return true;
        }
        else
        {
          return m.Complete;
        }
      }
    }

    public void AddTour(Joueur est, Joueur sud, Joueur ouest, Joueur nord)
    {
      if (this.NumeroDeManche == -1 || this.NumeroDeManche == 3 || this.NumeroDeManche == 7 || this.NumeroDeManche == 11)
      {
        int idxTour = (this.NumeroDeManche + 1) / 4;
        this.Tours[idxTour] = new Tour(idxTour, this.WithHonnors, est, sud, ouest, nord);
        est.VentDuJoueurPourLeTour = Vent.Est;
        sud.VentDuJoueurPourLeTour = Vent.Sud;
        ouest.VentDuJoueurPourLeTour = Vent.Ouest;
        nord.VentDuJoueurPourLeTour = Vent.Nord;
      }
    }

    public Manche AddManche(Vent ventDominant)
    {
      if (this.NumeroDeManche < 15)
      {
        this.NumeroDeManche++;
        int idxTour = this.IndexTour;
        int idxManche = this.NumeroDeManche % 4;
        if (this.Tours[idxTour] == null)
        {
          throw new Exception("Il faut créer le tour avant la manche");
        }

        return this.Tours[idxTour].AddManche(idxManche, ventDominant);
      }
      else
      {
        throw new Exception("Partie finie");
      }
    }
  }
}
