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
    public partial class FormAdaugareEx: MetroForm
    {
        private const int MIN_DURATA = 1;
        private const int MAX_DURATA = 300;
        public FormAdaugareEx()
        {
            InitializeComponent();
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            AdministrareAntrenament_FisierText adminAntrenament = new AdministrareAntrenament_FisierText(caleCompletaFisier2);
            mcbZi.DataSource = Enum.GetValues(typeof(Zile));
        }

        private void mlAdaugare_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show(
                    "Vă rugăm să corectați câmpurile evidențiate în roșu.",
                    "Date invalide",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            AdministrareAntrenament_FisierText adminAntrenament = new AdministrareAntrenament_FisierText(caleCompletaFisier2);
            Antrenament AntrenamentNou = new Antrenament();
            List<Antrenament> antrenamente = adminAntrenament.GetAntrenamente(out int nrAntrenamente);
            Zile ziEnum = (Zile)mcbZi.SelectedItem;

            Antrenament antrenament = new Antrenament(mtbExercitiu.Text,
                mtbTip.Text,
                int.Parse(mtbDurata.Text),
                ziEnum);
            adminAntrenament.AddAntrenament(antrenament);
        }
        private bool ValidateInputs()
        {
            bool allValid = true;

            bool numeValid = !string.IsNullOrWhiteSpace(mtbExercitiu.Text);
            allValid &= StyleTextbox(mtbExercitiu, mlExercitiu, numeValid);

            bool tipValid = !string.IsNullOrWhiteSpace(mtbTip.Text);
            allValid &= StyleTextbox(mtbTip, mlTip, tipValid);

            bool durataValid = int.TryParse(mtbDurata.Text, out int dur)
                               && dur >= MIN_DURATA
                               && dur <= MAX_DURATA;
            allValid &= StyleTextbox(mtbDurata, mlDurata, durataValid);

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
    }
}
