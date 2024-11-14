using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectContabilitate
{
    public partial class Operatii_contabile : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BD-Conturi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        OperatiiContabile o;
        public Operatii_contabile()
        {
            InitializeComponent();
            MessageBox.Show("Va rugam sa introduceti conturi! >> Conturi >> File >> Restaurare >> Alegeti o optiune! sau introduceti conturile dvs!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public Operatii_contabile(List<Cont> listaConturi)
        {
            InitializeComponent();
            dgvConturi.ContextMenuStrip = contextMenuStrip1;
            tbSoldTotal.ContextMenuStrip = contextMenuStrip2;
            if (listaConturi != null && listaConturi.Count > 0)
            {
                o = new OperatiiContabile(listaConturi);
                connection.Open();
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM Conturi", connection);
                deleteCommand.ExecuteNonQuery();
                foreach (Cont c in listaConturi)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Conturi([Numar cont], [Nume cont], [Sold debitor], [Sold creditor]) "
                    + "VALUES(@numarCont, @numeCont, @soldDebitor, @soldCreditor)", connection);
                    command.Parameters.AddWithValue("@numarCont", c.NumarCont);
                    command.Parameters.AddWithValue("@numeCont", c.NumeCont);
                    command.Parameters.AddWithValue("@soldDebitor", c.Sold_debitor);
                    command.Parameters.AddWithValue("@soldCreditor", c.Sold_creditor);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Va rugam sa introduceti conturi! >> Conturi >> File >> Restaurare >> Alegeti o optiune! sau introduceti conturile dvs!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void btnConturi_Click(object sender, EventArgs e)
        {
            Conturi conturi = new Conturi();
            conturi.Show();
            this.Close();
        }

        private void btnAfisareOperatiiContabile_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM Conturi", connection);
            int count = (int)countCommand.ExecuteScalar();

            if (count > 0)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Conturi", connection);
                adapter.Fill(dt);
                dgvConturi.DataSource = dt;
                connection.Close();
            }
            else
            {
                MessageBox.Show("Va rugam adaugati conturi!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSoldTotal_Click(object sender, EventArgs e)
        {
            float calculTotal = 0;
            if (o == null || o.ListaConturi.Count <= 0)
            {
                MessageBox.Show("Va rugam sa introduceti conturi! >> Conturi >> File >> Restaurare >> Alegeti o optiune! sau introduceti conturile dvs!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                calculTotal = o.CalculTotalSold();
            }
            tbSoldTotal.Text = calculTotal.ToString();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            float calculTotal = 0;
            if (o.CalculTotalSold() > 0 && o!=null)
            {
                calculTotal = o.CalculTotalSold();
            }
            tbSoldTotal.Text = calculTotal.ToString();
        }

        private void toolAfisareOperatiiContabile_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM Conturi", connection);
            int count = (int)countCommand.ExecuteScalar();

            if (count > 0)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Conturi", connection);
                adapter.Fill(dt);
                dgvConturi.DataSource = dt;
                connection.Close();
            }
            else
            {
                MessageBox.Show("Va rugam adaugati conturi!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
