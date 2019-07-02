using Archive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archive.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, string family, int age)
        {
            Person person = new Person() { Name = name, Family = family, Age = age };

            using (DataContext dataContext = new DataContext())
            {
                dataContext.People.Add(person);
                dataContext.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            List<Person> people = new List<Person>();

            using (DataContext data = new DataContext())
            {
                people = data.People.ToList();
            }

            return View(people);
        }
    }
}