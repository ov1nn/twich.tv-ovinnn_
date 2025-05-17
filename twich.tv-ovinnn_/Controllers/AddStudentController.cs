using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using twich.tv_ovinnn_.Data;
using twich.tv_ovinnn_.Models;
using System.Linq;

namespace twich.tv_ovinnn_.Controllers
{
    [Authorize]
    public class AddStudentController : Controller
    {
        private readonly DataContext db;

        public AddStudentController(DataContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Groups = db.Groups.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentModel studentM)
        {
            if (db.Students.Any(s => s.Username == studentM.Username && s.Surname == studentM.Surname))
            {
                return View();
            }

            var student = new Student
            {
                Username = studentM.Username,
                Surname = studentM.Surname,
                MiddleName = studentM.MiddleName,
                BirthDay = studentM.BirthDay,
                GroupId = studentM.Group
            };

            db.Students.Add(student);
            db.SaveChanges();

            return Redirect("/User");
        }
    }
}
