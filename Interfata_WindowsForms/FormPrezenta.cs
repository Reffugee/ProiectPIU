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
        private AdministrareJucatori_FisierText adminJuc;
        private AdministrareAntrenament_FisierText adminEx;
        private AdministrarePrezenta adminPrez;

        private Dictionary<string, bool[]> prezMap = new Dictionary<string, bool[]>();

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
            PopuleazaJucatori();      
            lastExercitiu = cmbExercitii.SelectedValue as string;
        }

        private void IncarcaExercitii()
        {
            
            var listaAntr = adminEx.GetAntrenamente(out int nrAntr);

            
            cmbExercitii.DataSource = listaAntr;
            cmbExercitii.DisplayMember = nameof(Antrenament.Exercitiu);
            cmbExercitii.ValueMember = nameof(Antrenament.Exercitiu);
            lastExercitiu = cmbExercitii.SelectedValue as string;
            PopuleazaJucatori();
        }

        private void cmbExercitii_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lastExercitiu != null)
            {
                bool[] state = dgvJucatori.Rows
                    .Cast<DataGridViewRow>()
                    .Select(r => r.Cells["Prezent"].Value as bool? ?? false)
                    .ToArray();
                prezMap[lastExercitiu] = state;
            }

            
            string curEx = cmbExercitii.SelectedValue as string;
            if (curEx != null && prezMap.TryGetValue(curEx, out var saved))
            {
                for (int i = 0; i < dgvJucatori.Rows.Count && i < saved.Length; i++)
                    dgvJucatori.Rows[i].Cells["Prezent"].Value = saved[i];
            }
            else
            {
                
                foreach (DataGridViewRow row in dgvJucatori.Rows)
                    row.Cells["Prezent"].Value = false;
            }

           
            lastExercitiu = curEx;

        }
        private void PopuleazaJucatori()
        {
            var jucatori = adminJuc.GetJucatori(out _);

            
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
                
                string exer = cmbExercitii.SelectedValue as string;
                

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
