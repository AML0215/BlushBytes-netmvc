using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netmvc.Data;    // namespace for DbContext (ContactFormDbContext)
using netmvc.Models;  // namespace for your model (ContactForm)

namespace netmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContactFormDbContext _context; // Inject DbContext to interact with the database

        public HomeController(ILogger<HomeController> logger, ContactFormDbContext context)
        {
            _logger = logger;
            _context = context;  // Set up the DbContext to be used in the controller
        }

        // Display the home page
        public IActionResult Index()
        {
            return View();
        }

        // Display the contact form page
        public IActionResult Contact()
        {
            return View();
        }

        // Handle form submission and save data to the database
        [HttpPost]
        public IActionResult Contact(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                // Save the form data into the database
                _context.ContactForms.Add(contactForm);
                _context.SaveChanges();

                // Redirect to the submissions page after the form is submitted
                return RedirectToAction("Submissions");
            }
            return View(contactForm);
        }

        // Display the submissions page
        public IActionResult Submissions(string searchName = "")
        {
            // Fetch all submissions or filter by name if provided
            var submissions = string.IsNullOrEmpty(searchName)
                ? _context.ContactForms.ToList()  // fetch all submissions
                : _context.ContactForms
                    .Where(c => c.Name.Contains(searchName))  // filter by name
                    .ToList();

            return View(submissions);  // Pass the submissions to the view
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
