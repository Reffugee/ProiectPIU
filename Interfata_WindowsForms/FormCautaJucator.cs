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
        private AdministrareJucatori_FisierText adminJucatori;
        public FormCautaJucator()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);
        }

        private void mtCauta_Click(object sender, EventArgs e)
        {
            string termen = mtbNume.Text.Trim();

            var jucatoriGasiti = adminJucatori.GetJucator(termen, out int nrGasiti);


            StergereJucatorCautat();

            if (nrGasiti == 0)
            {
                MessageBox.Show($"Nu am găsit niciun jucător pentru '{termen}'.",
                                "Căutare terminată",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }


            int topOffset = 100;
            int leftOffset = 360;

            foreach (var j in jucatoriGasiti)
            {
                var info = new Dictionary<string, string>()
                {
                    ["Nume"] = j.Nume,
                    ["Prenume"] = j.Prenume,
                    ["Pozitie"] = j.Pozitie.ToString(),
                    ["Data Nașterii"] = j.DataNastere.ToShortDateString(),
                    ["Numar"] = j.Numar.ToString(),
                    ["Înălțime"] = $"{j.Inaltime} cm",
                    ["Greutate"] = $"{j.Greutate} kg",
                    ["Vârstă"] = $"{j.Varsta} ani",
                };


                foreach (var kvp in info)
                {
                    var lbl = new MetroFramework.Controls.MetroLabel()
                    {
                        AutoSize = true,
                        Top = topOffset,
                        Left = leftOffset,
                        ForeColor = Color.Wheat,
                        Text = $"{kvp.Key}: {kvp.Value}"
                    };
                    this.Controls.Add(lbl);
                    topOffset += lbl.Height + 2;
                }


                topOffset += 10;
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
