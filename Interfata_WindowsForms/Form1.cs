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
    public partial class Form1 : MetroForm
    {
        AdministrareJucatori_FisierText adminJucatori;
        AdministrareAntrenament_FisierText adminAntrenamente;

        private DataGridView dgvAntrenamente;
        private DateTimePicker dtpDataNasterii;

        private MetroLabel lblNume;
        private MetroLabel lblPrenume;
        private MetroLabel lblPozitie;
        private MetroLabel lblNumar;
        private MetroLabel lblVarsta;
        private MetroLabel lblInaltime;
        private MetroLabel lblGreutate;

        private MetroLabel lblExercitiu;
        private MetroLabel lblTip;
        private MetroLabel lblDurata;
        private MetroLabel lblZi;

        private MetroButton btnRefresh;

        private MetroTextBox txtNume, txtPrenume, txtPozitie, txtNumar, txtVarsta, txtInaltime, txtGreutate;
        private MetroTextBox txtExercitiu, txtTip, txtDurata;
        private MetroComboBox cmbZi;
        private MetroTextBox txtCautaNume, txtCautaPrenume;
        private MetroButton btnAdaugaJucator, btnAdaugaExercitiu;
        private MetroButton btnCautare;

        private MetroLabel[,] lblJucatori;

        private MetroLabel[,] lblExercitii;

        private const int LATIME_CONTROL = 70;
        private const int DIMENSIUNE_PAS_Y = 60;
        private const int DIMENSIUNE_PAS_X = 150;

        private const int DIMENSIUNE_PAS_Ya = 280;
        private const int DIMENSIUNE_PAS_Xa = 150;

        private const int DIMENSIUNE_LABEL_EXERCITII = 250;
        private const int DIMENSIUNE_ADAUGARE_EXERCITII = 550;
        private const int DIMENSIUNE_ADAUGARE_JUCATORI = 500;

        private const int MIN_NUMAR = 1;
        private const int MAX_NUMAR = 99;
        private const int MIN_INALTIME = 150;
        private const int MAX_INALTIME = 220;
        private const int MIN_GREUTATE = 50;
        private const int MAX_GREUTATE = 120;
        private const int MIN_DURATA = 5;
        private const int MAX_DURATA = 120;
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
            this.Size = new Size(1300, 600);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(20,5,60);
            this.Text = "Informatii jucatori si exercitii";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;

            //adaugare control de tip MetroLabel pentru 'Nume';
            lblNume = new MetroLabel();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Top = DIMENSIUNE_PAS_Y;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.ForeColor = Color.Wheat;
            this.Controls.Add(lblNume);

            //adaugare control de tip MetroLabel pentru 'Prenume';
            lblPrenume = new MetroLabel();
            lblPrenume.Width = LATIME_CONTROL;
            lblPrenume.Top = DIMENSIUNE_PAS_Y;
            lblPrenume.Text = "Prenume";
            lblPrenume.Left = 2 * DIMENSIUNE_PAS_X;
            lblPrenume.ForeColor = Color.Wheat;
            this.Controls.Add(lblPrenume);

            //adaugare control de tip MetroLabel pentru 'Pozitie';
            lblPozitie = new MetroLabel();
            lblPozitie.Width = LATIME_CONTROL;
            lblPozitie.Top = DIMENSIUNE_PAS_Y;
            lblPozitie.Text = "Pozitie";
            lblPozitie.Left = 3 * DIMENSIUNE_PAS_X;
            lblPozitie.ForeColor = Color.Wheat;
            this.Controls.Add(lblPozitie);

            //adaugare control de tip MetroLabel pentru 'Numar';
            lblNumar = new MetroLabel();
            lblNumar.Width = LATIME_CONTROL;
            lblNumar.Top = DIMENSIUNE_PAS_Y;
            lblNumar.Text = "Numar";
            lblNumar.Left = 4 * DIMENSIUNE_PAS_X;
            lblNumar.ForeColor = Color.Wheat;
            this.Controls.Add(lblNumar);

            //adaugare control de tip MetroLabel pentru 'Varsta';
            lblVarsta = new MetroLabel();
            lblVarsta.Width = LATIME_CONTROL;
            lblVarsta.Top = DIMENSIUNE_PAS_Y;
            lblVarsta.Text = "Varsta";
            lblVarsta.Left = 5 * DIMENSIUNE_PAS_X;
            lblVarsta.ForeColor = Color.Wheat;
            this.Controls.Add(lblVarsta);

            //adaugare control de tip MetroLabel pentru 'Inaltime';
            lblInaltime = new MetroLabel();
            lblInaltime.Width = LATIME_CONTROL;
            lblInaltime.Top = DIMENSIUNE_PAS_Y;
            lblInaltime.Text = "Inaltime";
            lblInaltime.Left = 6 * DIMENSIUNE_PAS_X;
            lblInaltime.ForeColor = Color.Wheat;
            this.Controls.Add(lblInaltime);

            //adaugare control de tip MetroLabel pentru 'Greutate';
            lblGreutate = new MetroLabel();
            lblGreutate.Width = LATIME_CONTROL;
            lblGreutate.Top = DIMENSIUNE_PAS_Y;
            lblGreutate.Text = "Greutate";
            lblGreutate.Left = 7 * DIMENSIUNE_PAS_X;
            lblGreutate.ForeColor = Color.Wheat;
            this.Controls.Add(lblGreutate);

            //adaugare control de tip MetroLabel pentru 'Exercitiu';
            lblExercitiu = new MetroLabel();
            lblExercitiu.Width = LATIME_CONTROL;
            lblExercitiu.Top = DIMENSIUNE_LABEL_EXERCITII;
            lblExercitiu.Text = "Exercitiu";
            lblExercitiu.Left = DIMENSIUNE_PAS_Xa;
            lblExercitiu.ForeColor = Color.Wheat;
            this.Controls.Add(lblExercitiu);

            //adaugare control de tip MetroLabel pentru 'Tip';
            lblTip = new MetroLabel();
            lblTip.Width = LATIME_CONTROL;
            lblTip.Top = DIMENSIUNE_LABEL_EXERCITII;
            lblTip.Text = "Tip";
            lblTip.Left = 2 * DIMENSIUNE_PAS_Xa;
            lblTip.ForeColor = Color.Wheat;
            this.Controls.Add(lblTip);

            //adaugare control de tip MetroLabel pentru 'Durata';
            lblDurata = new MetroLabel();
            lblDurata.Width = LATIME_CONTROL;
            lblDurata.Top = DIMENSIUNE_LABEL_EXERCITII;
            lblDurata.Text = "Durata";
            lblDurata.Left = 3 * DIMENSIUNE_PAS_Xa;
            lblDurata.ForeColor = Color.Wheat;
            this.Controls.Add(lblDurata);

            //adaugare control de tip MetroLabel pentru 'Zi';
            lblZi = new MetroLabel();
            lblZi.Width = LATIME_CONTROL;
            lblZi.Top = DIMENSIUNE_LABEL_EXERCITII;
            lblZi.Text = "Zi";
            lblZi.Left = 4 * DIMENSIUNE_PAS_Xa;
            lblZi.ForeColor = Color.Wheat;
            this.Controls.Add(lblZi);

            // adaugare buton pentru refresh
            btnRefresh = new MetroButton();
            btnRefresh.Text = "Refresh";
            btnRefresh.Width = 100;
            btnRefresh.Height = 30;
            btnRefresh.Top = this.ClientSize.Height - 50;
            btnRefresh.Left = 20;
            btnRefresh.Click += BtnRefresh_Click;
            this.Controls.Add(btnRefresh);

            // --- MetroTextBox-uri pentru jucători ---
            txtNume = new MetroTextBox();
            txtNume.Width = LATIME_CONTROL;
            txtNume.Left = DIMENSIUNE_PAS_X;
            txtNume.Top = DIMENSIUNE_ADAUGARE_JUCATORI;
            this.Controls.Add(txtNume);

            txtPrenume = new MetroTextBox();
            txtPrenume.Width = LATIME_CONTROL;
            txtPrenume.Left = 2 * DIMENSIUNE_PAS_X;
            txtPrenume.Top = DIMENSIUNE_ADAUGARE_JUCATORI;
            this.Controls.Add(txtPrenume);

            txtPozitie = new MetroTextBox();
            txtPozitie.Width = LATIME_CONTROL;
            txtPozitie.Left = 3 * DIMENSIUNE_PAS_X;
            txtPozitie.Top = DIMENSIUNE_ADAUGARE_JUCATORI;
            this.Controls.Add(txtPozitie);

            txtNumar = new MetroTextBox();
            txtNumar.Width = LATIME_CONTROL;
            txtNumar.Left = 4 * DIMENSIUNE_PAS_X;
            txtNumar.Top = DIMENSIUNE_ADAUGARE_JUCATORI;
            this.Controls.Add(txtNumar);

            dtpDataNasterii = new DateTimePicker();
            dtpDataNasterii.Width = 100;
            dtpDataNasterii.Left = 5 * DIMENSIUNE_PAS_X;
            dtpDataNasterii.Top = DIMENSIUNE_ADAUGARE_JUCATORI;
            dtpDataNasterii.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpDataNasterii);

            txtInaltime = new MetroTextBox();
            txtInaltime.Width = LATIME_CONTROL;
            txtInaltime.Left = 6 * DIMENSIUNE_PAS_X;
            txtInaltime.Top = DIMENSIUNE_ADAUGARE_JUCATORI;
            this.Controls.Add(txtInaltime);

            txtGreutate = new MetroTextBox();
            txtGreutate.Width = LATIME_CONTROL;
            txtGreutate.Left = 7 * DIMENSIUNE_PAS_X;
            txtGreutate.Top = DIMENSIUNE_ADAUGARE_JUCATORI;
            this.Controls.Add(txtGreutate);

            // --- MetroTextBox-uri pentru antrenamente ---
            txtExercitiu = new MetroTextBox();
            txtExercitiu.Width = LATIME_CONTROL;
            txtExercitiu.Left = DIMENSIUNE_PAS_Xa;
            txtExercitiu.Top = DIMENSIUNE_ADAUGARE_EXERCITII;
            this.Controls.Add(txtExercitiu);

            txtTip = new MetroTextBox();
            txtTip.Width = LATIME_CONTROL;
            txtTip.Left = 2 * DIMENSIUNE_PAS_Xa;
            txtTip.Top = DIMENSIUNE_ADAUGARE_EXERCITII;
            this.Controls.Add(txtTip);

            txtDurata = new MetroTextBox();
            txtDurata.Width = LATIME_CONTROL;
            txtDurata.Left = 3 * DIMENSIUNE_PAS_Xa;
            txtDurata.Top = DIMENSIUNE_ADAUGARE_EXERCITII;
            this.Controls.Add(txtDurata);

            cmbZi = new MetroComboBox();
            cmbZi.Width = LATIME_CONTROL;
            cmbZi.Left = 4 * DIMENSIUNE_PAS_Xa;
            cmbZi.Top = DIMENSIUNE_ADAUGARE_EXERCITII;
            cmbZi.DataSource = Enum.GetValues(typeof(Zile));
            this.Controls.Add(cmbZi);

            // MetroTextBox pentru cautare
            txtCautaNume= new MetroTextBox();
            txtCautaNume.Width = LATIME_CONTROL;
            txtCautaNume.Left = 1 * DIMENSIUNE_PAS_Xa;
            txtCautaNume.Top = 600;
            this.Controls.Add(txtCautaNume);

            txtCautaPrenume = new MetroTextBox();
            txtCautaPrenume.Width = LATIME_CONTROL;
            txtCautaPrenume.Left = 2 * DIMENSIUNE_PAS_Xa;
            txtCautaPrenume.Top = 600;
            this.Controls.Add(txtCautaPrenume);

            // --- Buton pentru salvare ---
            btnAdaugaJucator = new MetroButton();
            btnAdaugaJucator.Width = 150;
            btnAdaugaJucator.Text = "Adauga Jucator";
            btnAdaugaJucator.Left = 8 * DIMENSIUNE_PAS_X;
            btnAdaugaJucator.Top = DIMENSIUNE_ADAUGARE_JUCATORI;
            btnAdaugaJucator.Click += BtnAdaugaJucator_Click;
            this.Controls.Add(btnAdaugaJucator);

            btnAdaugaExercitiu = new MetroButton();
            btnAdaugaExercitiu.Width = 150;
            btnAdaugaExercitiu.Text = "Adauga Exercitiu";
            btnAdaugaExercitiu.Left = 5 * DIMENSIUNE_PAS_Xa;
            btnAdaugaExercitiu.Top = DIMENSIUNE_ADAUGARE_EXERCITII;
            btnAdaugaExercitiu.Click += BtnAdaugaExercitiu_Click;
            this.Controls.Add(btnAdaugaExercitiu);

            // buton cautare
            btnCautare = new MetroButton();
            btnCautare.Width = 150;
            btnCautare.Text = "Cauta Jucator";
            btnCautare.Left = 3 * DIMENSIUNE_PAS_Xa;
            btnCautare.Top = 600;
            btnCautare.Click += BtnCautare_Click;
            this.Controls.Add(btnCautare);
        }

        private void BtnAdaugaJucator_Click(object sender, EventArgs e)
        {
            if (!ValidateJucator())
                return;
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministrareJucatori_FisierText adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);
            Jucator JucatorNou = new Jucator();
            List<Jucator> jucatori = adminJucatori.GetJucatori(out int nrJucatori);
            Jucator jucator = new Jucator(txtNume.Text, 
                txtPrenume.Text, 
                (Pozitie)Enum.Parse(typeof(Pozitie), 
                txtPozitie.Text),
                dtpDataNasterii.Value,
                int.Parse(txtNumar.Text),  
                int.Parse(txtInaltime.Text),
                int.Parse(txtGreutate.Text));
            adminJucatori.AdaugaJucator(jucator);
        }

        private void BtnAdaugaExercitiu_Click(object sender, EventArgs e)
        {
            if (!ValidateExercitiu())
                return;
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            AdministrareAntrenament_FisierText adminAntrenament = new AdministrareAntrenament_FisierText(caleCompletaFisier2);
            Antrenament AntrenamentNou = new Antrenament();
            List<Antrenament> antrenamente = adminAntrenament.GetAntrenamente(out int nrAntrenamente);
            Zile ziEnum = (Zile)cmbZi.SelectedItem;

            Antrenament antrenament = new Antrenament(txtExercitiu.Text,
                txtTip.Text,
                int.Parse(txtDurata.Text),
                ziEnum);
            adminAntrenament.AddAntrenament(antrenament);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaJucator();
            AfiseazaExercitii();
        }

        private void BtnCautare_Click(object sender, EventArgs e)
        {
            string nume = txtCautaNume.Text;
            string prenume = txtCautaPrenume.Text;
            List<Jucator> jucatori = adminJucatori.GetJucatori(out int nrJucatori);
            var jucatorGasit = jucatori.FirstOrDefault(j => j.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase) && j.Prenume.Equals(prenume, StringComparison.OrdinalIgnoreCase));

            // Clear previous search results  
            StergereJucatorCautat();

            if (jucatorGasit != null)
            {
                // Display player information in a horizontal manner below the search fields  
                MetroLabel lblInfoJucator = new MetroLabel();
                lblInfoJucator.AutoSize = true;
                lblInfoJucator.Top = txtCautaPrenume.Bottom + 10;
                lblInfoJucator.Left = txtCautaNume.Left;
                lblInfoJucator.ForeColor = Color.Wheat;
                lblInfoJucator.Text = $"Jucator gasit: " +
                                      $"Nume: {jucatorGasit.Nume}, " +
                                      $"Prenume: {jucatorGasit.Prenume}, " +
                                      $"Pozitie: {jucatorGasit.Pozitie}, " +
                                      $"Data Nasterii: {jucatorGasit.DataNastere.ToShortDateString()}, " +
                                      $"Numar: {jucatorGasit.Numar}, " +
                                      $"Inaltime: {jucatorGasit.Inaltime} cm, " +
                                      $"Greutate: {jucatorGasit.Greutate} kg, " +
                                      $"Varsta: {jucatorGasit.Varsta} ani";

                this.Controls.Add(lblInfoJucator);
                lblInfoJucator.Tag = "Jucator Cautat"; 
            }
            else
            {
                MetroLabel lblInfoJucator = new MetroLabel();
                lblInfoJucator.AutoSize = true;
                lblInfoJucator.Top = txtCautaPrenume.Bottom + 10;
                lblInfoJucator.Left = txtCautaNume.Left;
                lblInfoJucator.ForeColor = Color.Red;
                lblInfoJucator.Text = "Jucatorul nu a fost gasit!";
                this.Controls.Add(lblInfoJucator);
                lblInfoJucator.Tag = "Jucator Cautat"; 
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

        private bool ValidateJucator()
        {
            bool valid = true;
            string errorMessage = "Erori la inregistrare:\n";

            // Validare Nume
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                lblNume.ForeColor = Color.Red;
                errorMessage += "Nume invalid.\n";
                valid = false;
            }
            else
            {
                lblNume.ForeColor = Color.Wheat;
            }

            // Validare Prenume
            if (string.IsNullOrWhiteSpace(txtPrenume.Text))
            {
                lblPrenume.ForeColor = Color.Red;
                errorMessage += "Prenume invalid.\n";
                valid = false;
            }
            else
            {
                lblPrenume.ForeColor = Color.Wheat;
            }

            // Validare Pozitie - presupunem că valoarea introdusă trebuie să corespundă unui enum valid
            try
            {
                var pozitie = (Pozitie)Enum.Parse(typeof(Pozitie), txtPozitie.Text, true);
                lblPozitie.ForeColor = Color.Wheat;
            }
            catch
            {
                lblPozitie.ForeColor = Color.Red;
                errorMessage += "Pozitie invalida.\n";
                valid = false;
            }

            // Validare Numar
            if (!int.TryParse(txtNumar.Text, out int numar) || numar < MIN_NUMAR || numar > MAX_NUMAR)
            {
                lblNumar.ForeColor = Color.Red;
                errorMessage += $"Numarul trebuie sa fie intre {MIN_NUMAR} si {MAX_NUMAR}.\n";
                valid = false;
            }
            else
            {
                lblNumar.ForeColor = Color.Wheat;
            }

            // Validare DataNasterii (exemplu: jucatorul trebuie să aibă minim 16 ani)
            int varsta = DateTime.Now.Year - dtpDataNasterii.Value.Year;
            if (varsta < 16)
            {
                // Puteți modifica această regulă după nevoie
                lblVarsta.ForeColor = Color.Red;
                errorMessage += "Jucatorul trebuie sa aiba minim 16 ani.\n";
                valid = false;
            }
            else
            {
                lblVarsta.ForeColor = Color.Wheat;
            }

            // Validare Inaltime
            if (!int.TryParse(txtInaltime.Text, out int inaltime) || inaltime < MIN_INALTIME || inaltime > MAX_INALTIME)
            {
                lblInaltime.ForeColor = Color.Red;
                errorMessage += $"Inaltimea trebuie sa fie intre {MIN_INALTIME} si {MAX_INALTIME}.\n";
                valid = false;
            }
            else
            {
                lblInaltime.ForeColor = Color.Wheat;
            }

            // Validare Greutate
            if (!int.TryParse(txtGreutate.Text, out int greutate) || greutate < MIN_GREUTATE || greutate > MAX_GREUTATE)
            {
                lblGreutate.ForeColor = Color.Red;
                errorMessage += $"Greutatea trebuie sa fie intre {MIN_GREUTATE} si {MAX_GREUTATE}.\n";
                valid = false;
            }
            else
            {
                lblGreutate.ForeColor = Color.Wheat;
            }

            if (!valid)
            {
                MessageBox.Show(errorMessage, "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private bool ValidateExercitiu()
        {
            bool valid = true;
            string errorMessage = "Erori la inregistrarea exercitiului:\n";

            // Validare Exercitiu
            if (string.IsNullOrWhiteSpace(txtExercitiu.Text))
            {
                lblExercitiu.ForeColor = Color.Red;
                errorMessage += "Exercitiu invalid.\n";
                valid = false;
            }
            else
            {
                lblExercitiu.ForeColor = Color.Wheat;
            }

            // Validare Tip
            if (string.IsNullOrWhiteSpace(txtTip.Text))
            {
                lblTip.ForeColor = Color.Red;
                errorMessage += "Tipul exercitiului invalid.\n";
                valid = false;
            }
            else
            {
                lblTip.ForeColor = Color.Wheat;
            }

            // Validare Durata
            if (!int.TryParse(txtDurata.Text, out int durata) || durata < MIN_DURATA || durata > MAX_DURATA)
            {
                lblDurata.ForeColor = Color.Red;
                errorMessage += $"Durata trebuie sa fie intre {MIN_DURATA} si {MAX_DURATA} minute.\n";
                valid = false;
            }
            else
            {
                lblDurata.ForeColor = Color.Wheat;
            }

            // Validare Zi
            if (cmbZi.SelectedItem == null)
            {
                lblZi.ForeColor = Color.Red;
                errorMessage += "Zi invalida.\n";
                valid = false;
            }
            else
            {
                lblZi.ForeColor = Color.Wheat;
            }

            if (!valid)
            {
                MessageBox.Show(errorMessage, "Date exercitiu invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaJucator();
            AfiseazaExercitii();
        }
        private void AfiseazaJucator()
        {
            List<Jucator> jucatori = adminJucatori.GetJucatori(out int nrJucatori);

            int nrColoane = 7; // Nume, Prenume, Pozitie, Numar, Varsta, Inaltime, Greutate
            lblJucatori = new MetroLabel[nrJucatori, nrColoane];

            int startTop = DIMENSIUNE_PAS_Y * 2; // Adjust starting position to avoid overlap
            int incrementY = 30;
            for (int i = 0; i < nrJucatori; i++)
            {
                int pozitieY = startTop + (i * incrementY);

                // Coloana 0: Nume
                lblJucatori[i, 0] = new MetroLabel();
                lblJucatori[i, 0].Width = LATIME_CONTROL;
                lblJucatori[i, 0].Text = jucatori[i].Nume;
                lblJucatori[i, 0].Left = 1 * DIMENSIUNE_PAS_X;
                lblJucatori[i, 0].Top = pozitieY;
                this.Controls.Add(lblJucatori[i, 0]);

                // Coloana 1: Prenume
                lblJucatori[i, 1] = new MetroLabel();
                lblJucatori[i, 1].Width = LATIME_CONTROL;
                lblJucatori[i, 1].Text = jucatori[i].Prenume;
                lblJucatori[i, 1].Left = 2 * DIMENSIUNE_PAS_X;
                lblJucatori[i, 1].Top = pozitieY;
                this.Controls.Add(lblJucatori[i, 1]);

                // Coloana 2: Pozitie
                lblJucatori[i, 2] = new MetroLabel();
                lblJucatori[i, 2].AutoSize = true;
                lblJucatori[i, 2].Text = jucatori[i].Pozitie.ToString();
                lblJucatori[i, 2].Left = 3 * DIMENSIUNE_PAS_X;
                lblJucatori[i, 2].Top = pozitieY;
                this.Controls.Add(lblJucatori[i, 2]);

                // Coloana 3: Numar
                lblJucatori[i, 3] = new MetroLabel();
                lblJucatori[i, 3].Width = LATIME_CONTROL;
                lblJucatori[i, 3].Text = jucatori[i].Numar.ToString();
                lblJucatori[i, 3].Left = 4 * DIMENSIUNE_PAS_X;
                lblJucatori[i, 3].Top = pozitieY;
                this.Controls.Add(lblJucatori[i, 3]);

                // Coloana 4: Varsta
                lblJucatori[i, 4] = new MetroLabel();
                lblJucatori[i, 4].Width = LATIME_CONTROL;
                lblJucatori[i, 4].Text = jucatori[i].Varsta.ToString();
                lblJucatori[i, 4].Left = 5 * DIMENSIUNE_PAS_X;
                lblJucatori[i, 4].Top = pozitieY;
                this.Controls.Add(lblJucatori[i, 4]);

                // Coloana 5: Inaltime
                lblJucatori[i, 5] = new MetroLabel();
                lblJucatori[i, 5].Width = LATIME_CONTROL;
                lblJucatori[i, 5].Text = jucatori[i].Inaltime.ToString();
                lblJucatori[i, 5].Left = 6 * DIMENSIUNE_PAS_X;
                lblJucatori[i, 5].Top = pozitieY;
                this.Controls.Add(lblJucatori[i, 5]);

                // Coloana 6: Greutate
                lblJucatori[i, 6] = new MetroLabel();
                lblJucatori[i, 6].Width = LATIME_CONTROL;
                lblJucatori[i, 6].Text = jucatori[i].Greutate.ToString();
                lblJucatori[i, 6].Left = 7 * DIMENSIUNE_PAS_X;
                lblJucatori[i, 6].Top = pozitieY;
                this.Controls.Add(lblJucatori[i, 6]);
            }
        }
        private void AfiseazaExercitii()
        {
            int nrExercitii;
            List<Antrenament> antrenamente = adminAntrenamente.GetAntrenamente(out nrExercitii);

            int nrColoane = 4; // Exercitiu, Tip, Durata, Zi  
            lblExercitii = new MetroLabel[nrExercitii, nrColoane];

            int startTop = DIMENSIUNE_PAS_Ya;
            int incrementY = 30; 

            for (int i = 0; i < nrExercitii; i++)
            {
                int pozitieY = startTop + (i * incrementY); 

                // Coloana 0: Exercitiu  
                lblExercitii[i, 0] = new MetroLabel();
                lblExercitii[i, 0].Width = LATIME_CONTROL;
                lblExercitii[i, 0].Text = antrenamente[i].Exercitiu;
                lblExercitii[i, 0].Left = 1 * DIMENSIUNE_PAS_Xa;
                lblExercitii[i, 0].Top = pozitieY;
                this.Controls.Add(lblExercitii[i, 0]);

                // Coloana 1: Tip  
                lblExercitii[i, 1] = new MetroLabel();
                lblExercitii[i, 1].Width = LATIME_CONTROL;
                lblExercitii[i, 1].Text = antrenamente[i].TipExercitiu;
                lblExercitii[i, 1].Left = 2 * DIMENSIUNE_PAS_Xa;
                lblExercitii[i, 1].Top = pozitieY;
                this.Controls.Add(lblExercitii[i, 1]);

                // Coloana 2: Durata  
                lblExercitii[i, 2] = new MetroLabel();
                lblExercitii[i, 2].Width = LATIME_CONTROL;
                lblExercitii[i, 2].Text = antrenamente[i].Durata.ToString();
                lblExercitii[i, 2].Left = 3 * DIMENSIUNE_PAS_Xa;
                lblExercitii[i, 2].Top = pozitieY;
                this.Controls.Add(lblExercitii[i, 2]);

                // Coloana 3: Zi  
                lblExercitii[i, 3] = new MetroLabel();
                lblExercitii[i, 3].Width = LATIME_CONTROL;
                lblExercitii[i, 3].Text = antrenamente[i].Zi.ToString();
                lblExercitii[i, 3].Left = 4 * DIMENSIUNE_PAS_Xa;
                lblExercitii[i, 3].Top = pozitieY;
                this.Controls.Add(lblExercitii[i, 3]);
            }
        }
    }
}
