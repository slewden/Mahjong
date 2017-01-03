using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongLib
{
  public class AnalyseParam
  {
    public int RangVentJoueur { get; set; }
    public int RangVentDominant { get; set; }
    public int RangVentDuTour { get; set; }
    public bool Expose { get; set; }

    public bool MahjongAvecTuileDuMur { get; set; }
    public bool MahjongAvecDerniereTuileDuMur { get; set; }
    public bool MahjongEnVolantKongExpose { get; set; }
  }

}
