namespace MahjongLib
{
  /// <summary>
  /// Les familles de tuiles
  /// </summary>
  public enum EFamille
  {
    /// <summary>
    /// Les caractères
    /// </summary>
    Caractere,

    /// <summary>
    /// Les bambous
    /// </summary>
    Bambou,

    /// <summary>
    /// Les cercles
    /// </summary>
    Cercle,

    /// <summary>
    /// Les vents 
    /// </summary>
    Vent,

    /// <summary>
    /// Les dragons
    /// </summary>
    Dragon,

    /// <summary>
    /// Les fleurs
    /// </summary>
    Fleur,

    /// <summary>
    /// Les saisons
    /// </summary>
    Saison
  }

  /// <summary>
  /// Les vents possibles (pour les joueurs)
  /// </summary>
  public enum Vent
  {
    /// <summary>
    /// Vent d'est
    /// </summary>
    Est = 0,

    /// <summary>
    /// Vent du sud
    /// </summary>
    Sud = 1,

    /// <summary>
    /// Vent d'ouest
    /// </summary>
    Ouest = 2,

    /// <summary>
    /// vent du nord
    /// </summary>
    Nord = 3
  }

  /// <summary>
  /// Les types de combinaisons (pour détecter 4 combinaisons et une paire !)
  /// </summary>
  public enum ETypeCombinaison
  {
    /// <summary>
    /// show, pung, kong
    /// </summary>
    Combinaison,

    /// <summary>
    /// la paire finale
    /// </summary>
    Paire,

    /// <summary>
    /// un ou plusieurs honneur
    /// </summary>
    Honneur
  }

  /// <summary>
  /// Classe d'extension pour les enums
  /// </summary>
  public static class EnumHelper
  {
    /// <summary>
    /// Indique si la famille est une famille ordinaire 
    /// </summary>
    /// <param name="famille">la famille</param>
    /// <returns>true si c'en est une</returns>
    public static bool IsOrdinaire(this EFamille famille)
    {
      switch (famille)
      {
        case EFamille.Bambou:
        case EFamille.Caractere:
        case EFamille.Cercle:
          return true;
      }

      return false;
    }

    /// <summary>
    /// Indique si la famille est un honneur (fleur ou saison)
    /// </summary>
    /// <param name="famille">la famille</param>
    /// <returns>true si c'est une fleur ou une saison</returns>
    public static bool IsHonneur(this EFamille famille)
    {
      switch (famille)
      {
        case EFamille.Fleur:
        case EFamille.Saison:
          return true;
      }

      return false;
    }
  }
}
