using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class ContactController : SurfaceController
    {
        private readonly ContactRequestService _contactRequestService;//NYTT
        public ContactController(/*NYTT*/ContactRequestService contactRequestService,/*NYTT*/ IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _contactRequestService = contactRequestService;//NYTT
        }


        [HttpPost]
        //public async IActionResult Index(ContactForm contactForm)
        public async Task<IActionResult> Index(ContactForm contactForm)//NYTT
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            await _contactRequestService.AddContactRequest(contactForm);//NYTT

            /*
            using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contactform@crito.com", "P@ssw0rd2023");

            mail.SendAsync(contactForm.Email, "Message received", "Thank you for contacting us!").ConfigureAwait(false);
            mail.SendAsync("christian.eriksson2@learnet.se", $"{contactForm.Name} sent a contact request", contactForm.Message).ConfigureAwait(false);
            */


            //return RedirectToCurrentUmbracoPage();
            return LocalRedirect(contactForm.RedirectURL ?? "/");
        }
    }
}
