using System;
using System.Windows.Forms;

namespace TestFont
{
  /// <summary>
  /// classe de démarrage pour le programme
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      
      Application.Run(new Form1());
      ////Application.Run(new FTestJson());
    }
  }
}
