using BackEnd_1.Task.Models;
using BackEnd_1.Task.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd_1.Task.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        

        public AccountController(UserManager <AppUser> userManager, SignInManager <AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
          
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Login(LoginVM login)
        {
            AppUser user = await _userManager.FindByNameAsync(login.Username);

            if (user == null) return View();

            if (login.RememberMe)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Username ve ya Password yanlisdir");
                    return View();
                }
            }

            else
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, false, true);

                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "3 defe sifreni yanlis yazdiginiz ucun 2 deqiqelik bloklandiniz");
                        return View();
                    }
                    ModelState.AddModelError("", "Username ve ya Password yanlisdir");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index" , "Home");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Register(RegisterVM register) 
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new AppUser
            {

                FirstName = register.FirstName,

                LastName = register.LastName,

                Email = register.Email,

                UserName = register.Username
            };

            


            if (register.Condition==true)
            {
                IdentityResult result = await _userManager.CreateAsync(user, register.Password);


                if (!result.Succeeded)
                {
                    foreach (IdentityError eror in result.Errors)
                    {
                        ModelState.AddModelError("", eror.Description);
                    }
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Sozlesmeni qebul etmeden qeydiyyatdan kece bilmersiz");
                return View();
            }

            return RedirectToAction ("Index", "Home");
        }
    }
}
