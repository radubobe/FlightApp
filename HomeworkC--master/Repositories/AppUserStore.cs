using ConsoleApp2.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2.Repositories
{
    public class AppUserStore : IUserStore<AppUser>, IUserPasswordStore<AppUser>, IUserRoleStore<AppUser>
    {
        private readonly IUserRepository _appUserRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private Models.AppContext Context;

        public AppUserStore(IUserRepository appUserRepository, Models.AppContext Context, RoleManager<IdentityRole> _roleManager)

        {
            this._appUserRepository = appUserRepository;
            this.Context = Context;
            this._roleManager = _roleManager;
            
        }

        Task IUserRoleStore<AppUser>.AddToRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            var userId = user.Id;
            IdentityRole role = _roleManager.FindByNameAsync(roleName).Result;
            var roleIdResult = _roleManager.GetRoleIdAsync(role);
            IdentityUserRole<string> userRole = new IdentityUserRole<string>
            {
                RoleId = roleIdResult.Result,
                UserId = userId
            };

            Context.UserRoles.Add(userRole);
            Context.SaveChangesAsync();

            return Task.FromResult(IdentityResult.Success);

        }

        public async Task<IdentityResult>  CreateAsync(AppUser user,CancellationToken cancellationToken)
        {
            var _user = new AppUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                NormalizedUserName = user.NormalizedUserName,
                PasswordHash = user.PasswordHash

            };

            UserRepository.Users.Add(_user);

            await _appUserRepository.CreateAsync(_user);
 

            return await Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            var appUser = UserRepository.Users.FirstOrDefault(u => u.Id == user.Id);
            if(appUser!=null)
            { 
                UserRepository.Users.Remove(appUser);
            }
            return Task.FromResult(IdentityResult.Success);
          
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }

        public async Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            //return Task.FromResult(UserRepository.Users.FirstOrDefault(u => u.Id == userId));
            return await await Task.FromResult(_appUserRepository.GetOneByConditionAsync(u => u.Id == userId));

        }

        public async Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await await Task.FromResult(_appUserRepository.GetOneByConditionAsync(u => u.NormalizedUserName == normalizedUserName));
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public async Task<IList<string>> GetRolesAsync(AppUser user, CancellationToken cancellationToken)
        {
            List<string> roles = new List<string>();

            return await Task.FromResult(roles);
        }

        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<IList<AppUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task<bool> IsInRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            var userId = user.Id;
            IdentityRole role = _roleManager.FindByNameAsync(roleName).Result;
            var roleIdResult = _roleManager.GetRoleIdAsync(role);

            string[] userRole = { userId, roleIdResult.Result };
            var result = Context.UserRoles.Find(userRole);


            if (result != null)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);

        }

        public Task RemoveFromRoleAsync(AppUser user, string roleName, CancellationToken cancellationToken)
        {
            IdentityRole role = _roleManager.FindByNameAsync(roleName).Result;

            string[] userRoleKeys = { user.Id, role.Id};
            var result = Context.UserRoles.Find(userRoleKeys);

            if (result != null)
            {
                Context.UserRoles.Remove(result);
                Context.SaveChanges();

            }
            return Task.FromResult(true);
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            var appUser = UserRepository.Users.FirstOrDefault(u => u.Id == user.Id);
            if(appUser !=null)
            {
                appUser.UserName = user.UserName;
                appUser.NormalizedUserName = user.NormalizedUserName;
                appUser.Email = user.Email;
                appUser.PasswordHash = user.PasswordHash;

            }
            return Task.FromResult(IdentityResult.Success);
        }


    }
}
