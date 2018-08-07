using System;
using System.Collections.Generic;
using ContactsManagerCorrige;
using System.Linq;
using System.IO;
using System.Text;

namespace ContactsManager
{
    class Program
    {
        static event EventHandler ListeModifiee;

        static List<Contact> contacts = new List<Contact>();

        static void Main(string[] args)
        {
            /*string chaine = "Bonjour";
            IComparable variable1 = chaine;
            IEnumerable<char> variable2 = chaine;
            contacts = GestionDonnees.LireFichier();*/
            ListeModifiee += (sender, EventArgs) =>
             {
                 Console.WriteLine("La liste a été modifiée..." + "Le fichier va être mis à jour");
                 GestionDonnees.EcrireFichier(contacts);
             };

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
                        SousMenuTrierContacts();
                        break;
                    case "5":
                        FiltrerContacts();
                        break;
                    case "Q":
                    case "q":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide, l'application va fermer...");
                        continuer = false;
                        break;
                }
            }
            /*GestionDonnees.EcrireFichier(contacts);*/
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
            Console.WriteLine("4. Trier les contacts");
            Console.WriteLine("5. Filtrer les contacts");
            Console.WriteLine("Q. Quitter");
            Console.Write("\nAppuyez sur le chiffre de votre choix ou sur Q pour quitter: ");

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
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }
        /*{
            Console.Clear();
            Console.WriteLine("LISTE DES CONTACTS\n");

            AfficherListeContacts(contacts);

            RevenirMenuPrincipal();
        }*/

        /*static void AfficherListeContacts(IEnumerable<Contact> listeContacts)
        {
            OutilsConsole.AfficherChamp("NOM", 10);
            OutilsConsole.AfficherChamp("PRENOM", 10);
            OutilsConsole.AfficherChamp("EMAIL", 20);
            OutilsConsole.AfficherChamp("TELEPHONE", 10);
            OutilsConsole.AfficherChamp("DATE NAISSANCE", 10);
            Console.WriteLine();
            Console.WriteLine(new string('-', 75));

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var contact in listeContacts)
            {
                OutilsConsole.AfficherChamp(contact.Nom, 10);
                OutilsConsole.AfficherChamp(contact.Prenom, 10);
                OutilsConsole.AfficherChamp(contact.Email, 20);
                OutilsConsole.AfficherChamp(contact.Telephone, 10);
                OutilsConsole.AfficherChamp(contact.DateNaissance?.ToShortDateString(), 10);
                Console.WriteLine();
            }
            Console.ResetColor();
        }*/

        static void AjouterContact()
        {
            Console.Clear();
            Console.WriteLine("AJOUT D'UN CONTACT\n");
           var contact = new Contact();
           /* var fichierContacts = "FichierContacts.txt";
            if (File.Exists(fichierContacts))
            {
                IEnumerable<string> lignesFichier = File.ReadLines(fichierContacts);
                var contactsDansFichier = new List<Contact>();
                foreach (var ligneFichier in lignesFichier)
                {
                    string[] champs = ligneFichier.Split(';');
                    var contact2 = new Contact();
                    contact2.Nom = champs[0];
                    contact2.Prenom = champs[1];
                    contact2.Email = champs[2];
                    contact2.Telephone = champs[3];
                    contact2.date = string.IsNullOrEmpty(champs[4])
                                                ? (DateTime?)null
                                                : DateTime.Parse(champs[4]);
                    contactsDansFichier.Add(contact);
                }
            }
            else
            {
                var contenuFichier = new StringBuilder();
                foreach (var contact2 in contacts)
                {
                    contenuFichier.AppendLine(string.Join(";", contact2.Nom, contact2.Prenom, contact2.Email, contact2.Telephone,contact2.date));
                    File.WriteAllText(fichierContacts, contenuFichier.ToString());

                }

            }
                Console.ReadKey();*/

            

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
            OnListeModifiee();

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

       
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
                OnListeModifiee();
            }
            else
            {
                Console.WriteLine("Numéro invalide !");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();

        }
        public static void SousMenuTrierContacts()
        {
            Console.Clear();
            Console.WriteLine("TRI DES CONTACTS\n");
            Console.WriteLine("Comment voulez-vous trier les contacts:");
            Console.WriteLine("1. par nom");
            Console.WriteLine("2. par prénom");
            Console.WriteLine("Faites votre choix ou Appuyez sur M pour revenir au menu principal:");

            
            var choix2 = Console.ReadLine();
            switch (choix2)
            {
                case "1":
                    TrierContactsNom();
                    break;
                case "2":
                    TrierContactsPrenom();
                    break;
                case "M":
                case " m":
                    AfficherMenu();
                    break;
                default:
                    Console.WriteLine("Mauvaise touche. Veuillez faire votre choix");
                    break;
            }
        }
        public static void TrierContactsNom()
        {
            Console.Clear();
            Console.WriteLine("LISTE DES CONTACTS PAR NOM\n");
            var triNom = from contact in contacts
                          orderby contact.Nom ascending
                          select contact;
            foreach (var resultat in triNom)
            {
                Console.WriteLine(resultat);
            }
            RevenirMenuPrincipal();
        }

        public static void TrierContactsPrenom()
        {
            Console.Clear();
            Console.WriteLine("LISTE DES CONTACTS PAR PRENOM\n");
            var triPrenom = from contact in contacts
                         orderby contact.Prenom ascending
                         select contact;
            foreach (var resultat in triPrenom)
            {
                Console.WriteLine(resultat);
            }
            RevenirMenuPrincipal();
            

        }
        
        public static void RevenirMenuPrincipal()
        {
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal");
            Console.ReadKey();
        }
        
        public static void FiltrerContacts()
        {
            Console.Clear();
            Console.WriteLine("FILTRER LES CONTACTS");
            Console.WriteLine("Saisissez les premières lettres du contact à rechercher");
            string recherche = Console.ReadLine();
            var filtreContact = from contact in contacts
                          where contact.Nom.StartsWith(recherche,StringComparison.OrdinalIgnoreCase) || contact.Prenom.StartsWith(recherche, StringComparison.OrdinalIgnoreCase)
                          select contact;
            foreach(var resultat in filtreContact)
            {
                Console.WriteLine(resultat);
            }


            RevenirMenuPrincipal();
        }
        static void OnListeModifiee()
        {
            var handler = ListeModifieeEventArgs;
            if (handler !=null)
            {
                handler(null, new ListeModifieeEventArgs(raison))
            }
        }
        


         

            
     public class ListeModifieeEventArgs:EventArgs
        {
            ListeModifieeEventArgs (RaisonListeModifiee raison)
            {

            }
        }
    }
}