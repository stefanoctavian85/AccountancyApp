using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectContabilitate
{
    public partial class Conturi : Form
    {
        List<Cont> listaConturi;
        const int margine = 10;
        Color culoareBars = Color.Blue;
        Font fontText = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
        Color culoareText = Color.Black;
        public Conturi()
        {
            InitializeComponent();
            listaConturi = new List<Cont>();

            lvConturi.ContextMenuStrip = contextMenuStrip1;
        }

        private void btnAdaugaCont_Click(object sender, EventArgs e)
        {
            try
            {
                int numarCont;
                if (!int.TryParse(tbNumarCont.Text, out numarCont))
                {
                    throw new Exception("Numarul contului trebuie sa fie un numar intreg!");
                }

                string numeCont = tbNumeCont.Text.Trim();
                if (string.IsNullOrEmpty(numeCont) || (!Regex.IsMatch(numeCont, @"^[a-zA-Z\s]+$"))) {
                    throw new Exception("Numele contului trebuie sa contina doar litere!");
                }

                float soldDebitor;
                if (!float.TryParse(tbSoldDebitor.Text, out soldDebitor))
                {
                    throw new Exception("Soldul debitor trebuie sa fie un numar real!");
                }

                float soldCreditor;
                if (!float.TryParse(tbSoldCreditor.Text, out soldCreditor))
                {
                    throw new Exception("Soldul creditor trebuie sa fie un numar real!");
                }

                Cont c = new Cont(numarCont, numeCont, soldDebitor, soldCreditor);
                listaConturi.Add(c);
                
                MessageBox.Show($"Contul {numeCont} a fost adaugat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                tbNumarCont.Clear();
                tbNumeCont.Clear();
                tbSoldDebitor.Clear();
                tbSoldCreditor.Clear();
                tbNumarCont.Focus();
            }
        }

        private void btnAfisareConturi_Click(object sender, EventArgs e)
        {
            lvConturi.Items.Clear();
            if (listaConturi.Count > 0) { 
                foreach (Cont c in listaConturi)
                {
                    ListViewItem lvi = new ListViewItem(c.NumarCont.ToString());
                    lvi.SubItems.Add(c.NumeCont);
                    lvi.SubItems.Add(c.Sold_debitor.ToString());
                    lvi.SubItems.Add(c.Sold_creditor.ToString());
                    lvConturi.Items.Add(lvi);
                }
            }
            else
            {
                MessageBox.Show("Nu sunt introduse date, va rugam introduceti sau Fisier >> Restaurare >> Fisier text/binar", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void fisierTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string numeFisier = "Conturi.txt";
            using (StreamWriter file = new StreamWriter(numeFisier))
            {
                foreach (Cont c in listaConturi)
                {
                    file.WriteLine($"{c.NumarCont},{c.NumeCont},{c.Sold_debitor},{c.Sold_creditor}");
                }
            }
            MessageBox.Show("Conturile au fost salvate in fisierul " + numeFisier);
        }

        private void fisierBinarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string numeFisier = "Conturi.bin";
            FileStream fs = new FileStream(numeFisier, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, listaConturi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Conturile au fost salvate in fisierul " + numeFisier);
                fs.Close();
            }
        }

        private void fisierTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string numeFisier = "Conturi.txt";
            if (File.Exists(numeFisier))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(numeFisier))
                    {
                        string linie;
                        while ((linie = sr.ReadLine()) != null)
                        {
                            string[] fields = linie.Split(',');

                            if (fields.Length == 4)
                            {
                                int numarCont = int.Parse(fields[0]);
                                string numeCont = fields[1];
                                float sold_Debitor = float.Parse(fields[2]);
                                float sold_Creditor = float.Parse(fields[3]);

                                Cont c = new Cont(numarCont, numeCont, sold_Debitor, sold_Creditor);
                                listaConturi.Add(c);
                            }
                        }
                    }
                    MessageBox.Show("Conturile au fost restaurate din fisierul " + numeFisier);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Eroare!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nu exista fisierul salvat!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fisierBinarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string numeFisier = "Conturi.bin";
            if (File.Exists(numeFisier))
            {
                try
                {
                    using (FileStream fs = new FileStream(numeFisier, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        listaConturi = (List<Cont>)bf.Deserialize(fs);
                    }
                    MessageBox.Show("Conturile au fost deserializate din fisierul " + numeFisier);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Eroare!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nu exista fisierul salvat!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolAfisareConturi_Click(object sender, EventArgs e)
        {
            lvConturi.Items.Clear();
            foreach (Cont c in listaConturi)
            {
                ListViewItem lvi = new ListViewItem(c.NumarCont.ToString());
                lvi.SubItems.Add(c.NumeCont);
                lvi.SubItems.Add(c.Sold_debitor.ToString());
                lvi.SubItems.Add(c.Sold_creditor.ToString());
                lvConturi.Items.Add(lvi);
            }
        }

        private void btnAfisareOperatiiContabile_Click(object sender, EventArgs e)
        {
            Operatii_contabile operatii_Contabile = new Operatii_contabile(listaConturi);
            operatii_Contabile.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            chart1.Visible = false;
            if (listaConturi.Count > 0)
            {
                Graphics g = e.Graphics;
                Rectangle rectangle = new Rectangle(panel1.ClientRectangle.X + margine, panel1.ClientRectangle.Y + 4 * margine, panel1.ClientRectangle.Width - 2 * margine, panel1.ClientRectangle.Height - 5 * margine);
                Pen pen = new Pen(Color.Red, 3);
                g.DrawRectangle(pen, rectangle);

                double latime = rectangle.Width / listaConturi.Count / 3;
                double distanta = (rectangle.Width - listaConturi.Count * latime) / (listaConturi.Count + 1);
                double vMax = listaConturi.Max(max => max.CalculCont());

                Brush brBars = new SolidBrush(culoareBars);
                Brush brFont = new SolidBrush(culoareText);

                Rectangle[] rectangles = new Rectangle[listaConturi.Count];
                for (int i = 0; i < rectangles.Length; i++)
                {
                    rectangles[i] = new Rectangle((int)(rectangle.Location.X + (i + 1) * distanta + i * latime),
                        (int)(rectangle.Location.Y + rectangle.Height - listaConturi[i].CalculCont() / vMax * rectangle.Height),
                        (int)latime,
                        (int)(listaConturi[i].CalculCont() / vMax * rectangle.Height));

                    g.DrawString(listaConturi[i].NumeCont, fontText, brFont, new Point((int)(rectangles[i].Location.X),
                        (int)(rectangles[i].Location.Y - fontText.Height)));

                }

                g.FillRectangles(brBars, rectangles);

                for (int i = 0; i < listaConturi.Count - 1; i++)
                {
                    g.DrawLine(pen, new Point((int)(rectangles[i].Location.X + latime / 2), (int)(rectangles[i].Location.Y)),
                        new Point((int)(rectangles[i + 1].Location.X + latime / 2), (int)(rectangles[i + 1].Location.Y)));
                }

            }
        }

        private void afisareGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listaConturi.Count > 0)
            {
                chart1.Series["Conturi"].Points.Clear();
                chart1.Titles.Clear();
                chart1.Visible = true;
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                for (int i = 0; i < listaConturi.Count; i++)
                {
                    chart1.Series["Conturi"].Points.AddXY(listaConturi[i].CalculCont(), listaConturi[i].NumarCont);
                }
                chart1.Titles.Add("Conturi");
            }
            else
            {
                MessageBox.Show("Conturile nu au fost adaugate!");
            }
        }

        private void pp(object sender, PrintPageEventArgs e)
        {
            if (listaConturi.Count > 0)
            {
                Graphics g = e.Graphics;
                Rectangle rectangle = new Rectangle(e.PageBounds.X + margine, e.PageBounds.Y + 4 * margine, e.PageBounds.Width - 2 * margine, e.PageBounds.Height - 5 * margine);
                Pen pen = new Pen(Color.Red, 3);
                g.DrawRectangle(pen, rectangle);

                double latime = rectangle.Width / listaConturi.Count / 3;
                double distanta = (rectangle.Width - listaConturi.Count * latime) / (listaConturi.Count + 1);
                double vMax = listaConturi.Max(max => max.CalculCont());

                Brush brBars = new SolidBrush(culoareBars);
                Brush brFont = new SolidBrush(culoareText);

                Rectangle[] rectangles = new Rectangle[listaConturi.Count];
                for (int i = 0; i < rectangles.Length; i++)
                {
                    rectangles[i] = new Rectangle((int)(rectangle.Location.X + (i + 1) * distanta + i * latime),
                        (int)(rectangle.Location.Y + rectangle.Height - listaConturi[i].CalculCont() / vMax * rectangle.Height),
                        (int)latime,
                        (int)(listaConturi[i].CalculCont() / vMax * rectangle.Height));

                    g.DrawString(listaConturi[i].NumeCont, fontText, brFont, new Point((int)(rectangles[i].Location.X),
                        (int)(rectangles[i].Location.Y - fontText.Height)));

                }

                g.FillRectangles(brBars, rectangles);

                for (int i = 0; i < listaConturi.Count - 1; i++)
                {
                    g.DrawLine(pen, new Point((int)(rectangles[i].Location.X + latime / 2), (int)(rectangles[i].Location.Y)),
                        new Point((int)(rectangles[i + 1].Location.X + latime / 2), (int)(rectangles[i + 1].Location.Y)));
                }

            }
        }

        private void printPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pp);
            PrintPreviewDialog pdlg = new PrintPreviewDialog
            {
                Document = pd
            };
            pdlg.ShowDialog();
        }
    }
}
