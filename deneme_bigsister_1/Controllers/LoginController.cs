using BigSister.Core.Models;
using deneme_bigsister_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace deneme_bigsister_1.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInVM user)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.userName, user.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Anasayfa", "Admin");
                }
                else
                {
                    return RedirectToAction("Index","Login");
                }
            }
            
            return View();
        }
    }
}
