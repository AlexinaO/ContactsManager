using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagerBusiness
{
    public class Contact
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime? date { get; set; }

        /*public void AjouterContact()
        {

        }*/

        public override string ToString()
        {
            return $"{Nom} {Prenom}";
        }

    }
}
