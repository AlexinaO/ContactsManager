using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.DAL
{
    public class DonneesContact
    {
        const string CheminFichier = "Contacts.txt";
        const char SeparateurChampx = ';';
        private List<Contact> contacts;

        public List<Contact>GetContacts()
        {
            if (this.contacts==null)
            {
                LireFichier();
            }
            return this.C
        }

    }
}
