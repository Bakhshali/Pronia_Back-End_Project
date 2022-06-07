using BackEnd_1.Task.Models;
using BackEnd_1.Task.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class AccountController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Register(RegisterVM adminRegister)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new AppUser
            {
                FirstName = adminRegister.FirstName,
                LastName = adminRegister.LastName,
                Email = adminRegister.Email,
                UserName = adminRegister.Username
            };


            Microsoft.AspNetCore.Identity.IdentityResult result = await _userManager.CreateAsync(user, adminRegister.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    
                }
                return View();
            }
            return RedirectToAction("Login","Account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]


        public async Task<IActionResult> Login(LoginVM adminLogin)
        {

            return View();
        } 

        
    }
}
