using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MahjongLib.JsonLoader;

namespace MahjongLib
{
  /// <summary>
  /// Un tour = groupe de Quatre manches
  /// </summary>
  public class Tour
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Tour"/>
    /// </summary>
    /// <param name="numTour">Le numero du tour</param>
    /// <param name="withHonnors">La partie se joue avec les honneurs ou sans</param>
    /// <param name="est">Qui est le vent d'est pour ce tour</param>
    /// <param name="sud">Qui est le vent du sud pour ce tour</param>
    /// <param name="ouest">Qui est le vent d'ouest pour ce tour</param>
    /// <param name="nord">Qui est le vent du nord pour ce tour</param>
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

    #region Properties
    /// <summary>
    /// Le numéro du tour
    /// </summary>
    public int NumeroTour { get; private set; }

    /// <summary>
    /// La partie se joue avec les honneurs ou sans
    /// </summary>
    public bool WithHonnors { get; private set; }

    /// <summary>
    /// Qui sont les joueurs pour se tour (0 = Est, 1 = Sud, 2 = Ouest, 3 = Nord
    /// </summary>
    public Joueur[] Joueurs { get; private set; }

    /// <summary>
    /// Les quatres manches du tour
    /// </summary>
    public Manche[] Manches { get; private set; }
    #endregion

    #region Computed properties
    /// <summary>
    /// Le vent du tour (déterminé à partir du numéro du tour)
    /// </summary>
    public Vent VentTour
    {
      get
      {
        return (Vent)this.NumeroTour;
      }
    }
    #endregion

    /// <summary>
    /// Ajouter une manche au tour
    /// </summary>
    /// <param name="numManche">le numero de la manche dans le tour (de 0 à 3)</param>
    /// <param name="ventDominant">le vent dominant de la manche</param>
    /// <returns>la manche créé</returns>
    public Manche AddManche(int numManche, Vent ventDominant)
    {
      if (numManche < 0 || numManche > 3)
      {
        throw new ArgumentException("Numéro de manche invalide", "numManche");
      }

      this.Manches[numManche] = new Manche(this.NumeroTour, ventDominant, this.WithHonnors, this.NumeroTour, numManche);
      return this.Manches[numManche];
    }

    /// <summary>
    /// Renvoie Le json de l'objet
    /// </summary>
    /// <returns>Le json de l'objet</returns>
    internal string ToJson()
    {
      StringBuilder res = new StringBuilder();
      res.Append("{");
      res.AppendFormat("\"numeroTour\":{0}", this.NumeroTour);
      res.AppendFormat(",\"idxJoueurs\":[{0}, {1}, {2}, {3}]", this.Joueurs[0].Position, this.Joueurs[1].Position, this.Joueurs[2].Position, this.Joueurs[3].Position);
      res.Append(",\"manches\":[");
      bool virgule = false;
      for (int i = 0; i < this.Manches.Length; i++)
      {
        if (this.Manches[i] != null)
        {
          if (virgule)
          {
            res.Append(",");
          }

          res.Append(this.Manches[i].ToJson());
          virgule = true;
        }
      }

      res.Append("]");
      res.Append("}");
      return res.ToString();
    }

    /// <summary>
    /// Charge les manche depuis l'objet Json
    /// </summary>
    /// <param name="jtour">le json</param>
    /// <param name="partie">la partie</param>
    internal void LoadManches(JsonObject jtour, Partie partie)
    {
      List<JsonObject> jmanches = jtour["manches"].ValeurCll;
      if (jmanches != null && jmanches.Any())
      { // y a bien au moins une manche
        foreach (JsonObject jmancheObj in jmanches)
        {
          JsonObject jmanche = jmancheObj.GetObjet;
          if (jmanche != null && jmanche.HasAttributtes(new JsonAttribut[] 
                                                                {
                                                                  new JsonAttribut("ventTour", JsonAttribut.EJsonType.Number),
                                                                  new JsonAttribut("ventDominant", JsonAttribut.EJsonType.Number),
                                                                  new JsonAttribut("numManche", JsonAttribut.EJsonType.Number),
                                                                  new JsonAttribut("complete", JsonAttribut.EJsonType.Bool),
                                                                  new JsonAttribut("mahjongAvecTuileDuMur", JsonAttribut.EJsonType.Bool),
                                                                  new JsonAttribut("mahjongAvecDerniereTuileDuMur", JsonAttribut.EJsonType.Bool),
                                                                  new JsonAttribut("mahjongEnVolantKongExpose", JsonAttribut.EJsonType.Bool),
                                                                  new JsonAttribut("mains", JsonAttribut.EJsonType.Array)
                                                                }))
          { // y a ce qu'il faut
            int ventTour = jmanche["ventTour"].ValeurInt;
            int ventDominant = jmanche["ventDominant"].ValeurInt;
            int numeroManche = jmanche["numManche"].ValeurInt;
            Manche manche = new Manche(ventTour, (Vent)ventDominant, partie.WithHonnors, this.NumeroTour, numeroManche);
            manche.Complete = jmanche["complete"].ValeurBool.Value;
            manche.MahjongAvecTuileDuMur = jmanche["mahjongAvecTuileDuMur"].ValeurBool.Value;
            manche.MahjongAvecDerniereTuileDuMur = jmanche["mahjongAvecDerniereTuileDuMur"].ValeurBool.Value;
            manche.MahjongEnVolantKongExpose = jmanche["mahjongEnVolantKongExpose"].ValeurBool.Value;
            manche.LoadMains(jmanche, partie);
            this.Manches[manche.NumeroManche] = manche;
          }
        }
      }
    }
  }
}
