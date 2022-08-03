using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributore
{
    public class Utente
    {
        public string Nome { get; set; }
        private double credito;
        public double Credito
        {
            get
            {
                return credito;
            }
            set
            {
                credito = Math.Round(value, 2);
            }
        }
        public List<string> ProdottiAcquistati { get; set; }

        public Utente(string nome, double credito, List<string> prodottiAcquistati)
        {
            this.Nome = nome;
            this.Credito = credito;
            this.ProdottiAcquistati = prodottiAcquistati;
        }
    }
}
