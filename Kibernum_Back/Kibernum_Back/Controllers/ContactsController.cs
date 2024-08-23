using Kibernum_Back.Interfaces;
using Kibernum_Back.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kibernum_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController(IContactService contactService) : ControllerBase
    {
        private readonly IContactService _contactService = contactService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var kljkj = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contacts = await _contactService.GetAllContactsAsync(userId);
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contact = await _contactService.GetContactByIdAsync(userId, id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(ContactRequest contact)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var createdContact = await _contactService.CreateContactAsync(userId, contact);
            return CreatedAtAction(nameof(GetContact), new { id = createdContact.Id }, createdContact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactRequest contact)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id != contact.Id)
            {
                return BadRequest("Contact ID mismatch");
            }

            var success = await _contactService.UpdateContactAsync(userId, contact);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var success = await _contactService.DeleteContactAsync(userId, id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
