namespace TestFont
{
  partial class FTestJson
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.txtFile = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btBrowse = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.btParse = new System.Windows.Forms.Button();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.listBox2 = new System.Windows.Forms.ListBox();
      this.lblDate = new System.Windows.Forms.Label();
      this.lblInt = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.listBox3 = new System.Windows.Forms.ListBox();
      this.listBox4 = new System.Windows.Forms.ListBox();
      this.lblAttribut = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.lblValue = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lblBool = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // txtFile
      // 
      this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtFile.Location = new System.Drawing.Point(56, 14);
      this.txtFile.Name = "txtFile";
      this.txtFile.Size = new System.Drawing.Size(892, 20);
      this.txtFile.TabIndex = 0;
      this.txtFile.Text = "C:\\Projets\\Mahjong\\MahjongSolution\\TestFont\\bin\\Debug\\mahjong_good.json";
      this.txtFile.TextChanged += new System.EventHandler(this.Changement);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Fichier";
      // 
      // btBrowse
      // 
      this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btBrowse.Location = new System.Drawing.Point(954, 12);
      this.btBrowse.Name = "btBrowse";
      this.btBrowse.Size = new System.Drawing.Size(75, 23);
      this.btBrowse.TabIndex = 2;
      this.btBrowse.Text = "...";
      this.btBrowse.UseVisualStyleBackColor = true;
      this.btBrowse.Click += new System.EventHandler(this.BtBrowse_Click);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.DefaultExt = "json";
      this.openFileDialog1.FileName = "openFileDialog1";
      this.openFileDialog1.Filter = "Fichier Json|*.json|Tous fichiers|*.*";
      this.openFileDialog1.Title = "Sélectionnez un fichier";
      // 
      // btParse
      // 
      this.btParse.Location = new System.Drawing.Point(15, 52);
      this.btParse.Name = "btParse";
      this.btParse.Size = new System.Drawing.Size(132, 31);
      this.btParse.TabIndex = 3;
      this.btParse.Text = "Analyser";
      this.btParse.UseVisualStyleBackColor = true;
      this.btParse.Click += new System.EventHandler(this.BtParse_Click);
      // 
      // listBox1
      // 
      this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.listBox1.FormattingEnabled = true;
      this.listBox1.IntegralHeight = false;
      this.listBox1.Location = new System.Drawing.Point(15, 104);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(299, 548);
      this.listBox1.TabIndex = 4;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
      // 
      // listBox2
      // 
      this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listBox2.FormattingEnabled = true;
      this.listBox2.IntegralHeight = false;
      this.listBox2.Location = new System.Drawing.Point(330, 104);
      this.listBox2.Name = "listBox2";
      this.listBox2.Size = new System.Drawing.Size(699, 219);
      this.listBox2.TabIndex = 5;
      this.listBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2_SelectedIndexChanged);
      // 
      // lblDate
      // 
      this.lblDate.AutoSize = true;
      this.lblDate.Location = new System.Drawing.Point(606, 368);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new System.Drawing.Size(114, 13);
      this.lblDate.TabIndex = 7;
      this.lblDate.Text = "yyyy-MM-dd HH:mm:ss";
      // 
      // lblInt
      // 
      this.lblInt.AutoSize = true;
      this.lblInt.Location = new System.Drawing.Point(752, 368);
      this.lblInt.Name = "lblInt";
      this.lblInt.Size = new System.Drawing.Size(31, 13);
      this.lblInt.TabIndex = 9;
      this.lblInt.Text = "9999";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(341, 404);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(32, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Objet";
      // 
      // listBox3
      // 
      this.listBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.listBox3.FormattingEnabled = true;
      this.listBox3.IntegralHeight = false;
      this.listBox3.Location = new System.Drawing.Point(399, 404);
      this.listBox3.Name = "listBox3";
      this.listBox3.Size = new System.Drawing.Size(204, 248);
      this.listBox3.TabIndex = 11;
      this.listBox3.SelectedIndexChanged += new System.EventHandler(this.ListBox3_SelectedIndexChanged);
      // 
      // listBox4
      // 
      this.listBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listBox4.FormattingEnabled = true;
      this.listBox4.IntegralHeight = false;
      this.listBox4.Location = new System.Drawing.Point(609, 404);
      this.listBox4.Name = "listBox4";
      this.listBox4.Size = new System.Drawing.Size(420, 248);
      this.listBox4.TabIndex = 12;
      // 
      // lblAttribut
      // 
      this.lblAttribut.AutoSize = true;
      this.lblAttribut.Location = new System.Drawing.Point(396, 342);
      this.lblAttribut.Name = "lblAttribut";
      this.lblAttribut.Size = new System.Drawing.Size(22, 13);
      this.lblAttribut.TabIndex = 14;
      this.lblAttribut.Text = "xxx";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(341, 342);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(40, 13);
      this.label6.TabIndex = 13;
      this.label6.Text = "Attribut";
      // 
      // lblValue
      // 
      this.lblValue.AutoSize = true;
      this.lblValue.Location = new System.Drawing.Point(396, 368);
      this.lblValue.Name = "lblValue";
      this.lblValue.Size = new System.Drawing.Size(22, 13);
      this.lblValue.TabIndex = 16;
      this.lblValue.Text = "xxx";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(341, 368);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(37, 13);
      this.label7.TabIndex = 15;
      this.label7.Text = "Valeur";
      // 
      // lblBool
      // 
      this.lblBool.AutoSize = true;
      this.lblBool.Location = new System.Drawing.Point(809, 368);
      this.lblBool.Name = "lblBool";
      this.lblBool.Size = new System.Drawing.Size(31, 13);
      this.lblBool.TabIndex = 17;
      this.lblBool.Text = "9999";
      // 
      // FTestJson
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1041, 664);
      this.Controls.Add(this.lblBool);
      this.Controls.Add(this.lblValue);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.lblAttribut);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.listBox4);
      this.Controls.Add(this.listBox3);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.lblInt);
      this.Controls.Add(this.lblDate);
      this.Controls.Add(this.listBox2);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.btParse);
      this.Controls.Add(this.btBrowse);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtFile);
      this.Name = "FTestJson";
      this.Text = "FTestJson";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtFile;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btBrowse;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button btParse;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.ListBox listBox2;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.Label lblInt;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ListBox listBox3;
    private System.Windows.Forms.ListBox listBox4;
    private System.Windows.Forms.Label lblAttribut;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label lblValue;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label lblBool;
  }
}