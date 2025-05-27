using LibrarieModele;
using LibrarieModele.Enumerari;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace Interfata_WindowsForms
{
    public partial class FormEditare : MetroForm
    {
        private AdministrareJucatori_FisierText adminJucatori;
        private BindingList<Jucator> listaJucatori;
        public FormEditare()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);
            listaJucatori = new BindingList<Jucator>(adminJucatori.GetJucatori(out int nrJucatori));
            dgvEditJuc.DataSource = listaJucatori;
            foreach (DataGridViewColumn col in dgvEditJuc.Columns)
            {
                if (col.Name == nameof(Jucator.Nume) ||
                    col.Name == nameof(Jucator.Prenume) ||
                    col.Name == nameof(Jucator.Numar) ||
                    col.Name == nameof(Jucator.Inaltime) ||
                    col.Name == nameof(Jucator.Greutate))
                {
                    col.ReadOnly = false;
                }
                else
                {
                    col.ReadOnly = true;
                }
            }
            dgvEditJuc.CellEndEdit += dgvEditJuc_CellEndEdit;
        }

        private void mtEditareJuc_Click(object sender, EventArgs e)
        {
            adminJucatori.SalveazaEdit(listaJucatori);

            MessageBox.Show("Modificările au fost salvate în fișier.",
                            "Salvare reușită",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        private void dgvEditJuc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            var row = grid.Rows[e.RowIndex];
            var col = grid.Columns[e.ColumnIndex];
            var prop = col.DataPropertyName;             
            var cell = row.Cells[e.ColumnIndex];
            string text = cell.Value?.ToString().Trim() ?? "";


            row.ErrorText = "";

            if (prop == nameof(Jucator.Nume) || prop == nameof(Jucator.Prenume))
            {
                if (string.IsNullOrEmpty(text))
                {
                    MessageBox.Show($"{prop} nu poate fi gol.",
                                    "Validare eșuată",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    row.ErrorText = $"{prop} nu poate fi gol.";
                    grid.CurrentCell = cell;
                }
            }


            if (prop == nameof(Jucator.Numar)
             || prop == nameof(Jucator.Inaltime)
             || prop == nameof(Jucator.Greutate))
            {
                if (!int.TryParse(text, out int val) || val < 0)
                {
                    MessageBox.Show($"{prop} trebuie să fie un întreg ≥ 0.",
                                    "Validare eșuată",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    row.ErrorText = $"{prop} invalid.";
                    grid.CancelEdit();
                    grid.CurrentCell = cell;
                }
            }
        }
       
    }
}
    
