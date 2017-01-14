using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MahjongLib.JsonLoader;

namespace TestFont
{
  /// <summary>
  /// Test de mise au point du json 
  /// </summary>
  public partial class FTestJson : Form
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FTestJson" />.
    /// </summary>
    public FTestJson()
    {
      this.InitializeComponent();
      this.Changement(null, null);
      this.Clear();
    }

    /// <summary>
    /// Changement dans la page
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void Changement(object sender, EventArgs e)
    {
      this.btParse.Enabled = !string.IsNullOrWhiteSpace(this.txtFile.Text) && File.Exists(this.txtFile.Text);
    }

    /// <summary>
    /// Changement du fichier
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void BtBrowse_Click(object sender, EventArgs e)
    {
      this.openFileDialog1.InitialDirectory = Application.StartupPath;
      this.openFileDialog1.FileName = this.txtFile.Text;
      if (this.openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
      {
        this.txtFile.Text = this.openFileDialog1.FileName;
        this.Changement(null, null);
      }
    }

    /// <summary>
    /// Démarre le parsing
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void BtParse_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtFile.Text) || !File.Exists(this.txtFile.Text))
      {
        return;
      }

      string txt = File.ReadAllText(this.txtFile.Text);
      if (!string.IsNullOrWhiteSpace(txt))
      {
        List<JsonObject> objects = JsonObject.Parse(txt);
        this.listBox1.Items.Clear();
        this.listBox2.Items.Clear();
        foreach (var o in objects)
        {
          this.listBox1.Items.Add(o);
        }
      }
    }

    /// <summary>
    /// Changement de sélection
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.listBox2.Items.Clear();
      JsonObject o = this.listBox1.SelectedItem as JsonObject;
      if (o != null)
      {
        foreach (var p in o.Properties)
        {
          this.listBox2.Items.Add(p);
        }

        this.Clear();
      }
    }

    /// <summary>
    /// RAZ des données
    /// </summary>
    private void Clear()
    {
      this.lblAttribut.Text = string.Empty;
      this.lblValue.Text = string.Empty;
      this.lblDate.Text = string.Empty;
      this.lblInt.Text = string.Empty;
      this.lblBool.Text = string.Empty;
      this.listBox3.Items.Clear();
      this.listBox4.Items.Clear();
    }

    /// <summary>
    /// Choix d'un niveau N°2
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Clear();
      JsonAttribut a = this.listBox2.SelectedItem as JsonAttribut;
      if (a != null)
      {
        this.lblAttribut.Text = a.Nom;
        this.lblValue.Text = a.Valeur;
        this.lblDate.Text = a.ValeurDate != null ? a.ValeurDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
        this.lblInt.Text = a.ValeurNumber != null ? a.ValeurInt.ToString() : string.Empty;
        this.lblBool.Text = a.ValeurBool != null ? (a.ValeurBool.Value ? "True" : "False") : string.Empty;
        List<JsonObject> cll = a.ValeurCll;
        if (cll != null && cll.Any())
        {
          foreach (var p in cll)
          {
            this.listBox3.Items.Add(p);
          }
        }
      }
    }

    /// <summary>
    /// Choix d'un niveau N°3
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.listBox4.Items.Clear();
      JsonObject o = this.listBox3.SelectedItem as JsonObject;
      if (o != null)
      {
        foreach (var p in o.Properties)
        {
          this.listBox4.Items.Add(p);
        }
      }
    }
  }
}
