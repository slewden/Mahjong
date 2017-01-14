using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MahjongLib.JsonLoader;

namespace TestFont
{
  public partial class FTestJson : Form
  {
    public FTestJson()
    {
      this.InitializeComponent();
      this.Changement(null, null);
      this.Clear();
    }

    private void Changement(object sender, EventArgs e)
    {
      this.btParse.Enabled = !string.IsNullOrWhiteSpace(this.txtFile.Text) && File.Exists(this.txtFile.Text);
    }

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
