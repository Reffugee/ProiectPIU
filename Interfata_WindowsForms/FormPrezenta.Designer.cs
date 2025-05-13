namespace Interfata_WindowsForms
{
    partial class FormPrezenta
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cmbExercitii = new MetroFramework.Controls.MetroComboBox();
            this.dgvJucatori = new System.Windows.Forms.DataGridView();
            this.mtSalvare = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJucatori)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(249, 93);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(60, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Exercitiu:";
            // 
            // cmbExercitii
            // 
            this.cmbExercitii.FormattingEnabled = true;
            this.cmbExercitii.ItemHeight = 23;
            this.cmbExercitii.Location = new System.Drawing.Point(335, 93);
            this.cmbExercitii.Name = "cmbExercitii";
            this.cmbExercitii.Size = new System.Drawing.Size(396, 29);
            this.cmbExercitii.TabIndex = 1;
            // 
            // dgvJucatori
            // 
            this.dgvJucatori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJucatori.Location = new System.Drawing.Point(335, 149);
            this.dgvJucatori.Name = "dgvJucatori";
            this.dgvJucatori.Size = new System.Drawing.Size(396, 228);
            this.dgvJucatori.TabIndex = 2;
            // 
            // mtSalvare
            // 
            this.mtSalvare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mtSalvare.CustomBackground = true;
            this.mtSalvare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mtSalvare.Location = new System.Drawing.Point(72, 174);
            this.mtSalvare.Name = "mtSalvare";
            this.mtSalvare.Size = new System.Drawing.Size(129, 92);
            this.mtSalvare.TabIndex = 3;
            this.mtSalvare.Text = "Salveaza Prezenta";
            this.mtSalvare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtSalvare.Click += new System.EventHandler(this.mtSalvare_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(252, 149);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(57, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Jucatori:";
            // 
            // FormPrezenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.mtSalvare);
            this.Controls.Add(this.dgvJucatori);
            this.Controls.Add(this.cmbExercitii);
            this.Controls.Add(this.metroLabel1);
            this.Name = "FormPrezenta";
            this.Text = "Prezenta Jucator";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJucatori)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cmbExercitii;
        private System.Windows.Forms.DataGridView dgvJucatori;
        private MetroFramework.Controls.MetroTile mtSalvare;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}