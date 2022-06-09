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

            AppUser user = await _userManager.FindByNameAsync(adminLogin.Username);
             if (user==null) return View();

            if (adminLogin.RememberMe)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, adminLogin.Password, true, true);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Username ve ya Password-nuz yanlisdir");
                    return View();
                }
            }
            else
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, adminLogin.Password, false, true);

                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Sifreni 3 defe yanlis girdiyiniz ucun, 5 deqiqe muddetinde bloklandiniz!");
                        return View();
                    }
                    ModelState.AddModelError("", "Username ve ya Password-nuz yanlisdir");
                    return View();
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
