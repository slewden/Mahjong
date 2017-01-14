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
  /// <summary>
  /// Page de tests
  /// </summary>
  public partial class Form1 : Form
  {
    /// <summary>
    /// Objet partie
    /// </summary>
    private Partie my;

    /// <summary>
    /// Le groupe en cours
    /// </summary>
    private Groupe newGroup = null;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Form1"/>
    /// </summary>
    public Form1()
    {
      this.InitializeComponent();

      ////StringBuilder t = new StringBuilder();
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F000"));   // Vent d'est
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F001"));   // Vent du sud
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F002"));   // Vent d'ouest
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F003"));   // Vent du Nord
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F004"));   // Dragon rouge
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F005"));   // Dragon vert
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F006"));   // Dragon blanc
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F007"));   // 1 de caractères
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F008"));   // 2 de caractères
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F009"));   // 3 de caractères
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00A"));   // 4 de caractères
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00B"));   // 5 de caractères
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00C"));   // 6 de caractères
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00D"));   // 7 de caractères
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00E"));   // 8 de caractères
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F00F"));   // 9 de caractères
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F010"));   // 1 de bambou
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F011"));   // 2 de bambou
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F012"));   // 3 de bambou
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F013"));   // 4 de bambou
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F014"));   // 5 de bambou
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F015"));   // 6 de bambou
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F016"));   // 7 de bambou
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F017"));   // 8 de bambou
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F018"));   // 9 de bambou
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F019"));   // 1 de cercle
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01A"));   // 2 de cercle
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01B"));   // 3 de cercle
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01C"));   // 4 de cercle
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01D"));   // 5 de cercle
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01E"));   // 6 de cercle
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F01F"));   // 7 de cercle
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F020"));   // 8 de cercle
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F021"));   // 9 de cercle
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F022"));   // fleur 1
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F023"));   // fleur 2
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F024"));   // fleur 3
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F025"));   // fleur 4
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F026"));   // saison 1 : printemps
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F027"));   // saison 2 : été
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F028"));   // saison 3 : automne
      ////t.Append(System.Text.RegularExpressions.Regex.Unescape("\U0001F029"));   // saison 5 : hivers
    }

    #region Events
    /// <summary>
    /// Chargement de la page
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void Form1_Load(object sender, EventArgs e)
    {
      this.my = Partie.Load(System.IO.Path.Combine(Application.StartupPath, Partie.NOMDEFAULT));

      this.GereMahjongFait();
      this.GereBouton();
    }

    /// <summary>
    /// Fermeture de la page
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (this.my != null)
      {
        this.my.Save(Application.StartupPath);
      }
    }

    /// <summary>
    /// Démarre une partie
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
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
        this.my.AddTour(this.my.Joueurs[0], this.my.Joueurs[1], this.my.Joueurs[2], this.my.Joueurs[3]);        

        this.GereBouton();
      }
    }

    /// <summary>
    /// Démarre une manche
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtStartManche_Click(object sender, EventArgs e)
    {
      int idx = this.cbVentDominant.SelectedIndex;
      if (idx >= 0)
      {
        Manche m = this.my.AddManche((Vent)idx);
        this.mahjongNone.Checked = true;
        this.mahjongKongExpose.Checked = false;
        this.GereBouton();
      }
    }

    /// <summary>
    /// Changement du vent dominant
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void CbVentDominant_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Changement des noms des joueurs
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void NomVent_TextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Changement du choix du joueur affiché
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void CbJoueurScore_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.DisplayMainJoueur();
    }

    /// <summary>
    /// changement dans les option du mahjong fait
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void MahjongFait_CheckedChanged(object sender, EventArgs e)
    {
      this.GereMahjongFait();
    }

    /// <summary>
    /// changement de sélection d'une tuile
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LstTuiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Ajouter une tuile à la combinaison en cours
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtAddToCurrentCombinaison_Click(object sender, EventArgs e)
    {
      if (this.lstTuiles.SelectedItem != null && this.cbJoueurScore.SelectedItem != null)
      { // ajoute la tuile choisie à la combinaison en cours
        Tuile t = this.lstTuiles.SelectedItem as Tuile;
        if (t != null)
        { // une tuile est sélectionnée
          Manche m = this.my.Manche;
          Joueur j = this.cbJoueurScore.SelectedItem as Joueur;

          if (!m.JoueurComplet(j))
          {
            Groupe g = this.lstCombinaison.SelectedItem as Groupe;
            if (m != null && j != null)
            {
              this.newGroup = m.AddTuile(j, g, t); // TODO gérer caché montrée
            }
          }
          else
          {
            MessageBox.Show("main complète");
          }
        }

        this.DisplayMainJoueur();
      }
    }

    /// <summary>
    /// changement de combinaison sélectionnée
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LstCombinaison_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.lstDetailGroupe.Items.Clear();
      Groupe grp = this.lstCombinaison.SelectedItem as Groupe;
      if (grp != null)
      {
        this.lstDetailGroupe.Items.AddRange(grp.Tuiles.ToArray());
        this.DisplayDetailCombinaison();
        this.GereBouton();
      }
    }

    /// <summary>
    /// changement de la tuile sélectionnée
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LstDetailGroupe_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// désélection d'une combinaison
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtUnselCombinaison_Click(object sender, EventArgs e)
    {
      this.lstCombinaison.SelectedItem = null;
      this.GereBouton();
    }

    /// <summary>
    /// retire une tuile d'une combinaison
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
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

    /// <summary>
    /// affiche ou masque la combinaison
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtSwapGroupVisible_Click(object sender, EventArgs e)
    {
      Groupe g = this.lstCombinaison.SelectedItem as Groupe;
      Joueur j = this.cbJoueurScore.SelectedItem as Joueur;
      if (g != null && j != null)
      {
        g.Expose = !g.Expose;
        g.UpdateCombinaison(this.my.Manche.Parametre(j));

        this.DisplayMainJoueur();
      }
    }

    /// <summary>
    /// Efface le groupe en cours
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtClearGroup_Click(object sender, EventArgs e)
    {
      Groupe g = this.lstCombinaison.SelectedItem as Groupe;
      Joueur j = this.cbJoueurScore.SelectedItem as Joueur;
      if (g != null  && j != null)
      {
        Manche m = this.my.Manche;
        foreach (Tuile tl in this.lstDetailGroupe.Items)
        {
          m.RemoveTuile(j, g, tl);
        }

        this.DisplayMainJoueur();
      }
    }

    /// <summary>
    /// Clos une manche
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtCloreManche_Click(object sender, EventArgs e)
    {
      this.my.Manche.Complete = true;
      this.GereBouton();
    }

    /// <summary>
    /// Shake les tuiles de la main en cours : sans show
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtShake_Click(object sender, EventArgs e)
    {
      Joueur j = this.cbJoueurScore.SelectedItem as Joueur;
      Manche m = this.my.Manche;

      if (j != null && m != null)
      {
        MainJoueur mj = m.Main(j);
        AnalyseParam param = m.Parametre(j);
        mj.Shake(param);
        this.DisplayMainJoueur();
      }
    }
    #endregion

    #region Gestion de l'interface
    /// <summary>
    /// Affiche la main d'un joueur
    /// </summary>
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
        this.lstCombinaison.Items.Clear();
        this.lstCombinaison.Items.AddRange(main.Groupes.ToArray());
        this.lblNombreTuile.Text = main.Groupes.Select(x => x.Tuiles.Count).Sum().ToString();
        this.lblNombreTuile.ForeColor = this.my.Manche.JoueurComplet(j) ? Color.Red : SystemColors.ControlText;
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

    /// <summary>
    /// Gère la cohérence de l'affichage en fonction de l'objet métier
    /// </summary>
    private void GereBouton()
    {
      this.groupBox1.Visible = false;
      this.groupBox2.Visible = false;
      this.groupBox3.Visible = false;

      this.FillJoueur();

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
        this.btCloreManche.Visible = this.my.Manche.CanCompleteManche;

        this.lblTotalJoueur.Text = string.Empty;
        this.lblTotalPoints.Text = string.Empty;
        this.lblDouble.Text = string.Empty;
        this.lblResultat.Text = string.Empty;
        this.lbldetailPoints.Text = string.Empty;
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
              this.lblMahjong.Text = "Mahjong";
            }

            string str;
            if (pts.Nombre > 0)
            {
              str = string.Format("Détail des points\n+{0} Points", pts.Nombre);
            }
            else
            {
              str = "Détail des points\n+Aucun point";
            }

            this.lbldetailPoints.Text = pts.Motifs.Any() ? pts.Motifs.Aggregate(str, (x, y) => x + "\n" + y, x => x + string.Format("\nTotal : {0}", pts.Total)) : string.Empty;
          }
        }

        this.DisplayDetailCombinaison();

        Tuile tl = this.lstTuiles.SelectedItem as Tuile; 
        this.label1.Text = tl == null ? string.Empty : tl.Nom;
        tl = this.lstDetailGroupe.SelectedItem as Tuile;
        this.label2.Text = tl == null ? string.Empty : tl.Nom;
      }
    }

    /// <summary>
    /// Gère les options de mahjong fait
    /// </summary>
    private void GereMahjongFait()
    {
      this.mahjongFaitLastMur.Enabled = this.mahjongFaitMur.Checked;
      if (this.my != null)
      {
        Manche m = this.my.Manche;
        if (m != null)
        {
          m.MahjongAvecTuileDuMur = this.mahjongFaitMur.Checked;
          m.MahjongAvecDerniereTuileDuMur = this.mahjongFaitMur.Checked && this.mahjongFaitLastMur.Checked;
          m.MahjongEnVolantKongExpose = this.mahjongKongExpose.Checked;
          this.DisplayMainJoueur();
        }
      }
    }

    /// <summary>
    /// Remplit les infos de la main d'un joueur
    /// </summary>
    private void FillJoueur()
    {
      if (this.my != null)
      {
        if (this.cbJoueurScore.Items.Count == 0)
        {
          this.cbJoueurScore.Items.Clear();
          this.cbJoueurScore.Items.Add(this.my.Joueurs[0]);
          this.cbJoueurScore.Items.Add(this.my.Joueurs[1]);
          this.cbJoueurScore.Items.Add(this.my.Joueurs[2]);
          this.cbJoueurScore.Items.Add(this.my.Joueurs[3]);
        }
      }
      else
      {
        this.cbJoueurScore.Items.Clear();
      }
    }

    /// <summary>
    /// Affiche le détail d'une combinaison
    /// </summary>
    private void DisplayDetailCombinaison()
    {
      Groupe grp = this.lstCombinaison.SelectedItem as Groupe;
      this.btShake.Visible = this.lstCombinaison.Items.Count > 0;
      if (grp != null)
      {
        this.btSwapGroupVisible.Text = grp.Expose ? "Masquer" : "Visible";
        this.lblCombinaison.Text = grp.Libelle();
        this.btRemoveTuileFromGroupe.Enabled = this.lstDetailGroupe.SelectedItem != null;
        this.btSwapGroupVisible.Visible = true;
        this.btUnselCombinaison.Visible = true;
        this.btClearGroup.Visible = true;
      }
      else
      {
        this.lblCombinaison.Text = string.Empty;
        this.btRemoveTuileFromGroupe.Enabled = false;
        this.btSwapGroupVisible.Visible = false;
        this.btUnselCombinaison.Visible = false;
        this.btClearGroup.Visible = false;
      }
    }
    #endregion
  }
}
