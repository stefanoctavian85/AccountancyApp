using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectContabilitate
{
    [Serializable]
    public class Tranzactie: IComparable, ICloneable
    {
        private int numarTranzactie;
        private string descriere;
        private float suma;
        private DateTime dataTranzactiei;

        public Tranzactie(int numarTranzactie, string descriere, float suma, DateTime dataTranzactiei)
        {
            this.numarTranzactie = numarTranzactie;
            this.descriere = descriere;
            this.suma = suma;
            this.dataTranzactiei = dataTranzactiei;
        }
        public int NumarTranzactie { get => numarTranzactie; set => numarTranzactie = value; }
        public string Descriere { get => descriere; set => descriere = value; }
        public float Suma { get => suma; set => suma = value; }
        public DateTime DataTranzactiei { get => dataTranzactiei; set => dataTranzactiei = value; }

        public object Clone()
        {
            Tranzactie t = new Tranzactie(this.numarTranzactie, this.descriere, this.suma, this.dataTranzactiei);
            return t;
        }

        public int CompareTo(object obj)
        {
            if (obj is Tranzactie)
            {
                Tranzactie t = (Tranzactie)obj;
                if (this.numarTranzactie > t.numarTranzactie)
                {
                    return 1;
                }
                else if (this.numarTranzactie == t.numarTranzactie)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }

        public static Tranzactie operator+(Tranzactie t, float sumaAdaugata)
        {
            t.suma += sumaAdaugata;
            return t;
        }

        public static Tranzactie operator-(Tranzactie t, float sumaScazuta)
        {
            t.suma += sumaScazuta;
            return t;
        }

        public override string ToString()
        {
            return $"Numar: {this.numarTranzactie} - descriere: {this.descriere} - suma: {this.suma} - data: {this.dataTranzactiei}\n";
        }
    }
}
