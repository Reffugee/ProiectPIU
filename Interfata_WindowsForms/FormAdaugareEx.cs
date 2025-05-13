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
        }

        private void mlAdaugare_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show(
                    "Please correct the highlighted fields before continuing.",
                    "Validation Error",
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

            Action<MetroTextBox, MetroLabel, bool> styleTextbox = (tb, lbl, isValid) =>
            {
                tb.CustomForeColor = true;
                tb.ForeColor = isValid ? Color.Black : Color.Red;

                lbl.CustomForeColor = true;
                lbl.ForeColor = isValid ? Color.Black : Color.Red;

                if (!isValid) allValid = false;
            };
            bool numeValid = !string.IsNullOrWhiteSpace(mtbExercitiu.Text);
            styleTextbox(mtbExercitiu, mlExercitiu, numeValid);

            bool tipValid = !string.IsNullOrWhiteSpace(mtbTip.Text);
            styleTextbox(mtbTip, mlTip, tipValid);

            bool durataValid = int.TryParse(mtbDurata.Text, out int dur)
                               && dur >= MIN_DURATA
                               && dur <= MAX_DURATA;
            styleTextbox(mtbDurata, mlDurata, durataValid);


            return allValid;
        }
    }
}
