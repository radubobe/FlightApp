using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{
    public class AppUser :IdentityUser
    {
        //  override public string Id { get; set; }
        // override public string UserName { get; set; }
        ///override public string Email { get; set; }
        //public string NormalizeUserName { get; set; }
        // override public string PasswordHash { get; set; }
        public virtual ICollection<Booking> bookings { get; set; }

    }

}
