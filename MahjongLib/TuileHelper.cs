using System.Collections.Generic;
using System.Linq;

namespace MahjongLib
{
  /// <summary>
  /// Classe qui gèrer la liste des tuiles d'une manche
  /// </summary>
  public class TuileHelper
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="TuileHelper"/>
    /// </summary>
    /// <param name="withHonnors">La partie inclue les honneurs ou pas</param>
    internal TuileHelper(bool withHonnors)
    {
      this.WithHonnors = withHonnors;
      this.Jeu = new List<Tuile>();

      this.Jeu.Add(new Tuile("Vent d'est", "\U0001F000", (int)Vent.Est, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent d'est", "\U0001F000", (int)Vent.Est, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent d'est", "\U0001F000", (int)Vent.Est, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent d'est", "\U0001F000", (int)Vent.Est, EFamille.Vent));

      this.Jeu.Add(new Tuile("Vent du sud", "\U0001F001", (int)Vent.Sud, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent du sud", "\U0001F001", (int)Vent.Sud, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent du sud", "\U0001F001", (int)Vent.Sud, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent du sud", "\U0001F001", (int)Vent.Sud, EFamille.Vent));

      this.Jeu.Add(new Tuile("Vent d'ouest", "\U0001F002", (int)Vent.Ouest, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent d'ouest", "\U0001F002", (int)Vent.Ouest, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent d'ouest", "\U0001F002", (int)Vent.Ouest, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent d'ouest", "\U0001F002", (int)Vent.Ouest, EFamille.Vent));

      this.Jeu.Add(new Tuile("Vent du nord", "\U0001F003", (int)Vent.Nord, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent du nord", "\U0001F003", (int)Vent.Nord, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent du nord", "\U0001F003", (int)Vent.Nord, EFamille.Vent));
      this.Jeu.Add(new Tuile("Vent du nord", "\U0001F003", (int)Vent.Nord, EFamille.Vent));

      this.Jeu.Add(new Tuile("Dragon rouge", "\U0001F004", 1, EFamille.Dragon));
      this.Jeu.Add(new Tuile("Dragon rouge", "\U0001F004", 1, EFamille.Dragon));
      this.Jeu.Add(new Tuile("Dragon rouge", "\U0001F004", 1, EFamille.Dragon));
      this.Jeu.Add(new Tuile("Dragon rouge", "\U0001F004", 1, EFamille.Dragon));

      this.Jeu.Add(new Tuile("Dragon vert", "\U0001F005", 2, EFamille.Dragon));
      this.Jeu.Add(new Tuile("Dragon vert", "\U0001F005", 2, EFamille.Dragon));
      this.Jeu.Add(new Tuile("Dragon vert", "\U0001F005", 2, EFamille.Dragon));
      this.Jeu.Add(new Tuile("Dragon vert", "\U0001F005", 2, EFamille.Dragon));

      this.Jeu.Add(new Tuile("Dragon blanc", "\U0001F006", 3, EFamille.Dragon));
      this.Jeu.Add(new Tuile("Dragon blanc", "\U0001F006", 3, EFamille.Dragon));
      this.Jeu.Add(new Tuile("Dragon blanc", "\U0001F006", 3, EFamille.Dragon));
      this.Jeu.Add(new Tuile("Dragon blanc", "\U0001F006", 3, EFamille.Dragon));

      this.Jeu.Add(new Tuile("1 de caractère", "\U0001F007", 1, EFamille.Caractere));
      this.Jeu.Add(new Tuile("1 de caractère", "\U0001F007", 1, EFamille.Caractere));
      this.Jeu.Add(new Tuile("1 de caractère", "\U0001F007", 1, EFamille.Caractere));
      this.Jeu.Add(new Tuile("1 de caractère", "\U0001F007", 1, EFamille.Caractere));

      this.Jeu.Add(new Tuile("2 de caractère", "\U0001F008", 2, EFamille.Caractere));
      this.Jeu.Add(new Tuile("2 de caractère", "\U0001F008", 2, EFamille.Caractere));
      this.Jeu.Add(new Tuile("2 de caractère", "\U0001F008", 2, EFamille.Caractere));
      this.Jeu.Add(new Tuile("2 de caractère", "\U0001F008", 2, EFamille.Caractere));

      this.Jeu.Add(new Tuile("3 de caractère", "\U0001F009", 3, EFamille.Caractere));
      this.Jeu.Add(new Tuile("3 de caractère", "\U0001F009", 3, EFamille.Caractere));
      this.Jeu.Add(new Tuile("3 de caractère", "\U0001F009", 3, EFamille.Caractere));
      this.Jeu.Add(new Tuile("3 de caractère", "\U0001F009", 3, EFamille.Caractere));

      this.Jeu.Add(new Tuile("4 de caractère", "\U0001F00A", 4, EFamille.Caractere));
      this.Jeu.Add(new Tuile("4 de caractère", "\U0001F00A", 4, EFamille.Caractere));
      this.Jeu.Add(new Tuile("4 de caractère", "\U0001F00A", 4, EFamille.Caractere));
      this.Jeu.Add(new Tuile("4 de caractère", "\U0001F00A", 4, EFamille.Caractere));

      this.Jeu.Add(new Tuile("5 de caractère", "\U0001F00B", 5, EFamille.Caractere));
      this.Jeu.Add(new Tuile("5 de caractère", "\U0001F00B", 5, EFamille.Caractere));
      this.Jeu.Add(new Tuile("5 de caractère", "\U0001F00B", 5, EFamille.Caractere));
      this.Jeu.Add(new Tuile("5 de caractère", "\U0001F00B", 5, EFamille.Caractere));

      this.Jeu.Add(new Tuile("6 de caractère", "\U0001F00C", 6, EFamille.Caractere));
      this.Jeu.Add(new Tuile("6 de caractère", "\U0001F00C", 6, EFamille.Caractere));
      this.Jeu.Add(new Tuile("6 de caractère", "\U0001F00C", 6, EFamille.Caractere));
      this.Jeu.Add(new Tuile("6 de caractère", "\U0001F00C", 6, EFamille.Caractere));

      this.Jeu.Add(new Tuile("7 de caractère", "\U0001F00D", 7, EFamille.Caractere));
      this.Jeu.Add(new Tuile("7 de caractère", "\U0001F00D", 7, EFamille.Caractere));
      this.Jeu.Add(new Tuile("7 de caractère", "\U0001F00D", 7, EFamille.Caractere));
      this.Jeu.Add(new Tuile("7 de caractère", "\U0001F00D", 7, EFamille.Caractere));

      this.Jeu.Add(new Tuile("8 de caractère", "\U0001F00E", 8, EFamille.Caractere));
      this.Jeu.Add(new Tuile("8 de caractère", "\U0001F00E", 8, EFamille.Caractere));
      this.Jeu.Add(new Tuile("8 de caractère", "\U0001F00E", 8, EFamille.Caractere));
      this.Jeu.Add(new Tuile("8 de caractère", "\U0001F00E", 8, EFamille.Caractere));

      this.Jeu.Add(new Tuile("9 de caractère", "\U0001F00F", 9, EFamille.Caractere));
      this.Jeu.Add(new Tuile("9 de caractère", "\U0001F00F", 9, EFamille.Caractere));
      this.Jeu.Add(new Tuile("9 de caractère", "\U0001F00F", 9, EFamille.Caractere));
      this.Jeu.Add(new Tuile("9 de caractère", "\U0001F00F", 9, EFamille.Caractere));

      this.Jeu.Add(new Tuile("1 de bambou", "\U0001F010", 1, EFamille.Bambou));
      this.Jeu.Add(new Tuile("1 de bambou", "\U0001F010", 1, EFamille.Bambou));
      this.Jeu.Add(new Tuile("1 de bambou", "\U0001F010", 1, EFamille.Bambou));
      this.Jeu.Add(new Tuile("1 de bambou", "\U0001F010", 1, EFamille.Bambou));

      this.Jeu.Add(new Tuile("2 de bambou", "\U0001F011", 2, EFamille.Bambou));
      this.Jeu.Add(new Tuile("2 de bambou", "\U0001F011", 2, EFamille.Bambou));
      this.Jeu.Add(new Tuile("2 de bambou", "\U0001F011", 2, EFamille.Bambou));
      this.Jeu.Add(new Tuile("2 de bambou", "\U0001F011", 2, EFamille.Bambou));

      this.Jeu.Add(new Tuile("3 de bambou", "\U0001F012", 3, EFamille.Bambou));
      this.Jeu.Add(new Tuile("3 de bambou", "\U0001F012", 3, EFamille.Bambou));
      this.Jeu.Add(new Tuile("3 de bambou", "\U0001F012", 3, EFamille.Bambou));
      this.Jeu.Add(new Tuile("3 de bambou", "\U0001F012", 3, EFamille.Bambou));

      this.Jeu.Add(new Tuile("4 de bambou", "\U0001F013", 4, EFamille.Bambou));
      this.Jeu.Add(new Tuile("4 de bambou", "\U0001F013", 4, EFamille.Bambou));
      this.Jeu.Add(new Tuile("4 de bambou", "\U0001F013", 4, EFamille.Bambou));
      this.Jeu.Add(new Tuile("4 de bambou", "\U0001F013", 4, EFamille.Bambou));

      this.Jeu.Add(new Tuile("5 de bambou", "\U0001F014", 5, EFamille.Bambou));
      this.Jeu.Add(new Tuile("5 de bambou", "\U0001F014", 5, EFamille.Bambou));
      this.Jeu.Add(new Tuile("5 de bambou", "\U0001F014", 5, EFamille.Bambou));
      this.Jeu.Add(new Tuile("5 de bambou", "\U0001F014", 5, EFamille.Bambou));

      this.Jeu.Add(new Tuile("6 de bambou", "\U0001F015", 6, EFamille.Bambou));
      this.Jeu.Add(new Tuile("6 de bambou", "\U0001F015", 6, EFamille.Bambou));
      this.Jeu.Add(new Tuile("6 de bambou", "\U0001F015", 6, EFamille.Bambou));
      this.Jeu.Add(new Tuile("6 de bambou", "\U0001F015", 6, EFamille.Bambou));

      this.Jeu.Add(new Tuile("7 de bambou", "\U0001F016", 7, EFamille.Bambou));
      this.Jeu.Add(new Tuile("7 de bambou", "\U0001F016", 7, EFamille.Bambou));
      this.Jeu.Add(new Tuile("7 de bambou", "\U0001F016", 7, EFamille.Bambou));
      this.Jeu.Add(new Tuile("7 de bambou", "\U0001F016", 7, EFamille.Bambou));

      this.Jeu.Add(new Tuile("8 de bambou", "\U0001F017", 8, EFamille.Bambou));
      this.Jeu.Add(new Tuile("8 de bambou", "\U0001F017", 8, EFamille.Bambou));
      this.Jeu.Add(new Tuile("8 de bambou", "\U0001F017", 8, EFamille.Bambou));
      this.Jeu.Add(new Tuile("8 de bambou", "\U0001F018", 8, EFamille.Bambou));

      this.Jeu.Add(new Tuile("9 de bambou", "\U0001F018", 9, EFamille.Bambou));
      this.Jeu.Add(new Tuile("9 de bambou", "\U0001F018", 9, EFamille.Bambou));
      this.Jeu.Add(new Tuile("9 de bambou", "\U0001F018", 9, EFamille.Bambou));
      this.Jeu.Add(new Tuile("9 de bambou", "\U0001F018", 9, EFamille.Bambou));

      this.Jeu.Add(new Tuile("1 de cercle", "\U0001F019", 1, EFamille.Cercle));
      this.Jeu.Add(new Tuile("1 de cercle", "\U0001F019", 1, EFamille.Cercle));
      this.Jeu.Add(new Tuile("1 de cercle", "\U0001F019", 1, EFamille.Cercle));
      this.Jeu.Add(new Tuile("1 de cercle", "\U0001F019", 1, EFamille.Cercle));

      this.Jeu.Add(new Tuile("2 de cercle", "\U0001F01A", 2, EFamille.Cercle));
      this.Jeu.Add(new Tuile("2 de cercle", "\U0001F01A", 2, EFamille.Cercle));
      this.Jeu.Add(new Tuile("2 de cercle", "\U0001F01A", 2, EFamille.Cercle));
      this.Jeu.Add(new Tuile("2 de cercle", "\U0001F01A", 2, EFamille.Cercle));

      this.Jeu.Add(new Tuile("3 de cercle", "\U0001F01B", 3, EFamille.Cercle));
      this.Jeu.Add(new Tuile("3 de cercle", "\U0001F01B", 3, EFamille.Cercle));
      this.Jeu.Add(new Tuile("3 de cercle", "\U0001F01B", 3, EFamille.Cercle));
      this.Jeu.Add(new Tuile("3 de cercle", "\U0001F01B", 3, EFamille.Cercle));

      this.Jeu.Add(new Tuile("4 de cercle", "\U0001F01C", 4, EFamille.Cercle));
      this.Jeu.Add(new Tuile("4 de cercle", "\U0001F01C", 4, EFamille.Cercle));
      this.Jeu.Add(new Tuile("4 de cercle", "\U0001F01C", 4, EFamille.Cercle));
      this.Jeu.Add(new Tuile("4 de cercle", "\U0001F01C", 4, EFamille.Cercle));

      this.Jeu.Add(new Tuile("5 de cercle", "\U0001F01D", 5, EFamille.Cercle));
      this.Jeu.Add(new Tuile("5 de cercle", "\U0001F01D", 5, EFamille.Cercle));
      this.Jeu.Add(new Tuile("5 de cercle", "\U0001F01D", 5, EFamille.Cercle));
      this.Jeu.Add(new Tuile("5 de cercle", "\U0001F01D", 5, EFamille.Cercle));

      this.Jeu.Add(new Tuile("6 de cercle", "\U0001F01E", 6, EFamille.Cercle));
      this.Jeu.Add(new Tuile("6 de cercle", "\U0001F01E", 6, EFamille.Cercle));
      this.Jeu.Add(new Tuile("6 de cercle", "\U0001F01E", 6, EFamille.Cercle));
      this.Jeu.Add(new Tuile("6 de cercle", "\U0001F01E", 6, EFamille.Cercle));

      this.Jeu.Add(new Tuile("7 de cercle", "\U0001F01F", 7, EFamille.Cercle));
      this.Jeu.Add(new Tuile("7 de cercle", "\U0001F01F", 7, EFamille.Cercle));
      this.Jeu.Add(new Tuile("7 de cercle", "\U0001F01F", 7, EFamille.Cercle));
      this.Jeu.Add(new Tuile("7 de cercle", "\U0001F01F", 7, EFamille.Cercle));

      this.Jeu.Add(new Tuile("8 de cercle", "\U0001F020", 8, EFamille.Cercle));
      this.Jeu.Add(new Tuile("8 de cercle", "\U0001F020", 8, EFamille.Cercle));
      this.Jeu.Add(new Tuile("8 de cercle", "\U0001F020", 8, EFamille.Cercle));
      this.Jeu.Add(new Tuile("8 de cercle", "\U0001F020", 8, EFamille.Cercle));

      this.Jeu.Add(new Tuile("9 de cercle", "\U0001F021", 9, EFamille.Cercle));
      this.Jeu.Add(new Tuile("9 de cercle", "\U0001F021", 9, EFamille.Cercle));
      this.Jeu.Add(new Tuile("9 de cercle", "\U0001F021", 9, EFamille.Cercle));
      this.Jeu.Add(new Tuile("9 de cercle", "\U0001F021", 9, EFamille.Cercle));

      if (this.WithHonnors)
      {
        this.Jeu.Add(new Tuile("Fleur 1", "\U0001F022", (int)Vent.Est, EFamille.Fleur));
        this.Jeu.Add(new Tuile("Fleur 2", "\U0001F023", (int)Vent.Sud, EFamille.Fleur));
        this.Jeu.Add(new Tuile("Fleur 3", "\U0001F024", (int)Vent.Ouest, EFamille.Fleur));
        this.Jeu.Add(new Tuile("Fleur 4", "\U0001F025", (int)Vent.Nord, EFamille.Fleur));

        this.Jeu.Add(new Tuile("Saison 1 printemps", "\U0001F026", (int)Vent.Est, EFamille.Saison));
        this.Jeu.Add(new Tuile("Saison 2 été", "\U0001F027", (int)Vent.Sud, EFamille.Saison));
        this.Jeu.Add(new Tuile("Saison 3 automne", "\U0001F028", (int)Vent.Ouest, EFamille.Saison));
        this.Jeu.Add(new Tuile("Saison 4 hivers", "\U0001F029", (int)Vent.Nord, EFamille.Saison));
      }
    }

    /// <summary>
    /// Renvoie le texte encodé d'une tuile retournée
    /// </summary>
    public static string HidenTuile
    {
      get
      {
        return System.Text.RegularExpressions.Regex.Unescape("\U0001F02B");
      }
    }

    /// <summary>
    /// La liste des tuiles disponibles
    /// </summary>
    public List<Tuile> Jeu { get; private set; }

    /// <summary>
    /// La partie se fait avec les honneur ou pas ?
    /// </summary>
    public bool WithHonnors { get; private set; }

    /// <summary>
    /// Retire une tuile du jeu restant
    /// </summary>
    /// <param name="tuile">la tuile</param>
    /// <returns>True si ok</returns>
    public bool Remove(Tuile tuile)
    {
      var t = this.Jeu.Where(x => x.Equals(tuile));
      if (t.Any())
      { // y en a au moins une
        this.Jeu.Remove(tuile);
        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Ajoute la tuile au jeu restant
    /// </summary>
    /// <param name="tuile">la tuile</param>
    public void Add(Tuile tuile)
    {
      this.Jeu.Add(tuile);
    }
  }
}
