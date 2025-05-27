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
    public partial class FormAdaugaJucator: MetroForm
    {
        private List<string> PozitieSelectate = new List<string>();
        private const int MIN_NUMAR = 1;
        private const int MAX_NUMAR = 99;
        private const int MIN_INALTIME = 130;
        private const int MAX_INALTIME = 230;
        private const int MIN_GREUTATE = 30;
        private const int MAX_GREUTATE = 150;
        public FormAdaugaJucator()
        {
            InitializeComponent();

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministrareJucatori_FisierText adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);
        }

        private void mtAdauga_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Vă rugăm să corectați câmpurile evidențiate în roșu.",
                                "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministrareJucatori_FisierText adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);
            Jucator JucatorNou = new Jucator();
            List<Jucator> jucatori = adminJucatori.GetJucatori(out int nrJucatori);
            Pozitie pozitieCombinata = Pozitie.Necunoscut;
            foreach (string pozitie in PozitieSelectate)
            {
                pozitieCombinata |= (Pozitie)Enum.Parse(typeof(Pozitie), pozitie);
            }
            Jucator jucator = new Jucator(mtbNume.Text,
                mtbPrenume.Text,
                pozitieCombinata,
                dtpDataNasterii.Value,
                int.Parse(mtbNumar.Text),
                int.Parse(mtbInaltime.Text),
                int.Parse(mtbGreutate.Text));
            adminJucatori.AdaugaJucator(jucator);
        }
        private bool ValidateInputs()
        {
            bool allValid = true;

            allValid &= StyleTextbox(mtbNume, mlNume, !string.IsNullOrWhiteSpace(mtbNume.Text));
            allValid &= StyleTextbox(mtbPrenume, mlPrenume, !string.IsNullOrWhiteSpace(mtbPrenume.Text));

            bool numarValid = int.TryParse(mtbNumar.Text, out int numar)
                              && numar >= MIN_NUMAR && numar <= MAX_NUMAR;
            allValid &= StyleTextbox(mtbNumar, mlNumar, numarValid);

            bool inaltimeValid = int.TryParse(mtbInaltime.Text, out int inaltime)
                                 && inaltime >= MIN_INALTIME && inaltime <= MAX_INALTIME;
            allValid &= StyleTextbox(mtbInaltime, mlInaltime, inaltimeValid);

            bool greutateValid = int.TryParse(mtbGreutate.Text, out int greutate)
                                 && greutate >= MIN_GREUTATE && greutate <= MAX_GREUTATE;
            allValid &= StyleTextbox(mtbGreutate, mlGreutate, greutateValid);


            bool validPozitii = PozitieSelectate.Any();

            foreach (var cb in Controls.OfType<MetroCheckBox>().Where(c => c.Name.StartsWith("mcb")))
                allValid &= StyleCheckBox(cb, validPozitii);


            allValid &= StyleLabel(mlPozitie, validPozitii);

            return allValid;
        }


        private bool StyleTextbox(MetroTextBox tb, MetroLabel lbl, bool isValid)
        {
            tb.CustomForeColor = true;
            tb.ForeColor = isValid ? Color.Black : Color.Red;

            lbl.CustomForeColor = true;
            lbl.ForeColor = isValid ? Color.Black : Color.Red;

            return isValid;
        }

        private bool StyleCheckBox(MetroCheckBox cb, bool isValid)
        {
            cb.CustomForeColor = true;
            cb.ForeColor = isValid ? Color.Black : Color.Red;

            return isValid;
        }

        private bool StyleLabel(MetroLabel lbl, bool isValid)
        {
            lbl.CustomForeColor = true;
            lbl.ForeColor = isValid ? Color.Black : Color.Red;

            return isValid;
        }


        private void mcbPozitie_CheckedChanged(object sender, EventArgs e)
        {
            var mcb = sender as MetroCheckBox;
            if (mcb == null) return;
            string pozitieText = mcb.Text;

            if (mcb.Checked)
                PozitieSelectate.Add(pozitieText);
            else
                PozitieSelectate.Remove(pozitieText);
        }
    }
}
