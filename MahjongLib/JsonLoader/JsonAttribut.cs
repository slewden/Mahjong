using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib.JsonLoader
{
  /// <summary>
  /// Un attribut Json
  /// </summary>
  public class JsonAttribut
  {
    /// <summary>
    /// La valeur brute
    /// </summary>
    private string valeur;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="JsonAttribut"/>
    /// </summary>
    public JsonAttribut() 
      : this(null, EJsonType.Null)
    { 
    }

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="JsonAttribut"/>
    /// </summary>
    /// <param name="nom">Le nom</param>
    /// <param name="type">le Type</param>
    public JsonAttribut(string nom, EJsonType type)
    {
      this.Nom = nom;
      this.Type = type;
    }

    /// <summary>
    /// Les type de données du json
    /// </summary>
    public enum EJsonType
    {
      /// <summary>
      /// une chaine
      /// </summary>
      String,

      /// <summary>
      /// un nombre
      /// </summary>
      Number,

      /// <summary>
      /// une date
      /// </summary>
      Date,

      /// <summary>
      /// un objet
      /// </summary>
      Object,

      /// <summary>
      /// une liste d'objets
      /// </summary>
      Array,

      /// <summary>
      /// un booleen
      /// </summary>
      Bool,

      /// <summary>
      /// rien un truc vide
      /// </summary>
      Null
    }

    /// <summary>
    /// Le type de données dans l'objet
    /// </summary>
    public EJsonType Type { get; private set; }

    /// <summary>
    /// Nom de l'attribut
    /// </summary>
    public string Nom { get; set; }

    /// <summary>
    /// Valeur brute de l'attribut
    /// </summary>
    public string Valeur
    {
      get
      {
        return this.valeur;
      }

      set
      {
        this.valeur = value;
        this.ValeurDate = null;
        this.ValeurNumber = null;
        this.ValeurString = null;
        this.ValeurBool = null;

        if (this.valeur == "true" || this.valeur == "false")
        { // bool 
          this.Type = EJsonType.Bool;
          this.ValeurBool = this.valeur == "true";
        }
        else if (this.valeur.StartsWith("\"") && this.valeur.EndsWith("\"") && this.valeur.Length >= 2)
        { // c'est une string
          this.Type = EJsonType.String;
          this.ValeurString = this.valeur.Substring(1, this.valeur.Length - 2); // on filtre les double quote
          if (!string.IsNullOrWhiteSpace(this.ValeurString))
          {
            if (this.ValeurString == "true" || this.ValeurString == "false")
            { // string qui contient true ou false ==> bool
              this.Type = EJsonType.Bool;
              this.ValeurBool = this.ValeurString == "true";
            }
            else
            {
              DateTime dt;
              if (DateTime.TryParse(this.ValeurString, out dt))
              { // string qui contient une date
                this.ValeurDate = dt;
                this.Type = EJsonType.Date;
              }
              else
              {
                double n;
                if (double.TryParse(this.ValeurString, out n))
                { // string qui contient un int
                  this.ValeurNumber = n;
                  this.Type = EJsonType.Number;
                }
              }
            }
          }
        }
        else if (this.valeur == "null" || string.IsNullOrWhiteSpace(this.valeur))
        { // null 
          this.Type = EJsonType.Null;
        }
        else if (this.valeur.StartsWith("{") && this.valeur.EndsWith("}") && this.valeur.Length >= 2)
        { // un objet
          this.Type = EJsonType.Object;
        }
        else if (this.valeur.StartsWith("[") && this.valeur.EndsWith("]") && this.valeur.Length >= 2)
        { // un tableau
          this.Type = EJsonType.Array;
        }
        else
        { // un ...
          double n;
          if (double.TryParse(this.valeur, out n))
          { // un number
            this.Type = EJsonType.Number;
            this.ValeurNumber = n;
          }
          else
          {
            throw new ArgumentException("Paramètre inconnu", "value");
          }
        }
      }
    }

    /// <summary>
    /// Valeur en string
    /// </summary>
    public string ValeurString { get; private set; }

    /// <summary>
    /// Valeur number de l'attribut
    /// </summary>
    public double? ValeurNumber { get; private set; }
    
    /// <summary>
    /// Valeur number en int de l'attribut
    /// </summary>
    public int ValeurInt 
    {
      get
      { 
        double? va = this.ValeurNumber;
        if (va.HasValue)
        {
          return Convert.ToInt32(va.Value);
        }

        return 0;
      }
    }

    /// <summary>
    /// Valeur Date de l'attribut
    /// </summary>
    public DateTime? ValeurDate { get; private set; }

    /// <summary>
    /// Renvoie un booleen
    /// </summary>
    public bool? ValeurBool { get; private set; }

    /// <summary>
    /// Renvoie une collection d'objet JSON
    /// </summary>
    public List<JsonObject> ValeurCll
    {
      get
      {
        if (this.Type == EJsonType.Array)
        { // y a ce qu'il faut
          return JsonObject.Parse(this.Valeur);
        }

        return null;
      }
    }

    /// <summary>
    /// Renvoie l'objet JSON
    /// </summary>
    public JsonObject ValeurObjet
    {
      get
      {
        if (this.Type == EJsonType.Object)
        { // y a ce qu'il faut
          List<JsonObject> lst = JsonObject.Parse(this.Valeur);
          if (lst != null && lst.Count == 1)
          {
            return lst.First();
          }
        }

        return null;
      }
    }

    /// <summary>
    /// pour affichage
    /// </summary>
    /// <returns>Le texte affiché</returns>
    public override string ToString()
    {
      return string.Format("{0} : {1}", this.Nom, this.Valeur);
    }
  }
}
