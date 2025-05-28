using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactsList.Models;

namespace ContactsList.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository.IContactsRepo _contactsRepo;
        public HomeController(Repository.IContactsRepo contactsRepo)
        {
            _contactsRepo = contactsRepo;
        }
        public IActionResult Index()
        {
            List<ContactsModel> contacts = _contactsRepo
                 .GetAll()
                 .OrderBy(c => c.Name) // Order ascending by Name 
                 .ToList();
            if (contacts == null)
            {
                contacts = new List<ContactsModel>();  // In case the list is null, provide an empty list.
            }
            return View(contacts);
        }

        public IActionResult Add() // This is the method that will be called when the user clicks on the "Add" button
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ContactsModel contacts) // This is the method that will be called when the user submits the form
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactsRepo.Add(contacts);
                    TempData["Success"] = "Contact added successfully!";
                    return RedirectToAction("Index");
                }
                return View(contacts);
            }
            catch (Exception error)
            {
                TempData["Error"] = $"Contact could not be added. \nDetails: {error.Message}";
                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            ContactsModel contact = _contactsRepo.Get(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactsModel contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactsRepo.SaveEdit(contacts);
                    TempData["Success"] = "Changes saved successfully!";
                    return RedirectToAction("Index");
                }
                return View(contacts);
            }
            catch (Exception error)
            {
                TempData["Error"] = $"Changes could not be saved. \nDetails: {error.Message}";
                throw;
            }
        }

        public IActionResult Delete(int id)
        {
            ContactsModel contact = _contactsRepo.Get(id);
            return View(contact);
        }
        public IActionResult DeleteInDb(int id)
        {
            try
            {
                bool isDeleted = _contactsRepo.DeleteInDb(id);
                if (isDeleted)
                {
                    TempData["Success"] = "Contact deleted successfully!";
                }
                else
                {
                    TempData["Error"] = "Contact could not be deleted.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["Error"] = $"Contact could not be deleted. \nDetails: {error.Message}";
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
