using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPI.DIInterface
{
    interface IContact
    {
        List<Contact> GetContacts();
        bool AddContact(Contact contact);
        bool EditContact(Contact contact);
        bool DeleteContact(int contactId);
    }
}
