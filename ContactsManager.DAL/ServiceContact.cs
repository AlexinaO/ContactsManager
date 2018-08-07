using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.DAL
{
    class ServiceContact
    {
        public readonly DonneesContact donnees;
        public ServiceContact(DonneesContact donnees)
        {
            this.donnees = donnees;
        }
        public void CreerContact(Contact contact)
        {

        }

        public void SupprimerContact(Contact contact)
        {

        }

        public IEnumerable<Contact>ChercherContacts(string texte)
        {
            return null;
        }
    }
}
