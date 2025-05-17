using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using twich.tv_ovinnn_.Data;
using twich.tv_ovinnn_.Models;


namespace twich.tv_ovinnn_.Controllers
{
    public class SigninController : Controller
    {
        private readonly DataContext db;

        public SigninController(DataContext db)
        {
            this.db = db;
        }

        public IActionResult Index() // Signin
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Check(Signin signIn) // Этот метод проверяет данные из формы
        {
            var User = signIn.Username;
            var Pass = signIn.Password;

            User user = await db.Users.FirstOrDefaultAsync(x => x.Username == User && x.Password == Pass);

            if (user != null)
            {
                Claim[] c = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"),
                    new Claim(ClaimTypes.Name, user.Username)
                };
                var identity = new ClaimsIdentity(c, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                if (user.IsAdmin)
                    return RedirectToAction("Index", "Admin");

                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", "Неверный логин или пароль");
            return View("Index", signIn);
        }
    }
}
