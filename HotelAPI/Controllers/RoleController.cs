using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp2.Models;
using ConsoleApp2.Repositories;
using HotelAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _appUserRepository;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IUserRepository appUserRepository)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._appUserRepository = appUserRepository;
        }

        [HttpGet("CreateRole")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost("CreateRolePost")]
        public async Task<IActionResult> CreateRolePost([FromForm]RoleVM model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet("ListRoles")]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("index", "home");
                else
                    Errors(result);
            }
            else
            {
                ModelState.AddModelError("", "No role found");
            }
            return View("ListRoles", _roleManager.Roles);
        }

        [HttpGet("AddUserRoleMenu")]
        public async Task<IActionResult> AddUserRoleMenuAsync(string roleId)
        {
            UsersInRole usersInRole = new UsersInRole();
            usersInRole.Users = new List<AppUser>();
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);
            var result = _appUserRepository.GetAllAsync();
            var users = result.Result;

            // get all users not in role
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name) == false)
                {
                    usersInRole.Users.Add(user);
                }
            }

            usersInRole.RoleId = role.Id;


            return View(usersInRole);
        }


        [HttpPost("AddUserRoleMenu")]
        public async Task<IActionResult> AddUserRole(string roleId, string userId)
        {
            var result = _userManager.FindByIdAsync(userId);
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);

            await _userManager.AddToRoleAsync(result.Result, role.Name);

            return RedirectToAction("index", "home");

        }

        [HttpGet("RemoveUserRoleMenu")]
        public async Task<IActionResult> RemoveUserRoleMenu(string roleId)
        {
            UsersInRole usersInRole = new UsersInRole();
            usersInRole.Users = new List<AppUser>();
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);
            var result = _appUserRepository.GetAllAsync();
            var users = result.Result;

            // get all users in this role
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name) == true)
                {
                    usersInRole.Users.Add(user);
                }
            }

            usersInRole.RoleId = role.Id;


            return View(usersInRole);
        }

        [HttpPost("RemoveUserRoleMenu")]
        public async Task<IActionResult> RemoveUserRoleMenuPost(string roleId, string userId)
        {
            var result = _userManager.FindByIdAsync(userId);
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);

            await _userManager.RemoveFromRoleAsync(result.Result, role.Name);

            return RedirectToAction("index", "home");

        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}