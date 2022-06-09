using BackEnd_1.ProniaProject.ViewModels;
using BackEnd_1.Task.Models;
using BackEnd_1.Task.Utilities;
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
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            return RedirectToAction("Index", "Home");
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




            if (register.Condition == true)
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

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null) return NotFound();

            EditVM edit = new EditVM
            {
                FirstName = user.FirstName,
                LastName= user.LastName,
                Username = user.UserName,
                Email = user.Email

            };
            return View(edit);
        }

        //public async Task CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Member.ToString() });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Admin.ToString() });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = Roles.SuperAdmin.ToString() });


        //}
    }
}
