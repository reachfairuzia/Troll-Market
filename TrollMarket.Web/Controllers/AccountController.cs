using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrollMarket.Provider.Impl;
using TrollMarket.ViewModel.Account;

namespace TrollMarket.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountProvider _accountProvider;

        public AccountController (IAccountProvider accountProvider)
        {
            _accountProvider = accountProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Login")]
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var modal = new LoginViewModel();
            modal.DropdownRoles = _accountProvider.GetDropdownRole();
            return View(modal);
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(string? returnUrl, LoginViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                if (_accountProvider.IsAuthentication(model))
                {
                    var claims = new List<Claim>()
                    {
                        new Claim("username", model.Username),
                        new Claim(ClaimTypes.NameIdentifier, model.Username),
                        new Claim(ClaimTypes.Role, _accountProvider.GetRoleName(model.Username))
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);

                    if (returnUrl == null)
                    {
                            return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //gagal authentication
                    return RedirectToAction("LoginFailed");
                }
            //}
            return View(model);
        }
        [HttpGet]
        public IActionResult LoginFailed()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }


        //[Route("RegistAccountBuyer")]
        [HttpGet]
        public IActionResult RegistAccountBuyer()
        {
            ViewBag.Role = "Buyer";
            return View("RegistAccount");
        }
        
        //[Route("RegistAccountSeller")]
        [HttpGet]
        public IActionResult RegistAccountSeller()
        {
            ViewBag.Role = "Seller";
            return View("RegistAccount");
        }  
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult RegistAccount([FromBody] RegistAccountViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (_accountProvider.RegistrationAccount(model))
                {

                    return Json(new { success = true, message = "Inssert berhasil" });
                }
                else
                {
                    return Json(new { success = false });

                }
            }
            var valMsg = GetValidationViewModels(ModelState);
            return Json(new { success = false, validation = valMsg });
        }

    }
}
