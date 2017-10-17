using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgSequentielle
{
    class Program
    {
        static void Main(string[] args)
        {
            string saisie;
            Console.WriteLine("Entrez une valeur");
            saisie = Console.ReadLine();
            int valeur = Convert.ToInt32(saisie);
            int carre = valeur * valeur;
            // ...
            Console.ReadKey();
        }
    }
}
