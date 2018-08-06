using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagerCorrige
{
    public static class OutilsConsole
    {
        public static int SaisirEntierObligatoire(string message)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();


            int entier = 0;
            while (string.IsNullOrEmpty(saisie) //si ce qui a été saisi n'est pas nul
                || !int.TryParse(saisie, out entier)) // ou si cela ne convertit pas
            {

                var messageErreur = string.IsNullOrEmpty(saisie)
                    ? "Champ obligatoire. Recommencez:"
                    : "Saisie invalide. Recommencez:";
                AfficherMessageErreur(messageErreur);
                saisie = Console.ReadLine();
            }
            return entier;

        }

        public static int? SaisirEntier(string message)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();


            int entier = 0;
            while (!string.IsNullOrEmpty(saisie) //si ce qui a été saisi n'est pas nul
                && !int.TryParse(saisie, out entier)) // et si cela convertit
            {
                AfficherMessageErreur("Saisie invalide. Recommencez.");
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
                ? (int?)null
                : entier;
        }

        public static string SaisirChaineObligatoire(string message)
        {
            Console.WriteLine(message);
            var saisie = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(saisie))
            {
                AfficherMessageErreur("Champ requis. Recommencez:");
                saisie = Console.ReadLine();
            }
            return saisie;
        }

        public static void AfficherMessageErreur(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static DateTime? SaisirDate (string message)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();


            DateTime date = default(DateTime);
            while (!string.IsNullOrEmpty(saisie) //si ce qui a été saisi n'est pas nul
                && !DateTime.TryParse(saisie, out date)) // et si cela convertit
            {
                AfficherMessageErreur("Saisie invalide. Recommencez:");
                saisie = Console.ReadLine();
            }
            return string.IsNullOrEmpty(saisie)
                ? (DateTime?)null
                : date;


        }
        public static DateTime SaisirDateObligatoire(string message)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();


            DateTime date;
            while (string.IsNullOrEmpty(saisie) //si ce qui a été saisi n'est pas nul
                || !DateTime.TryParse(saisie, out date)) // et si cela convertit
            {

                var messageErreur = string.IsNullOrEmpty(saisie)
                    ? "Champ obligatoire. Recommencez:"
                    : "Saisie invalide. Recommencez:";
                AfficherMessageErreur(messageErreur);
                saisie = Console.ReadLine();
            }
            return date;

        }
    }
}
