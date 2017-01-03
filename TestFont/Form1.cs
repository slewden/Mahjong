using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MahjongLib;

namespace TestFont
{
  public partial class Form1 : Form
  {
    Partie my;
    private Groupe newGroup = null;
    private string lesTuiles;

    public Form1()
    {
      InitializeComponent();

      StringBuilder t = new StringBuilder();
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F000"));   // Vent d'est
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F001"));   // Vent du sud
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F002"));   // Vent d'ouest
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F003"));   // Vent du Nord
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F004"));   // Dragon rouge
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F005"));   // Dragon vert
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F006"));   // Dragon blanc
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F007"));   // 1 de caractères
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F008"));   // 2 de caractères
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F009"));   // 3 de caractères
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00A"));   // 4 de caractères
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00B"));   // 5 de caractères
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00C"));   // 6 de caractères
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00D"));   // 7 de caractères
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00E"));   // 8 de caractères
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00F"));   // 9 de caractères
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F010"));   // 1 de bambou
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F011"));   // 2 de bambou
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F012"));   // 3 de bambou
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F013"));   // 4 de bambou
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F014"));   // 5 de bambou
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F015"));   // 6 de bambou
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F016"));   // 7 de bambou
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F017"));   // 8 de bambou
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F018"));   // 9 de bambou
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F019"));   // 1 de cercle
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01A"));   // 2 de cercle
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01B"));   // 3 de cercle
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01C"));   // 4 de cercle
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01D"));   // 5 de cercle
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01E"));   // 6 de cercle
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01F"));   // 7 de cercle
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F020"));   // 8 de cercle
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F021"));   // 9 de cercle
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F022"));   // fleur 1
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F023"));   // fleur 2
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F024"));   // fleur 3
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F025"));   // fleur 4
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F026"));   // saison 1 : printemps
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F027"));   // saison 2 : été
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F028"));   // saison 3 : automne
      t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F029"));   // saison 5 : hivers

      this.lesTuiles = t.ToString();  //"\U0001F000 \U0001F001"
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      //this.listBox1.Items.AddRange(th.Jeu.ToArray());

      this.GereBouton();
    }

