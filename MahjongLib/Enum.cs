using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  public enum EFamille
  {
    Caractere,
    Bambou,
    Cercle,
    Vent,
    Dragon,
    Fleur,
    Saison
  }

  public enum Vent
  {
    Est = 0,
    Sud = 1,
    Ouest = 2,
    Nord = 3
  }
  public enum ETypeCombinaison
  {
    Combinaison,    // show, pung, kong
    Paire,          // la paire finale
    Honneur         // un ou plusieurs honneur
  }

  public static class EnumHelper
  {
    public static bool IsCommon(this EFamille famille)
    {
      switch(famille)
      {
        case EFamille.Bambou:
        case EFamille.Caractere:
        case EFamille.Cercle:
          return true;
      }

      return false;
    }
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
