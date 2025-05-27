namespace Interfata_WindowsForms
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.mtExercitiu = new MetroFramework.Controls.MetroTile();
            this.mtJucatori = new MetroFramework.Controls.MetroTile();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mtExercitiu
            // 
            this.mtExercitiu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.mtExercitiu, "mtExercitiu");
            this.mtExercitiu.Name = "mtExercitiu";
            this.mtExercitiu.Style = MetroFramework.MetroColorStyle.Silver;
            this.mtExercitiu.TileImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mtExercitiu.Click += new System.EventHandler(this.mtExercitiu_Click);
            // 
            // mtJucatori
            // 
            this.mtJucatori.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.mtJucatori, "mtJucatori");
            this.mtJucatori.Name = "mtJucatori";
            this.mtJucatori.Style = MetroFramework.MetroColorStyle.Silver;
            this.mtJucatori.Click += new System.EventHandler(this.mtJucatori_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Interfata_WindowsForms.Properties.Resources.istockphoto_1342490008_612x612;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Interfata_WindowsForms.Properties.Resources._360_F_1268152671_HT1ASesrThk5keqJaEr3wmv1xBnVBqe4;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // metroTile1
            // 
            this.metroTile1.CustomBackground = true;
            this.metroTile1.CustomForeColor = true;
            resources.ApplyResources(this.metroTile1, "metroTile1");
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.TileImage = global::Interfata_WindowsForms.Properties.Resources.download__9_;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.metroTile1.UseTileImage = true;
            // 
            // FormPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mtExercitiu);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.mtJucatori);
            this.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Name = "FormPrincipal";
            this.Style = MetroFramework.MetroColorStyle.Black;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile mtExercitiu;
        private MetroFramework.Controls.MetroTile mtJucatori;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}