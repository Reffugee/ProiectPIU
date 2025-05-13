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
    public partial class FormCautaJucator: MetroForm
    {
        public FormCautaJucator()
        {
            InitializeComponent();
        }

        private void mtCauta_Click(object sender, EventArgs e)
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministrareJucatori_FisierText adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);
            string nume = mtbNume.Text;
            string prenume = mtbPrenume.Text;
            List<Jucator> jucatori = adminJucatori.GetJucatori(out int nrJucatori);
            var jucatorGasit = jucatori.FirstOrDefault(j => j.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase) && j.Prenume.Equals(prenume, StringComparison.OrdinalIgnoreCase));

            // Clear previous search results  
            StergereJucatorCautat();

            // starting vertical position:
            int topOffset = 100;
            int leftOffset = 360;

            // prepare your data:
            var info = new Dictionary<string, string>()
            {
                ["Nume"] = jucatorGasit.Nume,
                ["Prenume"] = jucatorGasit.Prenume,
                ["Pozitie"] = jucatorGasit.Pozitie.ToString(),
                ["Data Nașterii"] = jucatorGasit.DataNastere.ToShortDateString(),
                ["Numar"] = jucatorGasit.Numar.ToString(),
                ["Înălțime"] = $"{jucatorGasit.Inaltime} cm",
                ["Greutate"] = $"{jucatorGasit.Greutate} kg",
                ["Vârstă"] = $"{jucatorGasit.Varsta} ani",
            };

            foreach (var kvp in info)
            {
                var lbl = new MetroLabel()
                {
                    AutoSize = true,
                    Top = topOffset,
                    Left = leftOffset,
                    ForeColor = Color.Wheat,
                    Text = $"{kvp.Key}: {kvp.Value}"
                };
                this.Controls.Add(lbl);
                topOffset += lbl.Height + 5;  // 5px spacing between labels
            }

        }
        private void StergereJucatorCautat()
        {
            foreach (Control control in this.Controls.Cast<Control>().Where(c => c.Tag?.ToString() == "Jucator Cautat").ToList())
            {
                this.Controls.Remove(control);
                control.Dispose();
            }
        }
    }
}
