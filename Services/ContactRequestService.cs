using Crito.Contexts;
using Crito.Models;

namespace Crito.Services
{
    public class ContactRequestService
    {
        private readonly DataContext _context;

        public ContactRequestService(DataContext context)
        {
            _context = context;
        }

        public async Task AddContactRequest(ContactForm contactForm)
        {
            _context.ContactRequests.Add(new ContactRequestEntity
            {
                Name = contactForm.Name,
                Email = contactForm.Email,
                Message = contactForm.Message
            });

            await _context.SaveChangesAsync();
        }
    }
}
