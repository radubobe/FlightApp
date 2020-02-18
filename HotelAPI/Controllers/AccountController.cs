using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ConsoleApp2.Models;
using ConsoleApp2.Repositories;
using HotelAPI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserRepository _appUserRepository;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserRepository appUserRepository)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._appUserRepository = appUserRepository;
        }



        [HttpGet("LogoutUserFromPage")]
        public async Task<IActionResult> LogoutUserFromPage()
        {
            await _signInManager.SignOutAsync();

            // redirect to logout html page
            return RedirectToAction("Logout");
        }


        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    // page for successfull
                    return RedirectToAction("Index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);

        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterVM model)
        {
            
            if (ModelState.IsValid)
            {
                IdentityResult result = null;
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    //page for fail (possible user already exists)
                    return RedirectToAction("RegisterFailed", "account");

                }
                user = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    Email = model.Email
                };

                try
                {
                    result = await _userManager.CreateAsync(user, model.Password);
                }
                catch (Exception ex)
                {
                    //page for something went wrong
                    return RedirectToAction("RegisterFailed", "account");

                }


                if (result.Succeeded)
                {
                    
                    return RedirectToAction("RegisterSuccessful", "account");
                }
               
                foreach (var error in result.Errors)
                {
                     ModelState.AddModelError("", error.Description);
                  
                }
                    
            }

            return View(model);

        }
        [HttpGet("RegisterSuccessful")]
        public IActionResult RegisterSuccessful()
        {
            return View();
        }

        [HttpGet("RegisterFailed")]
        public IActionResult RegisterFailed()
        {
            return View();
        }
    }
}