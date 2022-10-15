using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<IdentityUser>userManager,SignInManager<IdentityUser>signInManager,ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
          
            
            if(ModelState.IsValid)
            {
                var data = new IdentityUser() {
                    UserName = registerVM.Email,
                    Email = registerVM.Email               
                };
                var result = await userManager.CreateAsync(data, registerVM.password);
                if (result.Succeeded)
                    return RedirectToAction("Login");
                else
                {
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("", item.Description);
                }
                
            }
            return View(registerVM);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(ModelState.IsValid)
            {
              var result = await signInManager.PasswordSignInAsync(loginVM.Email, loginVM.password, loginVM.RemberMe, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Home", "Home");
                }
                else
                {

                    ModelState.AddModelError("", "Invalid UserName Or Password Attempt");
                }

            }
            return View(loginVM);
        }
        public IActionResult forgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async  Task< IActionResult >forgetPassword(forgetpasswordVM forgetpasswordVM)
        {
            if(ModelState.IsValid)
            {
                var result =  await userManager.FindByEmailAsync(forgetpasswordVM.Email);
                if(result!=null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(result);
                    var link = Url.Action("ResetPassword", "Account", new
                    {
                        Email = forgetpasswordVM.Email,
                        Token = token
                    }, Request.Scheme);

                    logger.Log(LogLevel.Warning, link);
                    return RedirectToAction("confirmforgetPassword");
                }
            }
            return RedirectToAction("confirmforgetPassword");
        }
        public IActionResult confirmforgetPassword()
        {
            return View();
        }
        public IActionResult ResetPassword(string Email,string Token)
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(resetPasswordVM.Email);
                if(user!=null)
                {
                    var result = await userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                   
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(resetPasswordVM);
        }
    }
}
