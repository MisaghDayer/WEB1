using ArchiveNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchiveNew.Controllers
{
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(string firstname, string lastname, string username)
        {
            Person person = new Person()
            {
                Name = firstname,
                Family = lastname,
                Username = username,
                Role_ID = 1,
            };

            using (DataContext dataContext = new DataContext())
            {
                dataContext.People.Add(person);
                dataContext.SaveChanges();
            }
            return View();
        }

        public ActionResult EditUsers()
        {
            List<Person> people = new List<Person>();

            using (DataContext data = new DataContext())
            {
                people = data.People.ToList();
            }

            return View(people);
        }

        public ActionResult Activation(int id)
        {

            Person person = new Person();
            using (DataContext data = new DataContext())
            {
                var query =
                    from pep in data.People
                    where pep.User_ID == id
                    select pep;

                // Execute the query, and change the column values
                // you want to change.
                foreach (Person per in query)
                {
                    per.ACTIVE = !per.ACTIVE;
                    // Insert any additional changes to column values.
                }

                // Submit the changes to the database.
                try
                {
                    data.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }

            }

            return RedirectToAction("EditUsers");
        }



        public ActionResult Details(int id)
        {
            Person person = new Person();
            using (DataContext data = new DataContext())
            {
                 person = data.People.Find(id);
            }

            return View(person);
        }

        [HttpPost]
        public ActionResult SaveDetailChanges(string firstname, string lastname, string username, int uid)
        {
            int user_id = uid;

//            firstname = "newName";
            Console.WriteLine(firstname);
            Person person = new Person();
            using (DataContext data = new DataContext())
            {
                var query =
                    from pep in data.People
                    where pep.User_ID == user_id
                    select pep;

                // Execute the query, and change the column values
                // you want to change.
                foreach (Person per in query)
                {
                        per.Name = firstname;
                        per.Family = lastname;
                        per.Username = username;
                    
                    // Insert any additional changes to column values.
                }

                // Submit the changes to the database.
                try
                {
                    data.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }
            }
                return RedirectToAction("EditUsers");
        }

        }

}