    private void BtStartPartie_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(this.txtVentEst.Text) && !string.IsNullOrWhiteSpace(this.txtVentSud.Text) && !string.IsNullOrWhiteSpace(this.txtVentOuest.Text) && !string.IsNullOrWhiteSpace(this.txtVentNord.Text))
      {
        List<string> joueurs = new List<string>();
        joueurs.Add(this.txtVentEst.Text);
        joueurs.Add(this.txtVentSud.Text);
        joueurs.Add(this.txtVentOuest.Text);
        joueurs.Add(this.txtVentNord.Text);
        this.my = new Partie(DateTime.Now, "Test", joueurs, false); // pas d'honneur 

        // ajout du premier tour
        this.my.AddTour(my.Joueurs[0], my.Joueurs[1], my.Joueurs[2], my.Joueurs[3]);

        this.cbJoueurScore.Items.Clear();
        this.cbJoueurScore.Items.Add(this.my.Joueurs[0]);
        this.cbJoueurScore.Items.Add(this.my.Joueurs[1]);
        this.cbJoueurScore.Items.Add(this.my.Joueurs[2]);
        this.cbJoueurScore.Items.Add(this.my.Joueurs[3]);

        this.GereBouton();
      }
    }

    private void BtStartManche_Click(object sender, EventArgs e)
    {
      int idx = this.cbVentDominant.SelectedIndex;
      if (idx >= 0)
      {
        Manche m = this.my.AddManche((Vent)idx);

        this.GereBouton();
      }
    }

    private void cbVentDominant_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    private void NomVent_TextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    private void CbJoueurScore_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.DisplayMainJoueur();
    }

    private void LstTuiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    private void BtAddToCurrentCombinaison_Click(object sender, EventArgs e)
    {
      if (this.lstTuiles.SelectedItem != null && this.cbJoueurScore.SelectedItem != null)
      { // ajoute la tuile choisie à la combinaison en cours
        Tuile t = this.lstTuiles.SelectedItem as Tuile;
        if (t != null)
        { // une tuile est sélectionnée
          Manche m = this.my.Manche;
          Joueur j = this.cbJoueurScore.SelectedItem as Joueur;
          Groupe g = this.lstCombinaison.SelectedItem as Groupe;
          if (m != null && j != null)
          {
            this.newGroup = m.AddTuile(j, g, t); // TODO gérer caché montrée
          }
        }


        this.DisplayMainJoueur();
      }
    }

    private void LstCombinaison_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.lstDetailGroupe.Items.Clear();
      Groupe grp = this.lstCombinaison.SelectedItem as Groupe;
      if (grp != null)
      {
        this.lstDetailGroupe.Items.AddRange(grp.Tuiles.ToArray());
        this.DisplayDetailCombinaison();
      }
    }

    private void LstDetailGroupe_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    private void BtUnselCombinaison_Click(object sender, EventArgs e)
    {
      this.lstCombinaison.SelectedItem = null;
      this.GereBouton();
    }

    private void BtRemoveTuileFromGroupe_Click(object sender, EventArgs e)
    {
      Tuile tl = this.lstDetailGroupe.SelectedItem as Tuile;
      Groupe g = this.lstCombinaison.SelectedItem as Groupe;
      Joueur j = this.cbJoueurScore.SelectedItem as Joueur;
      if (g != null && tl != null && j != null)
      {
        Manche m = this.my.Manche;
        m.RemoveTuile(j, g, tl);
        this.DisplayMainJoueur();
      }
    }

    private void BtSwapGroupVisible_Click(object sender, EventArgs e)
    {
      Groupe g = this.lstCombinaison.SelectedItem as Groupe;
      Joueur j = this.cbJoueurScore.SelectedItem as Joueur;
      if (g != null && j != null)
      {
        g.Expose = !g.Expose;
        g.Compute(this.my.Manche.Parametre(j));

        this.DisplayMainJoueur();
      }
    }

    private void BtCloreManche_Click(object sender, EventArgs e)
    {
      this.my.Manche.Complete = true;
      this.GereBouton();
    }

    private void DisplayMainJoueur()
    {
      var sel = this.lstCombinaison.SelectedItem; 
      this.lstCombinaison.Items.Clear();
      this.lstTuiles.Items.Clear();
      this.lstDetailGroupe.Items.Clear();
      this.lblNombreTuile.Text = string.Empty;

      if (this.my == null || this.my.Manche == null || this.cbJoueurScore.SelectedItem == null)
      { // y a pas les données qui vont bien
        return;
      }

      this.lstTuiles.Items.AddRange(this.my.Manche.Tuiles.Jeu.Distinct().ToArray());

      Joueur j = this.cbJoueurScore.SelectedItem as Joueur;
      if (j == null)
      {
        return;
      }

      MainJoueur main = this.my.Manche.Main(j);
      if (main != null)
      {
        this.lstCombinaison.Items.AddRange(main.Groupes.ToArray());
        this.lblNombreTuile.Text = main.Groupes.Select(x => x.Tuiles.Count).Sum().ToString();
      }

      if (this.newGroup != null && this.lstCombinaison.Items.Contains(this.newGroup))
      {
        this.lstCombinaison.SelectedItem = this.newGroup;
        this.newGroup = null;
      }
      else if (sel != null && this.lstCombinaison.Items.Contains(sel))
      {
        this.lstCombinaison.SelectedItem = sel;
      }
      
      this.GereBouton();
    }

    private void GereBouton()
    {
      this.groupBox1.Visible = false;
      this.groupBox2.Visible = false;
      this.groupBox3.Visible = false;

      if (this.my == null)
      { // pas de partie en cours
        this.groupBox1.Visible = true;
        this.btStatPartie.Enabled = !string.IsNullOrWhiteSpace(this.txtVentEst.Text) && !string.IsNullOrWhiteSpace(this.txtVentSud.Text) && !string.IsNullOrWhiteSpace(this.txtVentOuest.Text) && !string.IsNullOrWhiteSpace(this.txtVentNord.Text);
      }
      else if (this.my.MancheComplete)
      { // manche pas débutée
        this.groupBox2.Visible = true;
        this.groupBox2.Text = string.Format("Manche N° {0}", this.my.NumeroDeManche + 2); // +1 pour commencer à 1 et +1 pour indique ce c'est la prochaine manche qui va démarrer
        this.btStartManche.Enabled = this.cbVentDominant.SelectedItem != null;

        this.cbJoueurScore.SelectedItem = null;
      }
      else if (this.cbJoueurScore.SelectedItem == null)
      { // sélection du score d'un joueur
        this.groupBox3.Visible = true;
        this.groupBox3.Text = string.Format("Manche N° {0} Vent dominant {1}", this.my.NumeroDeManche + 1, this.my.Manche.VentDominant);
        this.panel1.Visible = false;
      }
      else
      {
        this.groupBox3.Visible = true;
        this.groupBox3.Text = string.Format("Manche N° {0} Vent dominant {1}", this.my.NumeroDeManche + 1, this.my.Manche.VentDominant);
        this.panel1.Visible = true;

        this.btAddToCurrentCombinaison.Enabled = this.lstTuiles.SelectedItem != null;
        this.btCloreManche.Visible = this.my.Manche.CanComplete;

        this.lblTotalJoueur.Text = string.Empty;
        this.lblTotalPoints.Text = string.Empty;
        this.lblDouble.Text = string.Empty;
        this.lblResultat.Text = string.Empty;
        this.lblMahjong.Visible = false;
        Joueur j = this.cbJoueurScore.SelectedItem as Joueur;
        if (j != null)
        {
          Manche m = this.my.Manche;
          if (m != null)
          {
            AnalyseParam param = m.Parametre(j);
            Points pts = m.Main(j).TotalPoints(param);
            this.lblTotalPoints.Text = pts.Nombre > 0 ? pts.Nombre.ToString() : string.Empty;
            this.lblDouble.Text = pts.Doubles > 0 ? "x " + pts.Doubles.ToString() : string.Empty;
            this.lblTotalJoueur.Text = pts.Total > 0 ? pts.Total.ToString() : string.Empty;
            this.lblResultat.Text = (pts.NombreCombinaison > 0 ? string.Format("{0} {1}", pts.NombreCombinaison, pts.NombreCombinaison > 1 ? "Combinaisons" : "Combinaison") : string.Empty) +
              (pts.NombrePaire > 0 && pts.NombreCombinaison > 0 ? " et " : string.Empty) +
              (pts.NombrePaire > 0 ? string.Format("{0} {1}", pts.NombrePaire, pts.NombrePaire > 1 ? "Paires" : "Paire") : string.Empty);
            this.lblMahjong.Visible = pts.Mahjong;
            if (pts.Mahjong)
            {
              this.lblMahjong.Text = string.Format("Mahjong \n+{0} x {1}", pts.NombreMahjong, pts.DoublesMahjong);
            }
          }
        }

        this.DisplayDetailCombinaison();

        Tuile tl = this.lstTuiles.SelectedItem as Tuile; 
        this.label1.Text = tl == null ? string.Empty : tl.Nom;
        tl = this.lstDetailGroupe.SelectedItem as Tuile;
        this.label2.Text = tl == null ? string.Empty : tl.Nom;
      }
    }

    private void DisplayDetailCombinaison()
    {
      Groupe grp = this.lstCombinaison.SelectedItem as Groupe;
      if (grp != null)
      {
        this.btSwapGroupVisible.Text = grp.Expose ? "Masquer" : "Visible";
        this.lblCombinaison.Text = grp.Libelle();
        this.btRemoveTuileFromGroupe.Enabled = this.lstDetailGroupe.SelectedItem != null;
        this.btSwapGroupVisible.Visible = true;
        this.btUnselCombinaison.Enabled = true;
      }
      else
      {
        this.lblCombinaison.Text = string.Empty;
        this.btRemoveTuileFromGroupe.Enabled = false;
        this.btSwapGroupVisible.Visible = false;
        this.btUnselCombinaison.Enabled = false;
      }
    }
  }
}
