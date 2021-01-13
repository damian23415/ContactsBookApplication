using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsBookApp.DAL.Interfaces;
using ContactsBookApp.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ContactsBookApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactDAL _contactDAL;
        public ContactController(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactDTO model)
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

            await _contactDAL.CreateContact(contact);

            return Ok(contact);
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _contactDAL.GetAllContacts();

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> EditContact(int contactId, ContactDTO model)
        {
            var contact = new ContactDTO()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                City = model.City,
                Zip = model.Zip
            };

            await _contactDAL.EditContact(contactId, contact);

            return Ok(contact);
        }

    }
}
