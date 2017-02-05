using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongWS.Services.Partie
{
  public class PartieResponse
  {
    /// <summary>
    /// Les infos sur la partie demandée
    /// </summary>
    MahjongLib.Partie Partie { get; set; }
  }
}
