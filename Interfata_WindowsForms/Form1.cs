using LibrarieModele;
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

namespace Interfata_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareJucatori_FisierText adminJucatori;
        AdministrareAntrenament_FisierText adminAntrenamente; // New: Manage training data

        private DataGridView dgvAntrenamente; // New: Table for training exercises

        private Label lblNume;
        private Label lblPrenume;
        private Label lblPozitie;
        private Label lblNumar;
        private Label lblVarsta;
        private Label lblInaltime;
        private Label lblGreutate;

        private Label lblExercitiu;
        private Label lblTip;
        private Label lblDurata;
        private Label lblZi;

        private Label[] lblsNume;
        private Label[] lblsPrenume;
        private Label[] lblsPozitie;
        private Label[] lblsNumar;
        private Label[] lblsVarsta;
        private Label[] lblsInaltime;
        private Label[] lblsGreutate;

        private Label[] lblsExercitiu;
        private Label[] lblsTip;
        private Label[] lblsDurata;
        private Label[] lblsZi;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;

        private const int INALTIME_CONTROL = 148;
        private const int DIMENSIUNE_PAS_Ya = 30;
        private const int DIMENSIUNE_PAS_Xa = 120;
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;

            adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);
            adminAntrenamente = new AdministrareAntrenament_FisierText(caleCompletaFisier2);

            //setare proprietati
            this.Size = new Size(1000, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(20,5,60);
            this.Text = "Informatii jucatori si exercitii";

            //adaugare control de tip Label pentru 'Nume';
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.ForeColor = Color.Wheat;
            this.Controls.Add(lblNume);

            //adaugare control de tip Label pentru 'Prenume';
            lblPrenume = new Label();
            lblPrenume.Width = LATIME_CONTROL;
            lblPrenume.Text = "Prenume";
            lblPrenume.Left = 2 * DIMENSIUNE_PAS_X;
            lblPrenume.ForeColor = Color.Wheat;
            this.Controls.Add(lblPrenume);

            //adaugare control de tip Label pentru 'Pozitie';
            lblPozitie = new Label();
            lblPozitie.Width = LATIME_CONTROL;
            lblPozitie.Text = "Pozitie";
            lblPozitie.Left = 3 * DIMENSIUNE_PAS_X;
            lblPozitie.ForeColor = Color.Wheat;
            this.Controls.Add(lblPozitie);

            //adaugare control de tip Label pentru 'Numar';
            lblNumar = new Label();
            lblNumar.Width = LATIME_CONTROL;
            lblNumar.Text = "Numar";
            lblNumar.Left = 4 * DIMENSIUNE_PAS_X;
            lblNumar.ForeColor = Color.Wheat;
            this.Controls.Add(lblNumar);

            //adaugare control de tip Label pentru 'Varsta';
            lblVarsta = new Label();
            lblVarsta.Width = LATIME_CONTROL;
            lblVarsta.Text = "Varsta";
            lblVarsta.Left = 5 * DIMENSIUNE_PAS_X;
            lblVarsta.ForeColor = Color.Wheat;
            this.Controls.Add(lblVarsta);

            //adaugare control de tip Label pentru 'Inaltime';
            lblInaltime = new Label();
            lblInaltime.Width = LATIME_CONTROL;
            lblInaltime.Text = "Inaltime";
            lblInaltime.Left = 6 * DIMENSIUNE_PAS_X;
            lblInaltime.ForeColor = Color.Wheat;
            this.Controls.Add(lblInaltime);

            //adaugare control de tip Label pentru 'Greutate';
            lblGreutate = new Label();
            lblGreutate.Width = LATIME_CONTROL;
            lblGreutate.Text = "Greutate";
            lblGreutate.Left = 7 * DIMENSIUNE_PAS_X;
            lblGreutate.ForeColor = Color.Wheat;
            this.Controls.Add(lblGreutate);

            //adaugare control de tip Label pentru 'Exercitiu';
            lblExercitiu = new Label();
            lblExercitiu.Width = LATIME_CONTROL;
            lblExercitiu.Top = INALTIME_CONTROL;
            lblExercitiu.Text = "Exercitiu";
            lblExercitiu.Left = DIMENSIUNE_PAS_Xa;
            lblExercitiu.ForeColor = Color.Wheat;
            this.Controls.Add(lblExercitiu);

            //adaugare control de tip Label pentru 'Tip';
            lblTip = new Label();
            lblTip.Width = LATIME_CONTROL;
            lblTip.Top = INALTIME_CONTROL;
            lblTip.Text = "Tip";
            lblTip.Left = 2 * DIMENSIUNE_PAS_Xa;
            lblTip.ForeColor = Color.Wheat;
            this.Controls.Add(lblTip);

            //adaugare control de tip Label pentru 'Durata';
            lblDurata = new Label();
            lblDurata.Width = LATIME_CONTROL;
            lblDurata.Top = INALTIME_CONTROL;
            lblDurata.Text = "Durata";
            lblDurata.Left = 3 * DIMENSIUNE_PAS_Xa;
            lblDurata.ForeColor = Color.Wheat;
            this.Controls.Add(lblDurata);

            //adaugare control de tip Label pentru 'Zi';
            lblZi = new Label();
            lblZi.Width = LATIME_CONTROL;
            lblZi.Top = INALTIME_CONTROL;
            lblZi.Text = "Zi";
            lblZi.Left = 4 * DIMENSIUNE_PAS_Xa;
            lblZi.ForeColor = Color.Wheat;
            this.Controls.Add(lblZi);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaJucator();
            AfiseazaExercitii();
        }
        private void AfiseazaJucator()
        {
            int nrJucatori;
            Jucator[] jucatori = adminJucatori.GetJucatori(out nrJucatori);

            lblsNume = new Label[nrJucatori];
            lblsPrenume = new Label[nrJucatori];
            lblsPozitie = new Label[nrJucatori];
            lblsNumar = new Label[nrJucatori];
            lblsVarsta = new Label[nrJucatori];
            lblsInaltime = new Label[nrJucatori];
            lblsGreutate = new Label[nrJucatori];

            int i = 0;
            foreach (Jucator jucator in jucatori)
            {
                //adaugare control de tip Label pentru nume
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = jucator.Nume;
                lblsNume[i].Left = DIMENSIUNE_PAS_X;
                lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNume[i]);

                //adaugare control de tip Label pentru prenume
                lblsPrenume[i] = new Label();
                lblsPrenume[i].Width = LATIME_CONTROL;
                lblsPrenume[i].Text = jucator.Prenume;
                lblsPrenume[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsPrenume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPrenume[i]);

                //adaugare control de tip Label pentru pozitie
                lblsPozitie[i] = new Label();
                lblsPozitie[i].AutoSize = true;
                lblsPozitie[i].Text = jucator.Pozitie.ToString();
                lblsPozitie[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsPozitie[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPozitie[i]);

                //adaugare control de tip Label pentru numar
                lblsNumar[i] = new Label();
                lblsNumar[i].Width = LATIME_CONTROL;
                lblsNumar[i].Text = jucator.Numar.ToString();
                lblsNumar[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsNumar[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumar[i]);

                //adaugare control de tip Label pentru varsta
                lblsVarsta[i] = new Label();
                lblsVarsta[i].Width = LATIME_CONTROL;
                lblsVarsta[i].Text = jucator.Varsta.ToString();
                lblsVarsta[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblsVarsta[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsVarsta[i]);

                //adaugare control de tip Label pentru inaltime
                lblsInaltime[i] = new Label();
                lblsInaltime[i].Width = LATIME_CONTROL;
                lblsInaltime[i].Text = jucator.Inaltime.ToString();
                lblsInaltime[i].Left = 6 * DIMENSIUNE_PAS_X;
                lblsInaltime[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsInaltime[i]);

                //adaugare control de tip Label pentru greutate
                lblsGreutate[i] = new Label();
                lblsGreutate[i].Width = LATIME_CONTROL;
                lblsGreutate[i].Text = jucator.Greutate.ToString();
                lblsGreutate[i].Left = 7 * DIMENSIUNE_PAS_X;
                lblsGreutate[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsGreutate[i]);

                i++;
            }
        }
        private void AfiseazaExercitii()
        {
            // Get the exercises
            int nrExercitii;
            Antrenament[] antrenamente = adminAntrenamente.GetAntrenamente(out nrExercitii);

            int startTop = 150; // Start from this position below the title
            
            lblsExercitiu = new Label[nrExercitii];
            lblsTip = new Label[nrExercitii];
            lblsDurata = new Label[nrExercitii];
            lblsZi = new Label[nrExercitii];
            int i = 0;

            foreach(Antrenament antrenament in antrenamente)
            {
                lblsExercitiu[i] = new Label();
                lblsExercitiu[i].Width = LATIME_CONTROL;
                lblsExercitiu[i].Text = antrenament.Exercitiu;
                lblsExercitiu[i].Left = DIMENSIUNE_PAS_Xa;
                lblsExercitiu[i].Top = startTop + (i + 1) * DIMENSIUNE_PAS_Ya;
                this.Controls.Add(lblsExercitiu[i]);

                lblsTip[i] = new Label();
                lblsTip[i].Width = LATIME_CONTROL;
                lblsTip[i].Text = antrenament.TipExercitiu;
                lblsTip[i].Left = 2 * DIMENSIUNE_PAS_Xa;
                lblsTip[i].Top = startTop + (i + 1) * DIMENSIUNE_PAS_Ya;
                this.Controls.Add(lblsTip[i]);

                lblsDurata[i] = new Label();
                lblsDurata[i].Width = LATIME_CONTROL;
                lblsDurata[i].Text = antrenament.Durata.ToString();
                lblsDurata[i].Left = 3 * DIMENSIUNE_PAS_Xa;
                lblsDurata[i].Top = startTop + (i + 1) * DIMENSIUNE_PAS_Ya;
                this.Controls.Add(lblsDurata[i]);

                lblsZi[i] = new Label();
                lblsZi[i].Width = LATIME_CONTROL;
                lblsZi[i].Text = antrenament.Zi.ToString();
                lblsZi[i].Left = 4 * DIMENSIUNE_PAS_Xa;
                lblsZi[i].Top = startTop + (i + 1) * DIMENSIUNE_PAS_Ya;
                this.Controls.Add(lblsZi[i]);

                i++;
            }
        }
    }
}
