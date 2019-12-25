using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactAPI.DIInterface;
using System.Data;

namespace ContactAPI.DIService
{
    public class ContactService : IContact
    {
        EvolentHealthDemoEntities db = new EvolentHealthDemoEntities();

        public List<Contact> GetContacts()
        {
            List<Contact> lstContacts = new List<Contact>();
            lstContacts = db.Contacts.Where(x => x.Status != false).ToList();
            return lstContacts;
        }

        public bool AddContact(Contact contact)
        {
            contact.Status = contact.Status != null ? contact.Status : true;
            db.Contacts.Add(contact);
            db.Entry(contact).State = EntityState.Added;
            db.SaveChanges();
            return true;
        }

        public bool EditContact(Contact contact)
        {
            bool blnresult = false;
            var result = db.Contacts.FirstOrDefault(x => x.ContactId == contact.ContactId);
            if (result != null)
            {
                db.Contacts.Attach(contact);
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                blnresult = true;
            }
            return blnresult;
        }

        public bool DeleteContact(int contactId)
        {
            bool blnresult = false;
            Contact contact = db.Contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                contact.Status = false;
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                blnresult = true;
            }
            return blnresult;
        }
    }
}