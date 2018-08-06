using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagerCorrige
{
    static class OutilsConsole
    {
        static int SaisirEntierObligatoire(string message)
        {
            Console.WriteLine(message);
            var saisie = Console.ReadLine();
            while (int.TryParse(string (saisie)) != true) ;
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ceci n'est pas un entier. Veuillez saisir un entier");
                Console.ResetColor();
                saisie = Console.ReadLine();
            }
            return saisie;

        }

        public static int? SaisirEntier (string message)
        {
            Console.WriteLine(message);
            var saisie = Console.ReadLine();

            
            int entier=0;
            while (!string.IsNullOrEmpty(saisie) //si ce qui a été saisi n'est pas nul
                &&!int.TryParse(saisie, out entier)) // et si cela convertit
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saisie invalide. Recommencez.");
                Console.ResetColor();
                saisie = Console.ReadLine();
            }
            /*if (string.IsNullOrEmpty(saisie))
            {
                return null;
            }
            else
            {
                return entier;
            }*/
            return string.IsNullOrEmpty(saisie)
                ?(int?)null
        }

        static string SaisirChaineObligatoire(string message)
        {
            Console.WriteLine(message);
            var saisie = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(saisie))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Champ requis. Recommence:");
                Console.ResetColor();
                saisie = Console.ReadLine();
            }
            return saisie;
        }

        
}
