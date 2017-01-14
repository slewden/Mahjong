using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MahjongLib.JsonLoader;

namespace MahjongLib
{
  /// <summary>
  /// Modélise une manche d'une partie
  /// </summary>
  public class Manche
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Manche"/>
    /// </summary>
    /// <param name="ventTour">Indique qui est le vent du tour</param>
    /// <param name="ventDom">indique qui est le vent dominant</param>
    /// <param name="withHonnors">Indique si les honneurs sont utilisées ou pas</param>
    /// <param name="numTour">indique le numéro du tour de 0 à 3</param>
    /// <param name="numManche">Indique le numéro de la manche dans le tour de 0 à 3</param>
    public Manche(int ventTour, Vent ventDom, bool withHonnors, int numTour, int numManche)
    {
      this.VentTour = ventTour;
      this.VentDominant = ventDom;
      this.Mains = new MainJoueur[4];
      this.NumeroTour = numTour;
      this.NumeroManche = numManche;
      this.Tuiles = new TuileHelper(withHonnors);
    }

    #region Properties
    /// <summary>
    /// Le vent du tour
    /// </summary>
    public int VentTour { get; private set; }

    /// <summary>
    /// Le vent dominant
    /// </summary>
    public Vent VentDominant { get; private set; }

    /// <summary>
    /// Les mains des joueurs (dans l'ordre de position des joueur dans la partie)
    /// </summary>
    public MainJoueur[] Mains { get; private set; }

    /// <summary>
    /// le numéro du tour de 0 à 3
    /// </summary>
    public int NumeroTour { get; private set; }

    /// <summary>
    /// le numéro de la manche de 0 à 3
    /// </summary>
    public int NumeroManche { get; private set; }

    /// <summary>
    /// La liste des tuiles restant (qui ne sont pas dans les mains des joueurs)
    /// </summary>
    public TuileHelper Tuiles { get; private set; }

    /// <summary>
    /// La saisie le manche est complète ou pas
    /// </summary>
    public bool Complete { get; set; }

    /// <summary>
    /// le joueur qui a fait majhong l'a fait avec une tuile du mur
    /// </summary>
    public bool MahjongAvecTuileDuMur { get; set; }

    /// <summary>
    /// le joueur qui a fait majhong l'a fait avec la dernière tuile du mur
    /// </summary>
    public bool MahjongAvecDerniereTuileDuMur { get; set; }

    /// <summary>
    /// le joueur qui a fait majhong l'a fait en vollant un kong exposé
    /// </summary>
    public bool MahjongEnVolantKongExpose { get; set; }
    #endregion

    #region Computed properties
    /// <summary>
    /// La saisie peut être déclarée complète
    /// (calcul du nombre de tuiles déclarées par mains)
    /// </summary>
    public bool CanComplete
    {
      get
      {
        return this.Mains.Where(x => x != null).Select(x => x.Groupes.Select(y => y.Tuiles.Count).Sum()).Sum() > 13 * 4;  // celui qui fait mahjong à au moins 14 tuiles !
      }
    }
    #endregion

    /// <summary>
    /// Renvoie la main du joueur demandé (on la crée si besoin)
    /// </summary>
    /// <param name="joueur">Le joueur</param>
    /// <returns>La main</returns>
    public MainJoueur Main(Joueur joueur)
    {
      if (joueur == null)
      {
        throw new ArgumentException("Il faut fournir un joueur", "joueur");
      }

      if (this.Mains[joueur.Position] == null)
      {
        this.Mains[joueur.Position] = new MainJoueur(joueur, this.NumeroTour, this.NumeroManche);
      }

      return this.Mains[joueur.Position];
    }

    /// <summary>
    /// Renvoie les paramètre d'analyse de la main du joueur
    /// </summary>
    /// <param name="j">le joueur</param>
    /// <returns>les paramétres d'analyse</returns>
    public AnalyseParam Parametre(Joueur j)
    {
      return new AnalyseParam()
                  {
                    RangVentJoueur = j.Position,
                    RangVentDominant = (int)this.VentDominant,
                    RangVentDuTour = this.VentTour,
                    MahjongAvecTuileDuMur = this.MahjongAvecTuileDuMur,
                    MahjongAvecDerniereTuileDuMur = this.MahjongAvecDerniereTuileDuMur,
                    MahjongEnVolantKongExpose = this.MahjongEnVolantKongExpose
                  };
    }

    /// <summary>
    /// Ajoute au groupe du joueur la tuile
    /// </summary>
    /// <param name="joueur">Le joueur</param>
    /// <param name="groupe">Le groupe</param>
    /// <param name="tuile">La tuile</param>
    /// <param name="expose">La tuile est exposée ou pas</param>
    /// <returns>Renvoie le groupe</returns>
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
    /// <returns>Renvoie true si la tuile a été retirée</returns>
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

