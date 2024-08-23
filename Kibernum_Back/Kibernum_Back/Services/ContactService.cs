using Kibernum_Back.DB;
using Kibernum_Back.Interfaces;
using Kibernum_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Kibernum_Back.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;

        public ContactService(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Contact>> GetAllContactsAsync(int userId)
        {
            return await _context.Contacts
                                 .Where(c => c.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int userId, int contactId)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == contactId && c.UserId == userId);
        }

        public async Task<Contact> CreateContactAsync(int userId, ContactRequest contact)
        {

            var cont = new Contact()
            {
                UserId = userId,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                User = null,
            };
            _context.Contacts.Add(cont);
            await _context.SaveChangesAsync();
            return cont;
        }

        public async Task<bool> UpdateContactAsync(int userId, ContactRequest contact)
        {
            var existingContact = await _context.Contacts
                                                .FirstOrDefaultAsync(c => c.Id == contact.Id && c.UserId == userId);

            if (existingContact == null)
            {
                return false;
            }

            existingContact.Name = contact.Name;
            existingContact.PhoneNumber = contact.PhoneNumber;

            _context.Contacts.Update(existingContact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContactAsync(int userId, int contactId)
        {
            var contact = await _context.Contacts
                                        .FirstOrDefaultAsync(c => c.Id == contactId && c.UserId == userId);

            if (contact == null)
            {
                return false;
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
