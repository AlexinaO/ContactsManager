﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager
{
    class Program
    {
        static List<string> contacts = new List<string>();


        static void Main(string[] args)
        {
            Console.Clear();
            AfficherMenu();
            string choix;
            do
            {
                choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        Console.Clear();
                        ListerContacts();
                        AfficherMenu();
                        break;
                    case "2":
                        Console.Clear();
                        AjouterContacts(contacts);
                        AfficherMenu();
                        break;
                    case "3":
                        Console.Clear();
                        SupprimerContact();
                        AfficherMenu();
                        break;
                    case "4":
                        Console.Clear();
                        Quitter();
                        AfficherMenu();
                        break;
                    default:
                        Console.WriteLine("L'application va fermer");
                        break;
                }
            } while (choix != "4");

            Console.ReadKey();
        }
     
        static void AfficherMenu()
        {
            string[] menu = new string[4] { "1.Liste des contacts", "2.Ajout d'un contact", "3.Suppression d'un contact", "4.Quitter" };
            Console.WriteLine("CONTACTS MANAGER");
            Console.WriteLine("Menu");
            Console.WriteLine(menu[0]);
            Console.WriteLine(menu[1]);
            Console.WriteLine(menu[2]);
            Console.WriteLine(menu[3]);
            Console.WriteLine("\nFaites votre choix:");
       

        }
        static void ListerContacts()
        {
            Console.WriteLine("Voici la liste des contacts");
           
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
        static void AjouterContacts(List<string>contacts)
        {
            Console.WriteLine("Ajout d'un contact");
            Console.WriteLine("Entrez le nom du contact:");
            contacts.Add(Console.ReadLine());
            Console.WriteLine("Entrez le prenom du contact:");
            contacts.Add(Console.ReadLine());
        }
        static void SupprimerContact()
        {
            Console.WriteLine("Supprimer un contact");
            Console.WriteLine("Entrez le nom du contact à supprimer:");
            contacts.Remove(Console.ReadLine());

        }
        /*static void SupprimerContact()
        {
            possible avec un for pour afficher la liste des contacts et permettre un choix de n° de contact

        }*/
        static void Quitter()
        {
            Environment.Exit(0);
        }
       
    }
}
