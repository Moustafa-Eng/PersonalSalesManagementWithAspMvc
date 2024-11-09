using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoFix.PL.ViewModels;

namespace MotoFix.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (User is not null)
                {
                    var Flag = await _userManager.CheckPasswordAsync(User, loginViewModel.Password);
                    if (Flag)
                    {
                        var Result = await _signInManager.PasswordSignInAsync(User,loginViewModel.Password, true, false);
                        if (Result.Succeeded)
                            return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Incorrect Email Or Password");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email Is Not Exists");
                }
            }
            return View(loginViewModel);

        }

        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
