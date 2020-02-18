using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2.Repositories
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public static List<AppUser> Users = new List<AppUser>();

        public UserRepository(Models.AppContext appContext) : base(appContext)
        {
            
        }
    }
}
