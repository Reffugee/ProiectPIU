namespace Interfata_WindowsForms
{
    partial class FormEditare
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
            this.jucatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvEditJuc = new System.Windows.Forms.DataGridView();
            this.mtEditareJuc = new MetroFramework.Controls.MetroTile();
            this.administrareJucatoriFisierTextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.jucatorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditJuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.administrareJucatoriFisierTextBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // jucatorBindingSource
            // 
            this.jucatorBindingSource.DataSource = typeof(LibrarieModele.Jucator);
            // 
            // dgvEditJuc
            // 
            this.dgvEditJuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditJuc.Location = new System.Drawing.Point(56, 79);
            this.dgvEditJuc.Name = "dgvEditJuc";
            this.dgvEditJuc.Size = new System.Drawing.Size(569, 219);
            this.dgvEditJuc.TabIndex = 0;
            // 
            // mtEditareJuc
            // 
            this.mtEditareJuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mtEditareJuc.CustomBackground = true;
            this.mtEditareJuc.Location = new System.Drawing.Point(214, 321);
            this.mtEditareJuc.Name = "mtEditareJuc";
            this.mtEditareJuc.Size = new System.Drawing.Size(228, 86);
            this.mtEditareJuc.TabIndex = 1;
            this.mtEditareJuc.Text = "Salveaza \r\nEditare";
            this.mtEditareJuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mtEditareJuc.Click += new System.EventHandler(this.mtEditareJuc_Click);
            // 
            // administrareJucatoriFisierTextBindingSource
            // 
            this.administrareJucatoriFisierTextBindingSource.DataSource = typeof(NivelStocareDate.AdministrareJucatori_FisierText);
            // 
            // FormEditare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 450);
            this.Controls.Add(this.mtEditareJuc);
            this.Controls.Add(this.dgvEditJuc);
            this.Name = "FormEditare";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Editare Jucatori";
            ((System.ComponentModel.ISupportInitialize)(this.jucatorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditJuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.administrareJucatoriFisierTextBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource jucatorBindingSource;
        private System.Windows.Forms.BindingSource administrareJucatoriFisierTextBindingSource;
        private System.Windows.Forms.DataGridView dgvEditJuc;
        private MetroFramework.Controls.MetroTile mtEditareJuc;
    }
}