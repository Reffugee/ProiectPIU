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
    public partial class FormExercitiu: MetroForm
    {
        private AdministrareAntrenament_FisierText adminAntrenamente;
        private MetroLabel[,] lblExercitii;
        private readonly int[] coloaneX = { 200, 346, 479, 595 };
        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_Y = 85;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int RAND_Y = DIMENSIUNE_Y + DIMENSIUNE_PAS_Y;
        public FormExercitiu()
        {
            InitializeComponent();
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            adminAntrenamente = new AdministrareAntrenament_FisierText(caleCompletaFisier2);
        }

        private void mtAdaugaEx_Click(object sender, EventArgs e)
        {
            var formAdd = new FormAdaugareEx();
            formAdd.ShowDialog();
        }

        private void mtActualizareEx_Click(object sender, EventArgs e)
        {
            AfiseazaExercitii();
        }
        private void AfiseazaExercitii()
        {
            if (lblExercitii != null)
            {
                foreach (var lbl in lblExercitii)
                    this.Controls.Remove(lbl);
            }

            var antrenamente = adminAntrenamente.GetAntrenamente(out int nrExercitii);
            int nrColoane = coloaneX.Length;              
            lblExercitii = new MetroLabel[nrExercitii, nrColoane];

            for (int i = 0; i < nrExercitii; i++)
            {
                int y = RAND_Y + (i * DIMENSIUNE_PAS_Y);

                string[] valori = new string[]
                {
            antrenamente[i].Exercitiu,
            antrenamente[i].TipExercitiu,
            antrenamente[i].Durata.ToString(),
            antrenamente[i].Zi.ToString()
                };

                for (int col = 0; col < nrColoane; col++)
                {
                    var lbl = new MetroLabel
                    {
                        Text = valori[col],
                        Left = coloaneX[col],
                        Top = y,
                        AutoSize = (col == 2),        
                        Width = (col == 2 ? 0 : LATIME_CONTROL)
                    };

                    lblExercitii[i, col] = lbl;
                    this.Controls.Add(lbl);
                }
            }
        }

        private void mtMeniuEx_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
