using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectContabilitate
{
    [Serializable]
    public class Cont: IComparable, ICloneable, ICalcul
    {
        private int numarCont;
        private string numeCont;
        private float sold_debitor;
        private float sold_creditor;

        public Cont(int numarCont, string numeCont, float sold_debitor, float sold_creditor)
        {
            this.numarCont = numarCont;
            this.numeCont = numeCont;
            this.sold_debitor = sold_debitor;
            this.sold_creditor = sold_creditor;
        }

        public int NumarCont { get => numarCont; set => numarCont = value; }
        public string NumeCont { get => numeCont; set => numeCont = value; }
        public float Sold_debitor { get => sold_debitor; set => sold_debitor = value; }
        public float Sold_creditor { get => sold_creditor; set => sold_creditor = value; }

        public float CalculCont()
        {
            return this.sold_debitor - this.sold_creditor;
        }

        public object Clone()
        {
            Cont c = new Cont(this.numarCont, this.numeCont, this.sold_debitor, this.sold_creditor);
            return c;
        }

        public int CompareTo(object obj)
        {
            if (obj is Cont)
            {
                Cont cont = (Cont)obj;
                if (this.numarCont > cont.numarCont)
                {
                    return 1;
                }
                else if (this.numarCont == cont.numarCont)
                {
                    return 0;
                }
                else {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }

        public static Cont operator+(Cont c, float soldInitial)
        {
            c.Sold_debitor += soldInitial;
            return c;
        }

        public static Cont operator-(Cont c, float soldFolosit)
        {
            c.sold_creditor -= soldFolosit;
            return c;
        }

        public override string ToString()
        {
            string result = $"Numar cont: {this.numarCont}, nume cont: {this.numeCont}, sold debitor: {this.sold_debitor}, sold creditor: {this.sold_creditor}\n";
            return result;
        }
    }
}
