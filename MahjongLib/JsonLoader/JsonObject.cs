using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib.JsonLoader
{
  /// <summary>
  /// Un objet JSon
  /// </summary>
  public class JsonObject
  {
    /// <summary>
    /// Les phases d'analyse
    /// </summary>
    private enum EJSonParserStatut
    {
      /// <summary>
      /// Trouver un début
      /// </summary>
      FindBegin,

      /// <summary>
      /// Trouver un attribut
      /// </summary>
      FindAttribut,

      /// <summary>
      /// Trouver une valeur
      /// </summary>
      FindValue,

      /// <summary>
      /// Trouve le prochain objet
      /// </summary>
      FindNext,

      /// <summary>
      /// Trouver une valeur de tableau
      /// </summary>
      FindArrayValue,
    }

    /// <summary>
    /// Les propriétés de l'objet
    /// </summary>
    public List<JsonAttribut> Properties { get; set; }
  
    /// <summary>
    /// Renvoie l'objet sous jascent dans le cas ou on a qu'une seule propriété
    /// </summary>
    public JsonObject GetObjet
    {
      get
      {
        if (this.Properties != null && this.Properties.Count == 1)
        {
          return this.Properties[0].ValeurObjet;
        }

        return null;
      }
    }

    /// <summary>
    /// indexeur de properties
    /// </summary>
    /// <param name="nom">le nom de la propriété</param>
    /// <returns>l'attribut demandé, null si non trouvé</returns>
    public JsonAttribut this[string nom]
    {
      get
      {
        return this.Properties.Where(x => x.Nom == nom).FirstOrDefault();
      }
    }

    /// <summary>
    /// Parse le texte et extrait les objets
    /// </summary>
    /// <param name="txt">le texte à parser</param>
    /// <returns>la liste des objets json trouvés</returns>
    public static List<JsonObject> Parse(string txt)
    {
      if (string.IsNullOrWhiteSpace(txt))
      {
        return null;
      }

      // TODO : corriger cela : bug potentiel si on enregistre des valeurs de propriétés avec ces caractères
      txt = txt.Replace("\n", string.Empty).Replace("\r", string.Empty);

      List<JsonObject> res = new List<JsonObject>();
      int position = 0;
      EJSonParserStatut statut = EJSonParserStatut.FindBegin;
      List<JsonAttribut> attributs = new List<JsonAttribut>();
      string attributName = string.Empty;
      int compteurAcolades = 0;
      int compteurCrochets = 0;
      string tampon = string.Empty;
      char ch;
      while (position < txt.Length)
      {
        ch = txt[position];
        switch (statut)
        {
          case EJSonParserStatut.FindBegin:
            if (ch == '{')
            { // trouvé un objet
              statut = EJSonParserStatut.FindAttribut;
              tampon = string.Empty;
              attributs = new List<JsonAttribut>();
              compteurAcolades = 0;
              compteurCrochets = 0;
              position++;
            }
            else if (ch == '[')
            { // trouvé un tableau
              statut = EJSonParserStatut.FindArrayValue;
              tampon = string.Empty;
              attributs = new List<JsonAttribut>();
              compteurAcolades = 0;
              compteurCrochets = 0;
              position++;
            }
            else if (!char.IsSeparator(ch) && !char.IsControl(ch))
            {
              throw new Exception(string.Format("Erreur de parsing : impossible de trouver '{' trouvé {0} à la position : {1}", ch, position));
            }
            else
            { // y a des espaces avant : on les absorbent
              position++;
            }

            break;
          case EJSonParserStatut.FindAttribut:
            if (ch == ':')
            { // trouvé ce qu'on cherche
              if (string.IsNullOrWhiteSpace(tampon))
              {
                throw new Exception(string.Format("Erreur de parsing : Trouvé ':' sans attribut devant à la position : {0}", position));
              }
              else
              {
                attributName = tampon.Trim();
                if (!attributName.StartsWith("\"") || !attributName.EndsWith("\"") || attributName.Length < 3)
                {
                  throw new Exception(string.Format("Erreur de parsing : Trouvé ':' l'attribut '{0}' n'est pas entre Quotes ou est vide devant à la position : {1}", attributName, position));
                }
                else
                {
                  attributName = attributName.Substring(1, attributName.Length - 2);
                  tampon = string.Empty;
                  compteurAcolades = 0;
                  compteurCrochets = 0;
                  statut = EJSonParserStatut.FindValue;
                  position++;
                }
              }
            }
            else
            {
              tampon += ch;
              position++;
            }

            break;
          case EJSonParserStatut.FindArrayValue:
          case EJSonParserStatut.FindValue:
            if (ch == '}' && compteurAcolades <= 0 && compteurCrochets <= 0)
            { // trouvé ce qu'on cherche : la fin de l'objet en cours
              attributs.Add(new JsonAttribut()
                                  {
                                    Nom = attributName,
                                    Valeur = tampon.Trim()
                                  });
              res.Add(new JsonObject() { Properties = attributs });
              tampon = string.Empty;
              statut = EJSonParserStatut.FindNext;
              position++;
            }
            else if (ch == ']' && statut == EJSonParserStatut.FindArrayValue && compteurAcolades <= 0 && compteurCrochets <= 0)
            { // dernier élément du tableau
              attributs = new List<JsonAttribut>();
              attributs.Add(new JsonAttribut() { Valeur = tampon.Trim() });
              res.Add(new JsonObject() { Properties = attributs });
              tampon = string.Empty;
              statut = EJSonParserStatut.FindNext;
              position++;
            }
            else if (ch == ',' && compteurAcolades <= 0 && compteurCrochets <= 0)
            { // trouvé ce qu'on cherche : la fin de l'attribut en cours
              if (statut == EJSonParserStatut.FindValue)
              {
                attributs.Add(new JsonAttribut()
                                    {
                                      Nom = attributName,
                                      Valeur = tampon.Trim()
                                    });
                tampon = string.Empty;
                attributName = string.Empty;
                statut = EJSonParserStatut.FindAttribut;
                position++;
              }
              else
              { // dans un array
                attributs = new List<JsonAttribut>();
                attributs.Add(new JsonAttribut() { Valeur = tampon.Trim() });
                res.Add(new JsonObject() { Properties = attributs });
                tampon = string.Empty;
                position++;
              }
            }
            else if (ch == '}' && (compteurAcolades > 0 || compteurCrochets > 0))
            { // trouvé fin d'un objet
              compteurAcolades--;
              tampon += ch;
              position++;
            }
            else if (ch == '[')
            { // trouvé début d'un tableau
              compteurCrochets++;
              tampon += ch;
              position++;
            }
            else if (ch == ']')
            { // trouvé fin d'un tableau
              compteurCrochets--;
              tampon += ch;
              position++;
            }
            else if (ch == '{')
            { // trouvé début d'un objet
              compteurAcolades++;
              tampon += ch;
              position++;
            }
            else
            { // trouvé n'importe quel caractère
              tampon += ch;
              position++;
            }

            break;
          case EJSonParserStatut.FindNext:
            if (ch == ',')
            { // trouvé ce quon cherche
              attributs = new List<JsonAttribut>();
              tampon = string.Empty;
              statut = EJSonParserStatut.FindBegin;
              position++;
            }
            else if (!char.IsSeparator(ch) && !char.IsControl(ch))
            {
              throw new Exception(string.Format("Erreur de parsing : impossible de trouver ',' trouvé {0} à la position : {1}", ch, position));
            }
            else
            { // y a des espaces avant : on les absorbent
              position++;
            }

            break;
        }
      }

      return res;
    }

    /// <summary>
    /// Pour affichage
    /// </summary>
    /// <returns>le texte à afficher</returns>
    public override string ToString()
    {
      return string.Format("{0} properties", this.Properties.Count);
    }

    /// <summary>
    /// Indique si l'objet dispose de toutes les propriété fournies
    /// </summary>
    /// <param name="attributeNames">la liste des attributs a avoir </param>
    /// <returns>True s'il sont tous présents</returns>
    public bool HasAttributtes(JsonAttribut[] attributeNames)
    {
      return !attributeNames.Except(this.Properties, new AttributLoadComparer()).Any();
    }

    /// <summary>
    /// Indique si l'attribut existe ou pas
    /// </summary>
    /// <param name="attributeName">le nom de l'attribut</param>
    /// <returns>true s'il existe</returns>
    public bool HasAttributte(string attributeName)
    {
      return this.Properties.Where(x => x.Nom == attributeName).Any();
    }
  }
}