    /// <summary>
    /// Renvoie Le Json de l'objet
    /// </summary>
    /// <returns>Le Json de l'objet</returns>
    internal string ToJson()
    {
      StringBuilder res = new StringBuilder();
      res.Append("{");
      res.AppendFormat("\"ventTour\":{0}", this.VentTour);
      res.AppendFormat(",\"ventDominant\":{0}", (int)this.VentDominant);
      ////res.AppendFormat(",\"numeroTour\":{0}", this.NumeroTour);
      res.AppendFormat(",\"numManche\":{0}", this.NumeroManche);
      res.AppendFormat(",\"complete\":{0}", this.Complete ? "true" : "false");

      res.AppendFormat(",\"mahjongAvecTuileDuMur\":{0}", this.MahjongAvecTuileDuMur ? "true" : "false");
      res.AppendFormat(",\"mahjongAvecDerniereTuileDuMur\":{0}", this.MahjongAvecDerniereTuileDuMur ? "true" : "false");
      res.AppendFormat(",\"mahjongEnVolantKongExpose\":{0}", this.MahjongEnVolantKongExpose ? "true" : "false");
      res.Append(",\"mains\":[");
      bool virgule = false;
      for (int i = 0; i < this.Mains.Length; i++)
      {
        if (this.Mains[i] != null)
        {
          if (virgule)
          {
            res.Append(",");
          }

          res.Append(this.Mains[i].ToJson());
          virgule = true;
        }
      }

      res.Append("]");
      res.Append("}");
      return res.ToString();
    }

    /// <summary>
    /// Charge les mains de la manche
    /// </summary>
    /// <param name="jmanche">le json de la manche</param>
    /// <param name="partie">la partie</param>
    internal void LoadMains(JsonObject jmanche, Partie partie)
    {
      List<JsonObject> jmains = jmanche["mains"].ValeurCll;
      if (jmains != null && jmains.Any())
      { // y a bien au moins une main
        foreach (JsonObject jmainObj in jmains)
        {
          JsonObject jmain = jmainObj.GetObjet;
          if (jmain != null && jmain.HasAttributtes(new JsonAttribut[] 
                                                          {
                                                            new JsonAttribut("idxJoueur", JsonAttribut.EJsonType.Number),
                                                            new JsonAttribut("groupes", JsonAttribut.EJsonType.Array)
                                                          }))
          { // y a ce qu'il faut
            int idxJoueur = jmain["idxJoueur"].ValeurInt;
            Joueur joueur = partie.Joueurs.Where(x => x.Position == idxJoueur).FirstOrDefault();
            if (joueur != null)
            { // joueur trouvé
              List<JsonObject> jgroupes = jmain["groupes"].ValeurCll;
              if (jgroupes != null && jgroupes.Any())
              { // y a des groupes on les parse pour ajouter les tuiles
                Groupe groupe = null;
                foreach (JsonObject jgroupeObj in jgroupes)
                {
                  JsonObject jgroupe = jgroupeObj.GetObjet;
                  if (jgroupe != null && jgroupe.HasAttributtes(new JsonAttribut[] 
                                                                      {
                                                                        new JsonAttribut("expose", JsonAttribut.EJsonType.Bool),
                                                                        new JsonAttribut("tuiles", JsonAttribut.EJsonType.Array)
                                                                      }))
                  { // y a ce qu'il faut
                    bool? expose = jgroupe["expose"].ValeurBool;
                    Tuile tuile;

                    List<JsonObject> jtuiles = jgroupe["tuiles"].ValeurCll;
                    if (jtuiles != null && jtuiles.Any())
                    { // y a des tuiles on les parse pour les ajouter
                      foreach (JsonObject jtuileObj in jtuiles)
                      {
                        JsonObject jtuile = jtuileObj.GetObjet;
                        if (jtuile != null && jtuile.HasAttributtes(new JsonAttribut[] 
                                                                          {
                                                                            new JsonAttribut("famille", JsonAttribut.EJsonType.String),
                                                                            new JsonAttribut("rang", JsonAttribut.EJsonType.Number),
                                                                          }))
                        { // y a ce qu'il faut
                          int nombre = 1;
                          if (jtuile.HasAttributte("nombre"))
                          {
                            nombre = jtuile["nombre"].ValeurInt;
                          }

                          int rang = jtuile["rang"].ValeurInt;
                          string jfamille = jtuile["famille"].ValeurString;
                          EFamille fam;
                          if (Enum.TryParse(jfamille, out fam))
                          { // famille reconnue
                            tuile = this.Tuiles.Jeu.Where(x => x.Famille == fam && x.Rang == rang).FirstOrDefault();
                            if (tuile != null)
                            { // autant de fois que la tuile est utilisée
                              for (int tl = 0; tl < nombre; tl++)
                              {
                                groupe = this.AddTuile(joueur, groupe, tuile, expose);
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
  }
}
