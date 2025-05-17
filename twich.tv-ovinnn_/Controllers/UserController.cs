using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twich.tv_ovinnn_.Data;
using twich.tv_ovinnn_.Models;

namespace twich.tv_ovinnn_.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly DataContext _db;

        public UserController(DataContext db)
        {
            _db = db;
        }

        // Главная страница пользователя
        public IActionResult Index()
        {
            var students = _db.Students.ToList();
            var groups = _db.Groups.ToList();

            ViewBag.Groups = groups;
            ViewBag.Students = students;

            return View();
        }

        // Создание новой группы
        [HttpPost]
        public IActionResult CreateGroup(GroupModel groupModel)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(groupModel.Name))
                return View();

            // Проверка есть ли уже группа с таким именем
            bool groupExists = _db.Groups.Any(g => g.Name == groupModel.Name);

            if (groupExists)
                return View();

            // Создание и сохранение новой группы
            var group = new Group
            {
                Name = groupModel.Name
            };

            _db.Groups.Add(group);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
