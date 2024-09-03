using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.App_Data;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Read");
            }
            return View(person);
        }

        public ActionResult Update(int id)
        {
            Person person = _context.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        public ActionResult Update(Person person)
        {
            if (ModelState.IsValid)
            {
                var existingPerson = _context.People.Find(person.Id);
                if (existingPerson == null)
                {
                    return HttpNotFound();
                }

                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Email = person.Email;
                existingPerson.Age = person.Age;
                existingPerson.PhoneNumber = person.PhoneNumber;
                existingPerson.City = person.City;

                _context.SaveChanges();
                return RedirectToAction("Read");
            }
            return View(person);
        }

        public ActionResult Delete(int id)
        {
            Person person = _context.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            Person person = _context.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            _context.People.Remove(person);
            _context.SaveChanges();
            return RedirectToAction("Read");
        }

        // GET: /Home/Read
        public ActionResult Read()
        {
            List<Person> persons = _context.People.ToList();
            return View(persons);
        }
    }
}
