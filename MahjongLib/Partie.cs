using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MahjongLib.JsonLoader;

namespace MahjongLib
{
  /// <summary>
  /// Gére le comptage des point d'une partie de mahjong
  /// </summary>
  public class Partie
  {
    /// <summary>
    /// NNom du fichier par défaut
    /// </summary>
    public const string NOMDEFAULT = "mahjong.json";

      /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Partie"/>
    /// </summary>
    /// <param name="dt">La date associée</param>
    /// <param name="comment">Le commentaire sur la partie</param>
    /// <param name="noms">les noms des joueurs (dans l'ordre de leur position pour le permier tour 0=est, 1=sud, 2=ouest, 3=nord)</param>
    /// <param name="withHonnors">la partie se jouer avec les honneurs ou pas</param>
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

    #region Public Properties
    /// <summary>
    /// La date de la partie
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Le commentaire associé à la partie
    /// </summary>
    public string Commentaire { get; set; }

    /// <summary>
    /// La partie se joue avec les honneurs
    /// </summary>
    public bool WithHonnors { get; private set; }

    /// <summary>
    /// La liste des joueurs
    /// </summary>
    public Joueur[] Joueurs { get; private set; }

    /// <summary>
    /// Les tours de la partie (un tour = 4 manches)
    /// </summary>
    public Tour[] Tours { get; private set; }

    /// <summary>
    /// Le numero de la manche en cours de saisie (de 0 à 15)
    /// </summary>
    public int NumeroDeManche { get; private set; }

    /// <summary>
    /// Le nom complet avec le dossier du fichier pour sauver la partie (remplit ssi la partie est chargée ou après sauvegarde)
    /// </summary>
    public string FullFileName { get; private set; }
    #endregion

    #region Computed properties
    /// <summary>
    /// Renvoie l'index du tour en cours de 0 à 3 (en fonction du numéro de la manche) 
    /// </summary>
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

    /// <summary>
    /// Renvoie l'index de la manche en cours dans le tour de 0 à 3 (en fonction du numéro de la manche) 
    /// </summary>
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

    /// <summary>
    /// Renvoie la manche en cours
    /// </summary>
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

    /// <summary>
    /// Indique si la saisie des score de la manche est complète ou pas
    /// </summary>
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
    #endregion

    /// <summary>
    /// Charge une partie depuis un fichier
    /// </summary>
    /// <param name="filename">le nom complet du fichier</param>
    /// <returns>la partie chargée ou nul si fichier non trouvé ou non valide</returns>
    public static Partie Load(string filename)
    {
      if (File.Exists(filename))
      {
        string contenu = File.ReadAllText(filename, Encoding.UTF8);
        if (!string.IsNullOrWhiteSpace(contenu))
        { // y a du contenu

          List<JsonObject> nfos = null;
          try
          {
            nfos = JsonObject.Parse(contenu);
          }
          catch
          {
            return null;
          }

          if (nfos != null && nfos.Count() == 1)
          { // json parsé !
            JsonObject jpartie = nfos.First();
            if (jpartie.HasAttributtes(new JsonAttribut[]
                                                {
                                                  new JsonAttribut("date", JsonAttribut.EJsonType.Date), 
                                                  new JsonAttribut("comment", JsonAttribut.EJsonType.String),
                                                  new JsonAttribut("honneurs", JsonAttribut.EJsonType.Bool),
                                                  new JsonAttribut("numManche", JsonAttribut.EJsonType.Number),
                                                  new JsonAttribut("joueurs", JsonAttribut.EJsonType.Array),
                                                  new JsonAttribut("tours", JsonAttribut.EJsonType.Array)
                                                }))
            { // l'objet Json lu semble complet
              List<string> noms = Partie.LoadNomsJoueurs(jpartie);
              if (noms != null)
              { 
                Partie partie = new Partie(
                                      jpartie["date"].ValeurDate.Value,
                                      jpartie["comment"].ValeurString,
                                      noms,
                                      jpartie["honneurs"].ValeurBool.Value);
                partie.NumeroDeManche = jpartie["numManche"].ValeurInt;
                partie.FullFileName = filename;
                List<Tour> lstT = Partie.LoadTours(jpartie, partie);
                if (lstT != null && lstT.Any())
                {
                  partie.Tours = lstT.ToArray();
                }

                return partie;
              }
            }
          }
        }
      }

      return null;
    }

    /// <summary>
    /// Ajoute un tour à la partie (et en fait le tour en cours)
    /// </summary>
    /// <param name="est">Qui est Est pour ce tour</param>
    /// <param name="sud">Qui est sud pour ce tour</param>
    /// <param name="ouest">Qui est Ouest pour ce tour</param>
    /// <param name="nord">Qui est Nord pour ce tour</param>
    /// <returns>renvoie le tour créé</returns>
    public Tour AddTour(Joueur est, Joueur sud, Joueur ouest, Joueur nord)
    {
      if (this.NumeroDeManche == -1 || this.NumeroDeManche == 3 || this.NumeroDeManche == 7 || this.NumeroDeManche == 11)
      {
        int idxTour = (this.NumeroDeManche + 1) / 4;
        this.Tours[idxTour] = new Tour(idxTour, this.WithHonnors, est, sud, ouest, nord);
        est.VentDuJoueurPourLeTour = Vent.Est;
        sud.VentDuJoueurPourLeTour = Vent.Sud;
        ouest.VentDuJoueurPourLeTour = Vent.Ouest;
        nord.VentDuJoueurPourLeTour = Vent.Nord;
        return this.Tours[idxTour];
      }

      return null;
    }

