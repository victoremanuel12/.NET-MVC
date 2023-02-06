using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC2022.ViewModel;

namespace MVC2022.Controllers
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
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
            });  
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if(!ModelState.IsValid)
            {
                return View(loginVM);
            }
            //Consulta se o usuário existe
            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if(user != null)
            {
                //Caso exista,realiza o login 
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                //verifica se o login ocorre com sucesso
                if(result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(loginVM.ReturnUrl);
                    }
                }

            }
            ModelState.AddModelError("", "Falha ao realizar Login!");
            return View(loginVM);
        }



        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registroVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registroVM.UserName };
                var result = await _userManager.CreateAsync(user, registroVM.Password);
                if(result.Succeeded)
                {
                    // await _signInManager.SignInAsync(user,isPersistent: false);
                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
                }
            }
            // se não for valido o modelo, entao direciona para View Login
            return View(registroVM);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
