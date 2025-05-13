namespace Interfata_WindowsForms
{
    partial class FormCautaJucator
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
            this.mlNume = new MetroFramework.Controls.MetroLabel();
            this.mlPrenume = new MetroFramework.Controls.MetroLabel();
            this.mtbNume = new MetroFramework.Controls.MetroTextBox();
            this.mtbPrenume = new MetroFramework.Controls.MetroTextBox();
            this.mtCauta = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // mlNume
            // 
            this.mlNume.AutoSize = true;
            this.mlNume.Location = new System.Drawing.Point(82, 112);
            this.mlNume.Name = "mlNume";
            this.mlNume.Size = new System.Drawing.Size(45, 19);
            this.mlNume.TabIndex = 0;
            this.mlNume.Text = "Nume";
            // 
            // mlPrenume
            // 
            this.mlPrenume.AutoSize = true;
            this.mlPrenume.Location = new System.Drawing.Point(82, 155);
            this.mlPrenume.Name = "mlPrenume";
            this.mlPrenume.Size = new System.Drawing.Size(62, 19);
            this.mlPrenume.TabIndex = 1;
            this.mlPrenume.Text = "Prenume";
            // 
            // mtbNume
            // 
            this.mtbNume.Location = new System.Drawing.Point(191, 112);
            this.mtbNume.Name = "mtbNume";
            this.mtbNume.Size = new System.Drawing.Size(144, 23);
            this.mtbNume.TabIndex = 2;
            // 
            // mtbPrenume
            // 
            this.mtbPrenume.Location = new System.Drawing.Point(191, 155);
            this.mtbPrenume.Name = "mtbPrenume";
            this.mtbPrenume.Size = new System.Drawing.Size(144, 23);
            this.mtbPrenume.TabIndex = 3;
            // 
            // mtCauta
            // 
            this.mtCauta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mtCauta.CustomBackground = true;
            this.mtCauta.Location = new System.Drawing.Point(184, 204);
            this.mtCauta.Name = "mtCauta";
            this.mtCauta.Size = new System.Drawing.Size(151, 42);
            this.mtCauta.TabIndex = 4;
            this.mtCauta.Text = "Cauta";
            this.mtCauta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtCauta.Click += new System.EventHandler(this.mtCauta_Click);
            // 
            // FormCautaJucator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 269);
            this.Controls.Add(this.mtCauta);
            this.Controls.Add(this.mtbPrenume);
            this.Controls.Add(this.mtbNume);
            this.Controls.Add(this.mlPrenume);
            this.Controls.Add(this.mlNume);
            this.Name = "FormCautaJucator";
            this.Text = "Cauta Jucator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel mlNume;
        private MetroFramework.Controls.MetroLabel mlPrenume;
        private MetroFramework.Controls.MetroTextBox mtbNume;
        private MetroFramework.Controls.MetroTextBox mtbPrenume;
        private MetroFramework.Controls.MetroTile mtCauta;
    }
}