    /// <summary>
    /// Ajoute une manche au tour en cours
    /// </summary>
    /// <param name="ventDominant">qui est le vent dominant de la manche</param>
    /// <returns>La manche</returns>
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

    /// <summary>
    /// Sauve la partie sur disque
    /// </summary>
    /// <param name="folder">le dossier ou enregistrer le fichier</param>
    public void Save(string folder)
    {
      if (string.IsNullOrWhiteSpace(this.FullFileName))
      { // pas de fichier on en crée un 
        this.FullFileName = Path.Combine(folder, NOMDEFAULT);
      }

      File.WriteAllText(this.FullFileName, this.ToJson(), Encoding.UTF8);
    }

    /// <summary>
    /// Renvoie Le Json de l'objet
    /// </summary>
    /// <returns>Le Json de l'objet</returns>
    internal string ToJson()
    {
      StringBuilder res = new StringBuilder();
      res.Append("{");
      res.AppendFormat("\"date\":\"{0:o}\"", this.Date);
      res.AppendFormat(",\"comment\":\"{0}\"", this.Commentaire.Replace("\"", "\\\""));
      res.AppendFormat(",\"honneurs\":{0}", this.WithHonnors ? "true" : "false");
      res.AppendFormat(",\"numManche\":{0}", this.NumeroDeManche);
      res.AppendFormat(",\"joueurs\":[{0}, {1}, {2}, {3}]", this.Joueurs[0].ToJson(), this.Joueurs[1].ToJson(), this.Joueurs[2].ToJson(), this.Joueurs[3].ToJson());
      res.Append(",\"tours\":[");

      bool virgule = false;
      for (int i = 0; i < this.Tours.Length; i++)
      {
        if (this.Tours[i] != null)
        {
          if (virgule)
          {
            res.Append(",");
          }

          res.Append(this.Tours[i].ToJson());
          virgule = true;
        }
      }

      res.Append("]");
      res.Append("}");
      return res.ToString();
    }

    /// <summary>
    /// Renvoie la liste ordonnée des 4 noms des joueurs
    /// </summary>
    /// <param name="jpartie">l'objet json de lecture d'une partie</param>
    /// <returns>la liste des 4 noms; null en cas de problème</returns>
    private static List<string> LoadNomsJoueurs(JsonObject jpartie)
    {
      List<JsonObject> jjoueurs = jpartie["joueurs"].ValeurCll;
      if (jjoueurs != null && jjoueurs.Count == 4)
      { // y a bien 4 joueurs
        List<string> noms = new List<string>();

        IEnumerable<JsonObject> jjoueurObs = jjoueurs.Select(x => x.GetObjet);
        for (int i = 0; i < 4; i++)
        {
          JsonObject jjoueur = jjoueurObs.Where(x => x["position"].ValeurInt == i).FirstOrDefault();
          if (jjoueur == null)
          { // joueur non trouvé !
            return null;
          }
          else if (jjoueur.HasAttributtes(new JsonAttribut[] { new JsonAttribut("nom", JsonAttribut.EJsonType.String) }))
          { // le joueur a bien un nom
            noms.Add(jjoueur["nom"].ValeurString);
          }
        }

        if (noms.Count == 4)
        { // on les renvoie que s'il sont bien remplis
          return noms;
        }
      }

      return null;
    }

    /// <summary>
    /// Renvoie le la liste des tours eux même remplis (4 maxi)
    /// </summary>
    /// <param name="jpartie">l'objet json de lecture d'une partie</param>
    /// <param name="partie">La partie</param>
    /// <returns>La liste des tours trouvés</returns>
    private static List<Tour> LoadTours(JsonObject jpartie, Partie partie)
    {
      List<JsonObject> jtours = jpartie["tours"].ValeurCll;
      if (jtours != null && jtours.Any())
      { // y a bien au moins un tour
        IEnumerable<JsonObject> jtoursObj = jtours.Select(x => x.GetObjet);
        List<Tour> tours = new List<Tour>();
        for (int i = 0; i < 4; i++)
        {
          JsonObject jtour = jtoursObj.Where(x => x["numeroTour"].ValeurInt == i).FirstOrDefault();
          if (jtour == null)
          { // tour non trouvé ! ==> on sort de la boucle
            break;
          }

          if (jtour.HasAttributtes(new JsonAttribut[] 
                                             { 
                                               new JsonAttribut("idxJoueurs", JsonAttribut.EJsonType.Array),
                                               new JsonAttribut("manches", JsonAttribut.EJsonType.Array)
                                             }))
          { // le tour à tout ce qu'il faut
            List<JsonObject> jindexes = jtour["idxJoueurs"].ValeurCll;
            if (jindexes != null && jindexes.Count == 4)
            { // on a les positions des joueurs dans le tour
              int j0 = jindexes[0].Properties[0].ValeurInt;
              int j1 = jindexes[1].Properties[0].ValeurInt;
              int j2 = jindexes[2].Properties[0].ValeurInt;
              int j3 = jindexes[3].Properties[0].ValeurInt;
              Joueur est = partie.Joueurs.Where(x => x.Position == j0).FirstOrDefault();
              Joueur sud = partie.Joueurs.Where(x => x.Position == j1).FirstOrDefault();
              Joueur ouest = partie.Joueurs.Where(x => x.Position == j2).FirstOrDefault();
              Joueur nord = partie.Joueurs.Where(x => x.Position == j3).FirstOrDefault();
              Tour tour = new Tour(i, partie.WithHonnors, est, sud, ouest, nord);
              tour.LoadManches(jtour, partie);
              tours.Add(tour);
            }
          }
        }

        if (tours.Any())
        { // y en a au moins un
          return tours;
        }
      }

      return null;
    }
  }
}
