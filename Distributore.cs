using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributore
{
    public class Distributore
    {
        public int CodiceDistributore { get; set; }
        public List<Prodotto> ListaProdotti { get; set; }

        public Distributore(int codiceDistributore, List<Prodotto> listaProdotti)
        {
            this.CodiceDistributore = codiceDistributore;
            this.ListaProdotti = listaProdotti;
        }

        public int SelezionaIlProdotto()
        {
            Console.WriteLine("Seleziona il prodotto:");
            Console.WriteLine();
            foreach (Prodotto prodotto in ListaProdotti)
            {
                Console.WriteLine("Codice: " + prodotto.Codice);
                Console.WriteLine("Prodotto: " + prodotto.Nome);
                Console.WriteLine("Costo: " + prodotto.Costo);
                Console.WriteLine("Disponibilità: " + prodotto.Disponibilita);
                Console.WriteLine();
            }

            int prodottoSelezionato = 0;
            bool productIdIsValid = false;
            while (productIdIsValid == false)
            {
                bool successfulParse = int.TryParse(Console.ReadLine(), out int result);

                if (result > 0 && result <= ListaProdotti.Count && successfulParse == true)
                {
                    prodottoSelezionato = result;
                    productIdIsValid = true;
                }
                else
                {
                    Console.WriteLine("Devi inserire un ID prodotto valido! Riprova:");
                }
            }
            return prodottoSelezionato;
        }
    }
}
