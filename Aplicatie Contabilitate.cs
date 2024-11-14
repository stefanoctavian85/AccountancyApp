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
    public partial class AplicatieContabilitate : Form
    {
        private string nume;
        private string prenume;
        public AplicatieContabilitate()
        {
            InitializeComponent();
        }

        public AplicatieContabilitate(string nume, string prenume)
        {
            InitializeComponent();
            this.nume = nume;
            this.prenume = prenume;

            label4.Text = $"Bine ai venit, {this.nume} {this.prenume}!";
        }

        private void btnTranzactii_Click(object sender, EventArgs e)
        {
            Tranzactii tranzactii = new Tranzactii();
            tranzactii.Show();
        }

        private void btnConturi_Click(object sender, EventArgs e)
        {
            Conturi conturi = new Conturi();
            conturi.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tranzactiiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tranzactii tranzactii = new Tranzactii();
            tranzactii.Show();
        }

        private void conturiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conturi conturi = new Conturi();
            conturi.Show();
        }

        private void operatiiContabileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operatii_contabile operatii_contabile = new Operatii_contabile();
            operatii_contabile.Show();
        }

        private void btnOperatiiContabile_Click(object sender, EventArgs e)
        {
            Operatii_contabile operatii_contabile = new Operatii_contabile();
            operatii_contabile.Show();
        }
    }
}
