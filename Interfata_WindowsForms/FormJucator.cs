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
    public partial class FormJucator : MetroForm
    {
        private AdministrareJucatori_FisierText adminJucatori;
        private AdministrareAntrenament_FisierText adminEx;
        private AdministrarePrezenta adminPrez;
        private MetroLabel[,] lblJucatori;

        private readonly int[] coloaneX = { 224, 323, 440, 611, 716, 796, 886 };

        private const int LATIME_CONTROL = 60;
        private const int DIMENSIUNE_Y = 85;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int RAND_Y = DIMENSIUNE_Y + DIMENSIUNE_PAS_Y;

        public FormJucator()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string proiectDir = Directory
                .GetParent(Directory.GetCurrentDirectory())
                .Parent.Parent.FullName;
            string caleFisier = Path.Combine(proiectDir, numeFisier);
            adminJucatori = new AdministrareJucatori_FisierText(caleFisier);

            string numeFisierEx = ConfigurationManager.AppSettings["NumeFisier2"];
            string caleEx = Path.Combine(proiectDir, numeFisierEx);
            adminEx = new AdministrareAntrenament_FisierText(caleEx);

            string numeFisierPrez = ConfigurationManager.AppSettings["NumeFisier3"];
            string calePrez = Path.Combine(proiectDir, numeFisierPrez);
            adminPrez = new AdministrarePrezenta(calePrez);
            AfiseazaJucatori();

        }

        private void mtAdaugaJuc_Click(object sender, EventArgs e)
        {
            var formAdd = new FormAdaugaJucator();
            formAdd.ShowDialog();
        }

        private void mtRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaJucatori();
        }

        private void AfiseazaJucatori()
        {
            if (lblJucatori != null)
                foreach (var l in lblJucatori)
                    this.Controls.Remove(l);

            var jucatori = adminJucatori.GetJucatori(out int nrJucatori);
            int nrColoane = coloaneX.Length;
            lblJucatori = new MetroLabel[nrJucatori, nrColoane];

            for (int i = 0; i < nrJucatori; i++)
            {
                int y = RAND_Y + (i * DIMENSIUNE_PAS_Y);

                string[] valori = new string[]
                {
            jucatori[i].Nume,
            jucatori[i].Prenume,
            jucatori[i].Pozitie.ToString(),
            jucatori[i].Numar.ToString(),
            jucatori[i].Varsta.ToString(),
            jucatori[i].Inaltime.ToString(),
            jucatori[i].Greutate.ToString()
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

                    lblJucatori[i, col] = lbl;
                    this.Controls.Add(lbl);
                }
            }
        }

        private void mtCauta_Click(object sender, EventArgs e)
        {
            var formAdd = new FormCautaJucator();
            formAdd.ShowDialog();
        }

        private void mtMeniu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtPrezenta_Click(object sender, EventArgs e)
        {
            var formPrezenta = new FormPrezenta(adminJucatori,adminEx, adminPrez);
            formPrezenta.ShowDialog();
        }

        private void mtEdit_Click(object sender, EventArgs e)
        {
            var formEdit = new FormEditare();
            formEdit.ShowDialog();
        }

        private void mtSterge_Click(object sender, EventArgs e)
        {

            var rezultat = MessageBox.Show(
                "Sigur vrei să ștergi ultimul jucator?",
                "Confirmare ștergere",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rezultat != DialogResult.Yes)
                return;


            bool sters = adminJucatori.StergeUltimulJucator();
            if (!sters)
            {
                MessageBox.Show(
                    "Nu există niciun jucator de șters.",
                    "Ștergere eșuată",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }


            AfiseazaJucatori();
        }


    }
}