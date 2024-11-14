using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectContabilitate
{
    public partial class Conectare : UserControl
    {
        public Conectare()
        {
            InitializeComponent();
        }

        private void btnConectare_Click(object sender, EventArgs e)
        {
            string nume = tbNume.Text;
            string prenume = tbPrenume.Text;

            if (!string.IsNullOrEmpty(nume) && !string.IsNullOrEmpty(prenume) )
            {
                AplicatieContabilitate app = new AplicatieContabilitate(nume, prenume);
                app.Show();
            }
            else
            {
                MessageBox.Show("Va rugam sa introduceti datele dumneavoastra!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
