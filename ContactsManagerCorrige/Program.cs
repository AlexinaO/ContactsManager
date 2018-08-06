using System;
using System.Collections.Generic;
using ContactsManagerCorrige;

namespace ContactsManager
{
    class Program
    {
        static List<Contact> contacts = new List<Contact>();

        static void Main(string[] args)
        {
            bool continuer = true;
            while (continuer)
            {
                var choix = AfficherMenu();
                switch (choix)
                {
                    case "1":
                        ListerContacts();
                        break;
                    case "2":
                        AjouterContact();
                        break;
                    case "3":
                        SupprimerContact();
                        break;
                    case "4":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide, l'application va fermer...");
                        continuer = false;
                        break;
                }
            }
        }
        /// <summary>
        /// Affiche le menu
        /// </summary>
        /// <returns>Retourne le choix de l'utilisateur</returns>
        static string AfficherMenu()
        {
            //bool continuerExecution = true;
            Console.Clear();

            Console.WriteLine("MENU\n");
            Console.WriteLine("1. Liste des contacts");
            Console.WriteLine("2. Ajout d’un contact");
            Console.WriteLine("3. Suppression d’un contact");
            Console.WriteLine("4. Quitter");
            Console.Write("\nVotre choix: ");

            return Console.ReadLine();
        }

        static void ListerContacts()
        {
            Console.Clear();
            Console.WriteLine("LISTE DES CONTACTS\n");

            Console.Write("{0,-20}|", "Nom");
            Console.Write("{0,-15}|", "Prenom");
            Console.Write("{0,-30}|", "Email");
            Console.Write("{0,-15}|", "Telephone");
            Console.Write("{0,-15}|", "Date Naissance");
            Console.WriteLine();
            Console.WriteLine(new string('_',100));
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var contact in contacts)
            {
                Console.Write("{0,-20}|",contact.Nom);
                Console.Write("{0,-15}|",contact.Prenom);
                Console.Write("{0,-30}|",contact.Email);
                Console.Write("{0,-15}|",contact.Telephone);
                Console.Write("{0,-15}|",contact.date?.ToShortDateString());
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine("\nAppuiez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        static void AjouterContact()
        {
            Console.Clear();
            Console.WriteLine("AJOUT D'UN CONTACT\n");
            var contact = new Contact();

            contact.Nom=OutilsConsole.SaisirChaineObligatoire("Entrer le nom du contact:");
            contact.Prenom = OutilsConsole.SaisirChaineObligatoire("Entrer le prénom du contact:");
            
            Console.WriteLine("Entrer l'e-mail du contact:");
            contact.Email=(Console.ReadLine());

            Console.WriteLine("Entrer le numéro de téléphone du contact:");
            contact.Telephone=(Console.ReadLine());

            contact.date=OutilsConsole.SaisirDate("Entrer la date de naissance du contact:");
            //contact.date=DateTime.Parse(Console.ReadLine());

            contacts.Add(contact);
            Console.WriteLine("Contact ajouté !");

            Console.WriteLine("\nAppuiez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        /*static string SaisirChaineObligatoire(string message)
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
        }*/
        static void SupprimerContact()
        {
            Console.Clear();
            Console.WriteLine("SUPPRESSION D'UN CONTACT\n");

            /*Console.Write("{0,-6} | ", "NUMERO");
            Console.Write("{0,-10} | ", "NOM");
            Console.Write("{0,-10} | ", "PRENOM");
            Console.WriteLine();
            Console.WriteLine(new string('_', 35));*/

            /*foreach (var contact in contacts)
             * 
             * 
             * 
             * 
             * 
             * */


            for (var i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"- {contacts[i].ToString()} ({i})"); //on récupère la valeur et on affiche sa position
                }
            /*les lignes for auraient pu être écrites comme suit mais cela prend plus de temps
             * int position=0;
             * foreach(var contact in contacts)
             * {Console.WriteLine($"-{contact}({position}");
             * position++;*/

            Console.Write("Entrez le numéro du contact à supprimer: ");
            var index = int.Parse(Console.ReadLine());

            if (index < contacts.Count)
            {
                contacts.RemoveAt(index);
                Console.WriteLine("Contact supprimé !");
            }
            else
            {
                Console.WriteLine("Numéro invalide !");
            }

            Console.WriteLine("\nAppuie sur une touche pour revenir au menu...");
            Console.ReadKey();
        }
    }
}