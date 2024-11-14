using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProiectContabilitate
{
    public class OperatiiContabile
    {
        private List<Cont> conturi;

        public OperatiiContabile(List<Cont> listaConturi)
        {
            this.conturi = listaConturi;
        }

        public List<Cont> ListaConturi { get => conturi; set => conturi = value; }

        public static OperatiiContabile operator+(OperatiiContabile o, Cont c)
        {
            o.conturi.Add(c);
            return o;
        }

        public static OperatiiContabile operator-(OperatiiContabile o, Cont c)
        {
            o.conturi.Remove(c);
            return o;
        }

        public Cont this[int index]
        {
            get {
                if (index < 0 || index > conturi.Count)
                {
                    throw new IndexOutOfRangeException("Indexul este in afara limitei listei!");
                }
                return conturi[index];
            }
            set {
                if (index < 0 || index > conturi.Count)
                {
                    throw new IndexOutOfRangeException("Indexul este in afara limitei listei!");
                }
                conturi[index] = value;
            }
        }

        public float CalculTotalSold()
        {
            float sumaTotala = 0;
            foreach(Cont c in conturi)
            {
                sumaTotala += c.Sold_debitor - c.Sold_creditor;
            }
            return sumaTotala;
        }

        public List<Cont> sortareConturiCuSoldPozitiv()
        {
            List<Cont> aux = new List<Cont>();

            foreach(Cont c in conturi)
            {
                if (c.Sold_debitor - c.Sold_creditor > 0)
                {
                    aux.Add(c);
                }
            }

            return aux;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Cont c in conturi)
            {
                result += c.ToString();
            }

            return result;
        }
    }
}
