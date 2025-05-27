using LibrarieModele.Enumerari;
using System;

namespace Interfata_WindowsForms
{
    partial class FormAdaugareEx
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
            this.components = new System.ComponentModel.Container();
            this.mlExercitiu = new MetroFramework.Controls.MetroLabel();
            this.mlTip = new MetroFramework.Controls.MetroLabel();
            this.mlDurata = new MetroFramework.Controls.MetroLabel();
            this.mlZi = new MetroFramework.Controls.MetroLabel();
            this.mcbZi = new MetroFramework.Controls.MetroComboBox();
            this.mtbExercitiu = new MetroFramework.Controls.MetroTextBox();
            this.mtbTip = new MetroFramework.Controls.MetroTextBox();
            this.mtbDurata = new MetroFramework.Controls.MetroTextBox();
            this.mlAdaugare = new MetroFramework.Controls.MetroTile();
            this.jucatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jucatorBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.jucatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jucatorBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // mlExercitiu
            // 
            this.mlExercitiu.AutoSize = true;
            this.mlExercitiu.Location = new System.Drawing.Point(105, 101);
            this.mlExercitiu.Name = "mlExercitiu";
            this.mlExercitiu.Size = new System.Drawing.Size(57, 19);
            this.mlExercitiu.TabIndex = 0;
            this.mlExercitiu.Text = "Exercitiu";
            // 
            // mlTip
            // 
            this.mlTip.AutoSize = true;
            this.mlTip.Location = new System.Drawing.Point(105, 151);
            this.mlTip.Name = "mlTip";
            this.mlTip.Size = new System.Drawing.Size(27, 19);
            this.mlTip.TabIndex = 1;
            this.mlTip.Text = "Tip";
            // 
            // mlDurata
            // 
            this.mlDurata.AutoSize = true;
            this.mlDurata.Location = new System.Drawing.Point(105, 197);
            this.mlDurata.Name = "mlDurata";
            this.mlDurata.Size = new System.Drawing.Size(48, 19);
            this.mlDurata.TabIndex = 2;
            this.mlDurata.Text = "Durata";
            // 
            // mlZi
            // 
            this.mlZi.AutoSize = true;
            this.mlZi.Location = new System.Drawing.Point(105, 249);
            this.mlZi.Name = "mlZi";
            this.mlZi.Size = new System.Drawing.Size(20, 19);
            this.mlZi.TabIndex = 3;
            this.mlZi.Text = "Zi";
            // 
            // mcbZi
            // 
            this.mcbZi.Location = new System.Drawing.Point(184, 249);
            this.mcbZi.Name = "mcbZi";
            this.mcbZi.Size = new System.Drawing.Size(121, 29);
            this.mcbZi.TabIndex = 4;
            // 
            // mtbExercitiu
            // 
            this.mtbExercitiu.Location = new System.Drawing.Point(184, 96);
            this.mtbExercitiu.Name = "mtbExercitiu";
            this.mtbExercitiu.Size = new System.Drawing.Size(121, 23);
            this.mtbExercitiu.TabIndex = 5;
            // 
            // mtbTip
            // 
            this.mtbTip.Location = new System.Drawing.Point(184, 151);
            this.mtbTip.Name = "mtbTip";
            this.mtbTip.Size = new System.Drawing.Size(121, 23);
            this.mtbTip.TabIndex = 6;
            // 
            // mtbDurata
            // 
            this.mtbDurata.Location = new System.Drawing.Point(184, 197);
            this.mtbDurata.Name = "mtbDurata";
            this.mtbDurata.Size = new System.Drawing.Size(121, 23);
            this.mtbDurata.TabIndex = 7;
            // 
            // mlAdaugare
            // 
            this.mlAdaugare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mlAdaugare.CustomBackground = true;
            this.mlAdaugare.ForeColor = System.Drawing.Color.Red;
            this.mlAdaugare.Location = new System.Drawing.Point(358, 151);
            this.mlAdaugare.Name = "mlAdaugare";
            this.mlAdaugare.Size = new System.Drawing.Size(95, 50);
            this.mlAdaugare.TabIndex = 8;
            this.mlAdaugare.Text = "Adauga";
            this.mlAdaugare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mlAdaugare.Click += new System.EventHandler(this.mlAdaugare_Click);
            // 
            // jucatorBindingSource
            // 
            this.jucatorBindingSource.DataSource = typeof(LibrarieModele.Jucator);
            // 
            // jucatorBindingSource1
            // 
            this.jucatorBindingSource1.DataSource = typeof(LibrarieModele.Jucator);
            // 
            // FormAdaugareEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 307);
            this.Controls.Add(this.mlAdaugare);
            this.Controls.Add(this.mtbDurata);
            this.Controls.Add(this.mtbTip);
            this.Controls.Add(this.mtbExercitiu);
            this.Controls.Add(this.mcbZi);
            this.Controls.Add(this.mlZi);
            this.Controls.Add(this.mlDurata);
            this.Controls.Add(this.mlTip);
            this.Controls.Add(this.mlExercitiu);
            this.Name = "FormAdaugareEx";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Adaugare Exercitii";
            ((System.ComponentModel.ISupportInitialize)(this.jucatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jucatorBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel mlExercitiu;
        private MetroFramework.Controls.MetroLabel mlTip;
        private MetroFramework.Controls.MetroLabel mlDurata;
        private MetroFramework.Controls.MetroLabel mlZi;
        private MetroFramework.Controls.MetroComboBox mcbZi;
        private MetroFramework.Controls.MetroTextBox mtbExercitiu;
        private MetroFramework.Controls.MetroTextBox mtbTip;
        private MetroFramework.Controls.MetroTextBox mtbDurata;
        private MetroFramework.Controls.MetroTile mlAdaugare;
        private System.Windows.Forms.BindingSource jucatorBindingSource;
        private System.Windows.Forms.BindingSource jucatorBindingSource1;
    }
}