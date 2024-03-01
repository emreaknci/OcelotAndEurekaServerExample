using Contact.Infrastracture;
using Contact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Services
{
    public class ContactService : IContactService
    {
        public ContactDTO GetContactById(int id)
        {
            return new ContactDTO
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
            };
        }

        public List<ContactDTO> GetContacts()
        {
            return new List<ContactDTO>
            {
                new ContactDTO
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                },
                new ContactDTO
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                },
                new ContactDTO
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Smith",
                },
                new ContactDTO
                {
                    Id = 4,
                    FirstName = "Jonathan",
                    LastName = "Smith",
                },
                new ContactDTO
                {
                    Id = 5,
                    FirstName = "John",
                    LastName = "Johnson",
                },
            };
        }
    }
}
