namespace TestFont
{
  partial class Form1
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.lstTuiles = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btStatPartie = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtVentNord = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtVentOuest = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtVentSud = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtVentEst = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.cbVentDominant = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.btStartManche = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.mahjongNone = new System.Windows.Forms.RadioButton();
      this.mahjongFaitMur = new System.Windows.Forms.RadioButton();
      this.mahjongKongExpose = new System.Windows.Forms.RadioButton();
      this.mahjongFaitLastMur = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblMahjong = new System.Windows.Forms.Label();
      this.lblResultat = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.lblTotalPoints = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.lblDouble = new System.Windows.Forms.Label();
      this.lblTotalJoueur = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.lblCombinaison = new System.Windows.Forms.Label();
      this.btSwapGroupVisible = new System.Windows.Forms.Button();
      this.btCloreManche = new System.Windows.Forms.Button();
      this.lblNombreTuile = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.btUnselCombinaison = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.btRemoveTuileFromGroupe = new System.Windows.Forms.Button();
      this.lstDetailGroupe = new System.Windows.Forms.ListBox();
      this.btAddToCurrentCombinaison = new System.Windows.Forms.Button();
      this.lstCombinaison = new System.Windows.Forms.ListBox();
      this.label9 = new System.Windows.Forms.Label();
      this.cbJoueurScore = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.lbldetailPoints = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lstTuiles
      // 
      this.lstTuiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstTuiles.ColumnWidth = 45;
      this.lstTuiles.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lstTuiles.FormattingEnabled = true;
      this.lstTuiles.IntegralHeight = false;
      this.lstTuiles.ItemHeight = 65;
      this.lstTuiles.Location = new System.Drawing.Point(765, 0);
      this.lstTuiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lstTuiles.MultiColumn = true;
      this.lstTuiles.Name = "lstTuiles";
      this.lstTuiles.Size = new System.Drawing.Size(493, 374);
      this.lstTuiles.TabIndex = 0;
      this.lstTuiles.SelectedIndexChanged += new System.EventHandler(this.LstTuiles_SelectedIndexChanged);
      this.lstTuiles.DoubleClick += new System.EventHandler(this.BtAddToCurrentCombinaison_Click);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(761, 376);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 21);
      this.label1.TabIndex = 1;
      this.label1.Text = "label1";
      // 
      // btStatPartie
      // 
      this.btStatPartie.Location = new System.Drawing.Point(21, 193);
      this.btStatPartie.Name = "btStatPartie";
      this.btStatPartie.Size = new System.Drawing.Size(271, 45);
      this.btStatPartie.TabIndex = 3;
      this.btStatPartie.Text = "Démarrer partie";
      this.btStatPartie.UseVisualStyleBackColor = true;
      this.btStatPartie.Click += new System.EventHandler(this.BtStartPartie_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.txtVentNord);
      this.groupBox1.Controls.Add(this.btStatPartie);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.txtVentOuest);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.txtVentSud);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.txtVentEst);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Location = new System.Drawing.Point(18, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(472, 255);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Début de partie :";
      // 
      // txtVentNord
      // 
      this.txtVentNord.Location = new System.Drawing.Point(123, 145);
      this.txtVentNord.Name = "txtVentNord";
      this.txtVentNord.Size = new System.Drawing.Size(343, 29);
      this.txtVentNord.TabIndex = 7;
      this.txtVentNord.Text = "J4";
      this.txtVentNord.TextChanged += new System.EventHandler(this.NomVent_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(17, 148);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(100, 21);
      this.label6.TabIndex = 6;
      this.label6.Text = "Vent du nord";
      // 
      // txtVentOuest
      // 
      this.txtVentOuest.Location = new System.Drawing.Point(123, 110);
      this.txtVentOuest.Name = "txtVentOuest";
      this.txtVentOuest.Size = new System.Drawing.Size(343, 29);
      this.txtVentOuest.TabIndex = 5;
      this.txtVentOuest.Text = "J3";
      this.txtVentOuest.TextChanged += new System.EventHandler(this.NomVent_TextChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(17, 113);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(96, 21);
      this.label5.TabIndex = 4;
      this.label5.Text = "Vent d\'ouest";
      // 
      // txtVentSud
      // 
      this.txtVentSud.Location = new System.Drawing.Point(123, 75);
      this.txtVentSud.Name = "txtVentSud";
      this.txtVentSud.Size = new System.Drawing.Size(343, 29);
      this.txtVentSud.TabIndex = 3;
      this.txtVentSud.Text = "J2";
      this.txtVentSud.TextChanged += new System.EventHandler(this.NomVent_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(17, 78);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(92, 21);
      this.label4.TabIndex = 2;
      this.label4.Text = "Vent du sud";
      // 
      // txtVentEst
      // 
      this.txtVentEst.Location = new System.Drawing.Point(123, 40);
      this.txtVentEst.Name = "txtVentEst";
      this.txtVentEst.Size = new System.Drawing.Size(343, 29);
      this.txtVentEst.TabIndex = 1;
      this.txtVentEst.Text = "J1";
      this.txtVentEst.TextChanged += new System.EventHandler(this.NomVent_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(17, 43);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(78, 21);
      this.label3.TabIndex = 0;
      this.label3.Text = "Vent d\'est";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.cbVentDominant);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.btStartManche);
      this.groupBox2.Location = new System.Drawing.Point(18, 19);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(472, 166);
      this.groupBox2.TabIndex = 5;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Manche N°";
      // 
      // cbVentDominant
      // 
      this.cbVentDominant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbVentDominant.FormattingEnabled = true;
      this.cbVentDominant.Items.AddRange(new object[] {
            "Est",
            "Sud",
            "Ouest",
            "Nord"});
      this.cbVentDominant.Location = new System.Drawing.Point(239, 34);
      this.cbVentDominant.Name = "cbVentDominant";
      this.cbVentDominant.Size = new System.Drawing.Size(121, 29);
      this.cbVentDominant.TabIndex = 6;
      this.cbVentDominant.SelectedIndexChanged += new System.EventHandler(this.CbVentDominant_SelectedIndexChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(21, 37);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(212, 21);
      this.label7.TabIndex = 5;
      this.label7.Text = "Vent dominant de la manche ";
      // 
      // btStartManche
      // 
      this.btStartManche.Location = new System.Drawing.Point(25, 98);
      this.btStartManche.Name = "btStartManche";
      this.btStartManche.Size = new System.Drawing.Size(271, 45);
      this.btStartManche.TabIndex = 4;
      this.btStartManche.Text = "Démarrer manche";
      this.btStartManche.UseVisualStyleBackColor = true;
      this.btStartManche.Click += new System.EventHandler(this.BtStartManche_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox3.Controls.Add(this.groupBox4);
      this.groupBox3.Controls.Add(this.panel1);
      this.groupBox3.Controls.Add(this.cbJoueurScore);
      this.groupBox3.Controls.Add(this.label8);
      this.groupBox3.Location = new System.Drawing.Point(0, 0);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(1274, 744);
      this.groupBox3.TabIndex = 6;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "groupBox3";
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.mahjongNone);
      this.groupBox4.Controls.Add(this.mahjongFaitMur);
      this.groupBox4.Controls.Add(this.mahjongKongExpose);
      this.groupBox4.Controls.Add(this.mahjongFaitLastMur);
      this.groupBox4.Location = new System.Drawing.Point(490, 15);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(698, 78);
      this.groupBox4.TabIndex = 9;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Mahjong a été fait :";
      // 
      // mahjongNone
      // 
      this.mahjongNone.AutoSize = true;
      this.mahjongNone.Location = new System.Drawing.Point(6, 26);
      this.mahjongNone.Name = "mahjongNone";
      this.mahjongNone.Size = new System.Drawing.Size(212, 25);
      this.mahjongNone.TabIndex = 11;
      this.mahjongNone.TabStop = true;
      this.mahjongNone.Text = "en prenant une tuile posée";
      this.mahjongNone.UseVisualStyleBackColor = true;
      // 
      // mahjongFaitMur
      // 
      this.mahjongFaitMur.AutoSize = true;
      this.mahjongFaitMur.Location = new System.Drawing.Point(241, 28);
      this.mahjongFaitMur.Name = "mahjongFaitMur";
      this.mahjongFaitMur.Size = new System.Drawing.Size(195, 25);
      this.mahjongFaitMur.TabIndex = 10;
      this.mahjongFaitMur.TabStop = true;
      this.mahjongFaitMur.Text = "en piochant dans le mur";
      this.mahjongFaitMur.UseVisualStyleBackColor = true;
      this.mahjongFaitMur.CheckedChanged += new System.EventHandler(this.MahjongFait_CheckedChanged);
      // 
      // mahjongKongExpose
      // 
      this.mahjongKongExpose.AutoSize = true;
      this.mahjongKongExpose.Location = new System.Drawing.Point(490, 28);
      this.mahjongKongExpose.Name = "mahjongKongExpose";
      this.mahjongKongExpose.Size = new System.Drawing.Size(205, 25);
      this.mahjongKongExpose.TabIndex = 9;
      this.mahjongKongExpose.TabStop = true;
      this.mahjongKongExpose.Text = "en volant un kong exposé";
      this.mahjongKongExpose.UseVisualStyleBackColor = true;
      this.mahjongKongExpose.CheckedChanged += new System.EventHandler(this.MahjongFait_CheckedChanged);
      // 
      // mahjongFaitLastMur
      // 
      this.mahjongFaitLastMur.AutoSize = true;
      this.mahjongFaitLastMur.Location = new System.Drawing.Point(262, 51);
      this.mahjongFaitLastMur.Name = "mahjongFaitLastMur";
      this.mahjongFaitLastMur.Size = new System.Drawing.Size(196, 25);
      this.mahjongFaitLastMur.TabIndex = 7;
      this.mahjongFaitLastMur.Text = "La dernière tuile du mur";
      this.mahjongFaitLastMur.UseVisualStyleBackColor = true;
      this.mahjongFaitLastMur.CheckedChanged += new System.EventHandler(this.MahjongFait_CheckedChanged);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.lblMahjong);
      this.panel1.Controls.Add(this.lblResultat);
      this.panel1.Controls.Add(this.label14);
      this.panel1.Controls.Add(this.label13);
      this.panel1.Controls.Add(this.lblTotalPoints);
      this.panel1.Controls.Add(this.label12);
      this.panel1.Controls.Add(this.lblDouble);
      this.panel1.Controls.Add(this.lblTotalJoueur);
      this.panel1.Controls.Add(this.label11);
      this.panel1.Controls.Add(this.lblCombinaison);
      this.panel1.Controls.Add(this.btSwapGroupVisible);
      this.panel1.Controls.Add(this.btCloreManche);
      this.panel1.Controls.Add(this.lblNombreTuile);
      this.panel1.Controls.Add(this.label10);
      this.panel1.Controls.Add(this.btUnselCombinaison);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.btRemoveTuileFromGroupe);
      this.panel1.Controls.Add(this.lstDetailGroupe);
      this.panel1.Controls.Add(this.btAddToCurrentCombinaison);
      this.panel1.Controls.Add(this.lstCombinaison);
      this.panel1.Controls.Add(this.label9);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.lstTuiles);
      this.panel1.Controls.Add(this.lbldetailPoints);
      this.panel1.Location = new System.Drawing.Point(6, 99);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1262, 629);
      this.panel1.TabIndex = 5;
      // 
      // lblMahjong
      // 
      this.lblMahjong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.lblMahjong.Location = new System.Drawing.Point(18, 495);
      this.lblMahjong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMahjong.Name = "lblMahjong";
      this.lblMahjong.Size = new System.Drawing.Size(101, 44);
      this.lblMahjong.TabIndex = 23;
      this.lblMahjong.Text = "Mahjong";
      this.lblMahjong.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lblResultat
      // 
      this.lblResultat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblResultat.Location = new System.Drawing.Point(3, 444);
      this.lblResultat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblResultat.Name = "lblResultat";
      this.lblResultat.Size = new System.Drawing.Size(135, 51);
      this.lblResultat.TabIndex = 22;
      this.lblResultat.Text = "2500";
      this.lblResultat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(19, 423);
      this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(66, 21);
      this.label14.TabIndex = 21;
      this.label14.Text = "Résultat";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(33, 145);
      this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(52, 21);
      this.label13.TabIndex = 20;
      this.label13.Text = "Points";
      // 
      // lblTotalPoints
      // 
      this.lblTotalPoints.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTotalPoints.Location = new System.Drawing.Point(1, 166);
      this.lblTotalPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTotalPoints.Name = "lblTotalPoints";
      this.lblTotalPoints.Size = new System.Drawing.Size(133, 56);
      this.lblTotalPoints.TabIndex = 19;
      this.lblTotalPoints.Text = "2500";
      this.lblTotalPoints.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(33, 232);
      this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(65, 21);
      this.label12.TabIndex = 18;
      this.label12.Text = "doubles";
      // 
      // lblDouble
      // 
      this.lblDouble.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDouble.Location = new System.Drawing.Point(1, 253);
      this.lblDouble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblDouble.Name = "lblDouble";
      this.lblDouble.Size = new System.Drawing.Size(135, 56);
      this.lblDouble.TabIndex = 17;
      this.lblDouble.Text = "x 25";
      this.lblDouble.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lblTotalJoueur
      // 
      this.lblTotalJoueur.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTotalJoueur.Location = new System.Drawing.Point(1, 367);
      this.lblTotalJoueur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTotalJoueur.Name = "lblTotalJoueur";
      this.lblTotalJoueur.Size = new System.Drawing.Size(135, 56);
      this.lblTotalJoueur.TabIndex = 16;
      this.lblTotalJoueur.Text = "2500";
      this.lblTotalJoueur.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(18, 341);
      this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(93, 21);
      this.label11.TabIndex = 15;
      this.label11.Text = "Total Joueur";
      // 
      // lblCombinaison
      // 
      this.lblCombinaison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblCombinaison.AutoSize = true;
      this.lblCombinaison.Location = new System.Drawing.Point(887, 455);
      this.lblCombinaison.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblCombinaison.Name = "lblCombinaison";
      this.lblCombinaison.Size = new System.Drawing.Size(61, 21);
      this.lblCombinaison.TabIndex = 14;
      this.lblCombinaison.Text = "label11";
      // 
      // btSwapGroupVisible
      // 
      this.btSwapGroupVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btSwapGroupVisible.Location = new System.Drawing.Point(765, 444);
      this.btSwapGroupVisible.Name = "btSwapGroupVisible";
      this.btSwapGroupVisible.Size = new System.Drawing.Size(97, 43);
      this.btSwapGroupVisible.TabIndex = 13;
      this.btSwapGroupVisible.Text = "Masquer";
      this.btSwapGroupVisible.UseVisualStyleBackColor = true;
      this.btSwapGroupVisible.Click += new System.EventHandler(this.BtSwapGroupVisible_Click);
      // 
      // btCloreManche
      // 
      this.btCloreManche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btCloreManche.Location = new System.Drawing.Point(12, 542);
      this.btCloreManche.Name = "btCloreManche";
      this.btCloreManche.Size = new System.Drawing.Size(109, 55);
      this.btCloreManche.TabIndex = 12;
      this.btCloreManche.Text = "Clore la manche";
      this.btCloreManche.UseVisualStyleBackColor = true;
      this.btCloreManche.Click += new System.EventHandler(this.BtCloreManche_Click);
      // 
      // lblNombreTuile
      // 
      this.lblNombreTuile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblNombreTuile.AutoSize = true;
      this.lblNombreTuile.Location = new System.Drawing.Point(142, 600);
      this.lblNombreTuile.Name = "lblNombreTuile";
      this.lblNombreTuile.Size = new System.Drawing.Size(61, 21);
      this.lblNombreTuile.TabIndex = 11;
      this.lblNombreTuile.Text = "label11";
      // 
      // label10
      // 
      this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(6, 600);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(130, 21);
      this.label10.TabIndex = 10;
      this.label10.Text = "Nombre de tuiles";
      // 
      // btUnselCombinaison
      // 
      this.btUnselCombinaison.Location = new System.Drawing.Point(251, 61);
      this.btUnselCombinaison.Name = "btUnselCombinaison";
      this.btUnselCombinaison.Size = new System.Drawing.Size(75, 48);
      this.btUnselCombinaison.TabIndex = 9;
      this.btUnselCombinaison.Text = "UnSel";
      this.btUnselCombinaison.UseVisualStyleBackColor = true;
      this.btUnselCombinaison.Click += new System.EventHandler(this.BtUnselCombinaison_Click);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(640, 600);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(52, 21);
      this.label2.TabIndex = 8;
      this.label2.Text = "label2";
      // 
      // btRemoveTuileFromGroupe
      // 
      this.btRemoveTuileFromGroupe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btRemoveTuileFromGroupe.Location = new System.Drawing.Point(644, 444);
      this.btRemoveTuileFromGroupe.Name = "btRemoveTuileFromGroupe";
      this.btRemoveTuileFromGroupe.Size = new System.Drawing.Size(97, 43);
      this.btRemoveTuileFromGroupe.TabIndex = 7;
      this.btRemoveTuileFromGroupe.Text = "Retirer";
      this.btRemoveTuileFromGroupe.UseVisualStyleBackColor = true;
      this.btRemoveTuileFromGroupe.Click += new System.EventHandler(this.BtRemoveTuileFromGroupe_Click);
      // 
      // lstDetailGroupe
      // 
      this.lstDetailGroupe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstDetailGroupe.ColumnWidth = 66;
      this.lstDetailGroupe.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lstDetailGroupe.FormattingEnabled = true;
      this.lstDetailGroupe.HorizontalScrollbar = true;
      this.lstDetailGroupe.ItemHeight = 86;
      this.lstDetailGroupe.Location = new System.Drawing.Point(644, 507);
      this.lstDetailGroupe.MultiColumn = true;
      this.lstDetailGroupe.Name = "lstDetailGroupe";
      this.lstDetailGroupe.Size = new System.Drawing.Size(618, 90);
      this.lstDetailGroupe.TabIndex = 6;
      this.lstDetailGroupe.SelectedIndexChanged += new System.EventHandler(this.LstDetailGroupe_SelectedIndexChanged);
      this.lstDetailGroupe.DoubleClick += new System.EventHandler(this.BtRemoveTuileFromGroupe_Click);
      // 
      // btAddToCurrentCombinaison
      // 
      this.btAddToCurrentCombinaison.Location = new System.Drawing.Point(670, 29);
      this.btAddToCurrentCombinaison.Name = "btAddToCurrentCombinaison";
      this.btAddToCurrentCombinaison.Size = new System.Drawing.Size(75, 34);
      this.btAddToCurrentCombinaison.TabIndex = 5;
      this.btAddToCurrentCombinaison.Text = "<<";
      this.btAddToCurrentCombinaison.UseVisualStyleBackColor = true;
      this.btAddToCurrentCombinaison.Click += new System.EventHandler(this.BtAddToCurrentCombinaison_Click);
      // 
      // lstCombinaison
      // 
      this.lstCombinaison.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lstCombinaison.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lstCombinaison.FormattingEnabled = true;
      this.lstCombinaison.IntegralHeight = false;
      this.lstCombinaison.ItemHeight = 86;
      this.lstCombinaison.Location = new System.Drawing.Point(335, 0);
      this.lstCombinaison.Name = "lstCombinaison";
      this.lstCombinaison.Size = new System.Drawing.Size(303, 597);
      this.lstCombinaison.TabIndex = 3;
      this.lstCombinaison.SelectedIndexChanged += new System.EventHandler(this.LstCombinaison_SelectedIndexChanged);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(213, 18);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(113, 21);
      this.label9.TabIndex = 4;
      this.label9.Text = "Combinaisons ";
      // 
      // cbJoueurScore
      // 
      this.cbJoueurScore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbJoueurScore.FormattingEnabled = true;
      this.cbJoueurScore.Location = new System.Drawing.Point(146, 43);
      this.cbJoueurScore.Name = "cbJoueurScore";
      this.cbJoueurScore.Size = new System.Drawing.Size(288, 29);
      this.cbJoueurScore.TabIndex = 1;
      this.cbJoueurScore.SelectedIndexChanged += new System.EventHandler(this.CbJoueurScore_SelectedIndexChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(24, 46);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(116, 21);
      this.label8.TabIndex = 0;
      this.label8.Text = "Main du joueur";
      // 
      // lbldetailPoints
      // 
      this.lbldetailPoints.BackColor = System.Drawing.SystemColors.Control;
      this.lbldetailPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.lbldetailPoints.Location = new System.Drawing.Point(135, 145);
      this.lbldetailPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbldetailPoints.Name = "lbldetailPoints";
      this.lbldetailPoints.Size = new System.Drawing.Size(503, 383);
      this.lbldetailPoints.TabIndex = 24;
      this.lbldetailPoints.Text = "Détail points";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1276, 748);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox lstTuiles;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btStatPartie;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtVentNord;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtVentOuest;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtVentSud;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtVentEst;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button btStartManche;
    private System.Windows.Forms.ComboBox cbVentDominant;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.ComboBox cbJoueurScore;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ListBox lstCombinaison;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btAddToCurrentCombinaison;
    private System.Windows.Forms.ListBox lstDetailGroupe;
    private System.Windows.Forms.Button btRemoveTuileFromGroupe;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btUnselCombinaison;
    private System.Windows.Forms.Label lblNombreTuile;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button btCloreManche;
    private System.Windows.Forms.Button btSwapGroupVisible;
    private System.Windows.Forms.Label lblCombinaison;
    private System.Windows.Forms.Label lblTotalJoueur;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label lblDouble;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label lblTotalPoints;
    private System.Windows.Forms.Label lblResultat;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label lblMahjong;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.CheckBox mahjongFaitLastMur;
    private System.Windows.Forms.RadioButton mahjongKongExpose;
    private System.Windows.Forms.RadioButton mahjongFaitMur;
    private System.Windows.Forms.RadioButton mahjongNone;
    private System.Windows.Forms.Label lbldetailPoints;

  }
}

