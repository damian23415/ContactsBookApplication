using ContactsBookApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsBookApp.DAL.Interfaces
{
    public interface IContactDAL
    {
        public Task<ContactDTO> CreateContact(ContactDTO model);
        public Task<ContactDTO> EditContact(int contactId, ContactDTO model);
        public Task<List<ContactDTO>> GetAllContacts();
        public Task<List<ContactDTO>> Filter(string searchString);
        public Task<ContactDTO> GetOneContact(int id);
    }
}
