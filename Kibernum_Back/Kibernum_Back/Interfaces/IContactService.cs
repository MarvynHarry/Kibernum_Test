using Kibernum_Back.Models;

namespace Kibernum_Back.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync(int userId);
        Task<Contact> GetContactByIdAsync(int userId, int contactId);
        Task<Contact> CreateContactAsync(int userId, ContactRequest contact);
        Task<bool> UpdateContactAsync(int userId, ContactRequest contact);
        Task<bool> DeleteContactAsync(int userId, int contactId);
    }
}
