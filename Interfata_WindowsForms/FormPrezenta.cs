using LibrarieModele;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data;
using System.Linq;

namespace Interfata_WindowsForms
{
    public partial class FormPrezenta : MetroForm
    {
        private readonly AdministrareJucatori_FisierText adminJuc;
        private readonly AdministrareAntrenament_FisierText adminEx;
        private readonly AdministrarePrezenta adminPrez;

        private Dictionary<string, bool[]> prezMap = new Dictionary<string, bool[]>();

        // Hold on to the last-selected exercise so we know where to save
        private string lastExercitiu = null;

        public FormPrezenta(
            AdministrareJucatori_FisierText adminJuc,
            AdministrareAntrenament_FisierText adminEx,
            AdministrarePrezenta adminPrez)
        {
            InitializeComponent();
            this.adminJuc = adminJuc;
            this.adminEx = adminEx;
            this.adminPrez = adminPrez;
            IncarcaExercitii();
            PopuleazaJucatori();      // only this one time
            lastExercitiu = cmbExercitii.SelectedValue as string;
        }

        private void IncarcaExercitii()
        {
            // pull your Antrenament objects
            var listaAntr = adminEx.GetAntrenamente(out int nrAntr);

            // bind only the "name" (string) — change "Denumire" to your actual property
            cmbExercitii.DataSource = listaAntr;
            cmbExercitii.DisplayMember = nameof(Antrenament.Exercitiu);
            cmbExercitii.ValueMember = nameof(Antrenament.Exercitiu);
            lastExercitiu = cmbExercitii.SelectedValue as string;
            PopuleazaJucatori();
        }

        private void cmbExercitii_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1) Save old state
            if (lastExercitiu != null)
            {
                bool[] state = dgvJucatori.Rows
                    .Cast<DataGridViewRow>()
                    .Select(r => r.Cells["Prezent"].Value as bool? ?? false)
                    .ToArray();
                prezMap[lastExercitiu] = state;
            }

            // 2) Apply new state (if any), or clear
            string curEx = cmbExercitii.SelectedValue as string;
            if (curEx != null && prezMap.TryGetValue(curEx, out var saved))
            {
                for (int i = 0; i < dgvJucatori.Rows.Count && i < saved.Length; i++)
                    dgvJucatori.Rows[i].Cells["Prezent"].Value = saved[i];
            }
            else
            {
                // No saved state: clear all to false
                foreach (DataGridViewRow row in dgvJucatori.Rows)
                    row.Cells["Prezent"].Value = false;
            }

            // 3) Remember for next time
            lastExercitiu = curEx;

        }
        private void PopuleazaJucatori()
        {
            var jucatori = adminJuc.GetJucatori(out _);

            // If you’re still using the DataTable approach:
            dgvJucatori.DataSource = BuildPlayersTable(jucatori, null);
        }

        private DataTable BuildPlayersTable(List<Jucator> jucatori, bool[] savedState)
        {
            var dt = new DataTable();
            dt.Columns.Add("Nume", typeof(string));
            dt.Columns.Add("Prenume", typeof(string));
            dt.Columns.Add("Prezent", typeof(bool));

            for (int i = 0; i < jucatori.Count; i++)
            {
                var j = jucatori[i];
                bool initial = false;
                if (savedState != null && i < savedState.Length)
                    initial = savedState[i];
                dt.Rows.Add(j.Nume, j.Prenume, initial);
            }

            return dt;
        }

        private void mtSalvare_Click(object sender, EventArgs e)
        {
            {
                // grab the selected exercise name
                string exer = cmbExercitii.SelectedValue as string;
                // or:  string exer = ((Antrenament)cmbExercitii.SelectedItem).Denumire;

                DateTime data = DateTime.Today;

                foreach (DataGridViewRow row in dgvJucatori.Rows)
                {
                    bool prez = row.Cells["Prezent"].Value as bool? ?? false;
                    var p = new Prezenta
                    {
                        Nume = row.Cells["Nume"].Value?.ToString() ?? "",
                        Prenume = row.Cells["Prenume"].Value?.ToString() ?? "",
                        Exercitiu = cmbExercitii.SelectedValue as string,
                        Data = DateTime.Today,
                        Participa = prez
                    };
                    adminPrez.SalveazaPrezenta(p);
                }


                MessageBox.Show(
                    this,
                    "Prezențe salvate!",
                    "Confirmare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
        }
    }
}
