using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongWS.Services.Partie
{
  /// <summary>
  /// Classe requete pour une partie
  /// </summary>
  public class PartieRequest : RequestBase
  {
    /// <summary>
    /// La clé de la partie demandée
    /// </summary>
    public int Cle { get; set; }
  }
}
