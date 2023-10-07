using Microsoft.AspNetCore.Mvc;

namespace deneme_bigsister_1.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Anasayfa()
        {
            return View();
        }
    }
}
