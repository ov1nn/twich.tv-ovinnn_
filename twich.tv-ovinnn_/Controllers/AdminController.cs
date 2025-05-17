using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using twich.tv_ovinnn_.Data;

namespace twich.tv_ovinnn_.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly DataContext _db;
        private readonly ILogger<AdminController> _logger;

        public AdminController(DataContext db, ILogger<AdminController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Name = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Users = _db.Users.ToList();
            return View();
        }
    }
}
