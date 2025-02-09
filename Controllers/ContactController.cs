//using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using netmvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace netmvc.Controllers
{
    public class ContactController : Controller
    {
        // In-memory storage for temporary form submissions 
        private static List<ContactForm> _submissions = new List<ContactForm>();

        //display the contact form
        public IActionResult Contact()
        {
            var model = new ContactForm(); // Ensure model is initialized
            return View(model);
        }
        // Handle form submission
        [HttpPost]
        public IActionResult Submit(ContactForm model)
        {
            if (ModelState.IsValid)
            {
                // Add the form data to the list apps
                _submissions.Add(model);

                //return to the submissions page after form submission
                return RedirectToAction("Submissions"); 
            }
            // If the form is invalid, return to the index view with the model data
            return View("Contact", model);
        }

        // Action to display the list of form submissions(Submissions.cshtml)
        public IActionResult Submissions(string searchName)
        {
            // Use case-insensitive search for name filtering
            var submissions = string.IsNullOrEmpty(searchName)
                ? _submissions
                : _submissions.Where(s => s.Name.Contains(searchName, System.StringComparison.OrdinalIgnoreCase)).ToList();

            // Store the search query in ViewData to repopulate the search box in the view
            ViewData["SearchQuery"] = searchName;

            // Return the filtered list of submissions to the view
            return View(submissions);
        }


    }
}