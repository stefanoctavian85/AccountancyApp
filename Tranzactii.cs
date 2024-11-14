using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProiectContabilitate
{
    public partial class Tranzactii : Form
    {
        List<Tranzactie> listaTranzactii;
        public Tranzactii()
        {
            InitializeComponent();
            listaTranzactii = new List<Tranzactie>();
            tbTranzactii.ContextMenuStrip = contextMenuStrip1;
        }

        private void btnAdaugaTranzactie_Click(object sender, EventArgs e)
        {
            try
            {
                int numarTranzactie;
                if (!int.TryParse(tbNumarTranzactie.Text, out numarTranzactie))
                {
                    throw new Exception("Numarul tranzactiei trebuie sa fie un numar intreg!");
                }

                string descriere = tbDescriere.Text.Trim();
                if (string.IsNullOrEmpty(descriere) || (!Regex.IsMatch(descriere, @"^[a-zA-Z]+$")))
                {
                    throw new Exception("Descrierea tranzactiei trebuie sa contina doar litere!");
                }

                float suma;
                if (!float.TryParse(tbSuma.Text, out suma))
                {
                    throw new Exception("Suma trebuie sa fie un numar real!");
                }

                DateTime dataTranzactiei = dtp.Value.Date;

                Tranzactie t = new Tranzactie(numarTranzactie, descriere, suma, dataTranzactiei);
                listaTranzactii.Add(t);
                MessageBox.Show($"Tranzactia {descriere} a fost adaugata cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                tbNumarTranzactie.Clear();
                tbDescriere.Clear();
                tbSuma.Clear();
                tbNumarTranzactie.Focus();
            }
        }

        private void btnAfisareTranzactii_Click(object sender, EventArgs e)
        {
            tbTranzactii.Clear();
            if (listaTranzactii.Count > 0)
            {
                foreach (Tranzactie t in listaTranzactii)
                {
                    tbTranzactii.Text += t.ToString() + Environment.NewLine;
                }
            }
            else
            {
                MessageBox.Show("Va rugam introduceti tranzactii sau File >> Restaurare >> Fisier text/Binar", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fisierTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string numeFisier = "Tranzactie.txt";
            using (StreamWriter file = new StreamWriter(numeFisier))
            {
                foreach (Tranzactie t in listaTranzactii)
                {
                    file.WriteLine($"{t.NumarTranzactie},{t.Descriere},{t.Suma},{t.DataTranzactiei}");
                }
            }
            MessageBox.Show("Tranzactiile au fost salvate in fisierul " + numeFisier);
        }

        private void fisierBinarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string numeFisier = "Tranzactie.bin";
            FileStream fs = new FileStream(numeFisier, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, listaTranzactii);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Tranzactiile au fost salvate in fisierul " + numeFisier);
                fs.Close();
            }
        }

        private void fisierTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string numeFisier = "Tranzactie.txt";
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
                            int numarTranzactie = int.Parse(fields[0]);
                            string descriere = fields[1];
                            float suma = float.Parse(fields[2]);
                            DateTime dataTranzactiei = DateTime.Parse(fields[3]);

                            Tranzactie t = new Tranzactie(numarTranzactie, descriere,  suma, dataTranzactiei);
                            listaTranzactii.Add(t);
                        }
                    }
                }
                MessageBox.Show("Tranzactiile au fost restaurate din fisierul " + numeFisier);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void fisierBinarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string numeFisier = "Tranzactie.bin";
            try
            {
                using (FileStream fs = new FileStream(numeFisier, FileMode.Open))
                {
                BinaryFormatter bf = new BinaryFormatter();
                listaTranzactii = (List<Tranzactie>)bf.Deserialize(fs);
                }
                MessageBox.Show("Tranzactiile au fost deserializate din fisierul " + numeFisier);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void afisareTranzactiiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbTranzactii.Clear();
            if (listaTranzactii.Count > 0)
            {
                foreach (Tranzactie t in listaTranzactii)
                {
                    tbTranzactii.Text += t.ToString() + Environment.NewLine;
                }
            }
            else
            {
                MessageBox.Show("Nu sunt introduse date, va rugam introduceti sau File >> Restaurare >> Fisier text/Binar!", "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tranzactii_Load(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"TranzactiiXML.xml");
            XmlNodeList xnList = xmlDocument.SelectNodes("/catalog");
            foreach (XmlNode xn in xnList)
            {
                XmlNodeList xmlNodeList = xn.ChildNodes;
                foreach (XmlNode node in xmlNodeList)
                {
                    int numarTranzactie = Convert.ToInt32(node["NumarTranzactie"].InnerText);
                    string descriere = node["Descriere"].InnerText;
                    float suma = float.Parse(node["Suma"].InnerText);
                    DateTime dataTranzactiei = DateTime.Parse(node["DataTranzactiei"].InnerText).Date;
                    Tranzactie t = new Tranzactie(numarTranzactie, descriere, suma, dataTranzactiei);
                    lbTranzactiiXML.Items.Add(t);
                }
            }
        }
    }
}
