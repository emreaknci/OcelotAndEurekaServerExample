using Contact.Infrastracture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            return Ok(_contactService.GetContactById(id));
        }

        [HttpGet()]
        public IActionResult GetContacts()
        {
            return Ok(_contactService.GetContacts());
        }

    }
}
