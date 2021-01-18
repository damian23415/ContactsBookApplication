using ContactsBookApp.DAL.Interfaces;
using ContactsBookApp.DTO;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsBookApp.DAL.Implementation
{
    public class ContactDAL : IContactDAL
    {
        private readonly AppDbContext _ctx;

        public ContactDAL(AppDbContext context)
        {
            _ctx = context;
        }

        public async Task<ContactDTO> CreateContact(ContactDTO model)
        {
            using (_ctx)
            {
                var contact = new ContactDTO()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    City = model.City,
                    Zip = model.Zip
                };

                _ctx.Contacts.Add(contact);
                _ctx.SaveChanges();

                return contact;
            }
        }

        public async Task<ContactDTO> EditContact(int contactId, ContactDTO model)
        {
            using(_ctx)
            {
                var result = _ctx.Contacts.FirstOrDefault(x => x.Id == contactId);

                if (result != null)
                {
                    result.FirstName = model.FirstName;
                    result.LastName = model.LastName;
                    result.Email = model.Email;
                    result.PhoneNumber = model.PhoneNumber;
                    result.Address = model.Address;
                    result.City = model.City;
                    result.Zip = model.Zip;

                    _ctx.SaveChanges();
                }
                return model;
            }
        }

        public async Task<List<ContactDTO>> GetAllContacts()
        {
            using(_ctx)
            {
                return await _ctx.Contacts.Select(x => x).ToListAsync();
            }
        }

        public async Task<List<ContactDTO>> Filter(string searchString)
        {
            using(_ctx)
            {
                var contacts = _ctx.Contacts.Where(x => x.Email.Contains(searchString.Trim())).ToListAsync();

                return await contacts;
            }
        }

        public async Task<ContactDTO> GetOneContact(int id)
        {
            using(_ctx)
            {
                var contact = _ctx.Contacts.Where(x => x.Id == id).FirstOrDefault();

                return  contact;
            }
        }

    }
}
