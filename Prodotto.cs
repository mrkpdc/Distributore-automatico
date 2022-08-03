using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributore
{
    public abstract class Prodotto
    {
        public string Nome { get; set; }
        private double costo;
        public double Costo
        {
            get
            {
                return this.costo;
            }
            set
            {
                costo = Math.Round(value, 2);
            }
        }
        public string Codice { get; set; }
        public int Disponibilita { get; set; }
    }

    public class Bibita : Prodotto
    {
        public Bibita(string nome, double costo, string codice, int disponibilita)
        {
            this.Nome = nome;
            this.Costo = costo;
            this.Codice = codice;
            this.Disponibilita = disponibilita;
        }
    }

    public class Patatine : Prodotto
    {
        public Patatine(string nome, double costo, string codice, int disponibilita)
        {
            this.Nome = nome;
            this.Costo = costo;
            this.Codice = codice;
            this.Disponibilita = disponibilita;
        }
    }

    public class Sandwich : Prodotto
    {
        public Sandwich(string nome, double costo, string codice, int disponibilita)
        {
            this.Nome = nome;
            this.Costo = costo;
            this.Codice = codice;
            this.Disponibilita = disponibilita;
        }
    }

    public class Acqua : Prodotto
    {
        public Acqua(string nome, double costo, string codice, int disponibilita)
        {
            this.Nome = nome;
            this.Costo = costo;
            this.Codice = codice;
            this.Disponibilita = disponibilita;
        }
    }
}
