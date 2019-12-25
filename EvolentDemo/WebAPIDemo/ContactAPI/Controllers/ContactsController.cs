using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Data;
using ContactAPI.DIInterface;
using ContactAPI.DIService;

namespace ContactAPI.Controllers
{
    public class ContactsController : ApiController
    {
        //
        // GET: /Contacts/
        IContact objContact = null;

        public ContactsController()
        {
            objContact = new ContactService();
        }
        [HttpGet]
        public HttpResponseMessage GetContacts()
        {
            bool blnresult = false;
            List<Contact> lstContacts = new List<Contact>();
            try
            {
                lstContacts = objContact.GetContacts();
                blnresult = true;
            }
            catch (Exception e)
            {
                blnresult = false;
            }
            if (blnresult)
                return Request.CreateResponse(HttpStatusCode.OK, lstContacts);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, true);
        }

        [HttpPost]
        public HttpResponseMessage AddContact([FromBody]Contact contact)
        {
            bool blnresult = false;
            try
            {
                if (contact != null)
                {
                    blnresult = objContact.AddContact(contact);
                }
            }
            catch (Exception e)
            {
                blnresult = false;
            }
            if (blnresult)
                return Request.CreateResponse(HttpStatusCode.OK, true);
            else
                return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }

        [HttpPut]
        public HttpResponseMessage EditContact([FromBody]Contact contact)
        {
            bool blnresult = false;
            try
            {
                if (contact != null)
                {
                    blnresult = objContact.EditContact(contact);
                }
            }
            catch (Exception e)
            {
                blnresult = false;
            }
            if (blnresult)
                return Request.CreateResponse(HttpStatusCode.OK, true);
            else
                return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteContact(string contactId)
        {
            bool blnresult = false;
            try
            {
                if (!string.IsNullOrEmpty(contactId))
                {
                    int Id = 0;
                    int.TryParse(contactId, out Id);
                    blnresult = objContact.DeleteContact(Id);
                }
            }
            catch (Exception e)
            {
                blnresult = false;
            }
            if (blnresult)
                return Request.CreateResponse(HttpStatusCode.OK, true);
            else
                return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }
    }
}
