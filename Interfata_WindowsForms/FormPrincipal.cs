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
    public partial class FormPrincipal: MetroForm
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void mtJucatori_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var formJucator = new FormJucator())
            {
                formJucator.ShowDialog();
            }
            this.Show();
        }

        private void mtExercitiu_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var formExercitiu = new FormExercitiu())
            {
                formExercitiu.ShowDialog();
            }
            this.Show();
        }
    }
}
