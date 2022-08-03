using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributore
{
    internal class Program
    {
        /*
         * Il distributore
         */

        static void Main(string[] args)
        {
            bool vendita = true;

            // Istanzio la lista prodotti
            List<Prodotto> listaProdotti = new List<Prodotto>();
            listaProdotti.Add(new Bibita("Coca-Cola", 3.40, "1", 10));
            listaProdotti.Add(new Patatine("Patatine San Carlo", 2.00, "2", 12));
            listaProdotti.Add(new Sandwich("Club Sandwich", 3.00, "3", 5));
            listaProdotti.Add(new Acqua("Acqua Valmora", 1.00, "4", 7));

            // Funzione che inserisce un nuovo prodotto

            // Istanzio il distributore
            Distributore distributore = new Distributore(1, listaProdotti);

            // Istanzio l'utente
            List<string> listaProdottiAcquistati = new List<string>();
            Utente utente = new Utente("Mirko", 0, listaProdottiAcquistati);

            Console.WriteLine($"Ciao {utente.Nome}, benvenuto al distributore {distributore.CodiceDistributore}!");
            Console.WriteLine();

            utente.Credito = CheckInputCredito();
            Console.WriteLine();
            Console.WriteLine("Premi un tasto qualsiasi per acquistare!");
            Console.ReadKey();
            Console.Clear();

            
            // Vendita
            while (utente.Credito > 0 && vendita == true)
            {
                bool creditoSufficiente = true;
                while (creditoSufficiente == true)
                {
                    Console.WriteLine("Il tuo credito residuo è " + utente.Credito + " euro");
                    Console.WriteLine();

                    // Selezione del prodotto
                    int prodottoSelezionato = distributore.SelezionaIlProdotto();
                    Console.WriteLine();

                    Console.WriteLine("Hai selezionato " + listaProdotti[prodottoSelezionato - 1].Nome);
                    Console.WriteLine();

                    if (utente.Credito >= listaProdotti[prodottoSelezionato - 1].Costo)
                    {
                        utente.Credito = utente.Credito - listaProdotti[prodottoSelezionato - 1].Costo;
                        creditoSufficiente = true;
                    }
                    else
                    {
                        Console.WriteLine("Il tuo credito non è sufficiente per acquistare il prodotto selezionato.");
                        vendita = ContinuaAcquisto();
                        if (vendita == true)
                        {
                            utente.Credito = InserisciAltroCredito(utente.Credito);
                        }
                        else
                        {
                            creditoSufficiente = false;
                        }
                    }
                    Console.Clear();
                }
            }
            Console.WriteLine("Arrivederci!");

            Console.ReadKey();
        }
        // controlla che il credito inserito sia un numero valido e lo restituisce
        static double CheckInputCredito()
        {
            double result = 0;
            bool isValid = false;

            while (isValid == false)
            {
                Console.WriteLine("Inserisci il credito:");
                string inputUtente = Console.ReadLine();
                bool successfulParse = double.TryParse(inputUtente, out result);
                if (successfulParse == false)
                {
                    Console.WriteLine("Input non valido. Inserire un valore numerico.");
                }
                else
                {
                    isValid = true;
                }
            }
            return result;
        }

        // chiede all'utente se desidera continuare l'acquisto
        static bool ContinuaAcquisto()
        {
            string continua;
            bool vendita = false;
            bool inputIsValid = false;

            while (inputIsValid == false)
            {
                Console.WriteLine("Vuoi continuare ad acquistare? (S/N)");
                continua = Console.ReadLine();
                if (continua == "N" || continua == "n")
                {
                    inputIsValid = true;
                    vendita = false;
                }
                else if (continua == "S" || continua == "s")
                {
                    inputIsValid = true;
                    vendita = true;
                }
                else
                {
                    Console.WriteLine("Input non valido. Inserire \"S\" (SI) oppure \"N\" (NO).");
                }
            }
            return vendita;
        }

        // chiede all'utente se desidera inserire altro credito
        static double InserisciAltroCredito(double creditoResiduo)
        {
            bool inputIsValid = false;
            double credito = 0;

            while (inputIsValid == false)
            {
                string inserisciAltroCredito = "";
                Console.WriteLine("Vuoi inserire altro credito? (S/N)");
                inserisciAltroCredito = Console.ReadLine();
                if (inserisciAltroCredito == "S" || inserisciAltroCredito == "s")
                {
                    inputIsValid = true;
                    credito = creditoResiduo + CheckInputCredito();
                }
                else if (inserisciAltroCredito == "N" || inserisciAltroCredito == "n")
                {
                    inputIsValid = true;
                    credito = creditoResiduo;
                }
                else
                {
                    Console.WriteLine("Input non valido. Inserire \"S\" (SI) oppure \"N\".");
                }

            }


            return credito;
        }

        //static bool CheckCredito(List<Prodotto> listaProdotti, double credito)
        //{
        //    // controlla che il credito sia sufficiente per acquistare almeno un prodotto della lista prodotti

        //    bool isEnough = false;
        //    for (int i = 0; i < listaProdotti.Count; i++)
        //    {
        //        if (credito >= listaProdotti[i].Costo)
        //        {
        //            isEnough = true;
        //        }
        //    }
        //    if (isEnough == false)
        //    {
        //        Console.WriteLine("Il tuo credito non è sufficiente per acquistare nessuno dei prodotti disponibili.");
        //    }

        //    return isEnough;

        //}
    }
}
