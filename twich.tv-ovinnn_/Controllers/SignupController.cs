using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twich.tv_ovinnn_.Data;
using twich.tv_ovinnn_.Models;

namespace twich.tv_ovinnn_.Controllers
{
    public class SignupController : Controller
    {
        private readonly DataContext _db;

        public SignupController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Signup signup)
        {
            // Проверка модели и совпадения паролей
            if (!ModelState.IsValid || signup.Password != signup.ConfirmPassword)
                return Redirect("/Signin");

            // Проверка есьт ли пользователь с таким именем
            bool userExists = await _db.Users.AnyAsync(u => u.Username == signup.Username);
            if (userExists)
                return Redirect("/Signin");

            // Создание нового юзера
            var user = new User
            {
                Username = signup.Username,
                Password = signup.Password, 
                IsAdmin = false
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Redirect("/User");
        }
    }
}
