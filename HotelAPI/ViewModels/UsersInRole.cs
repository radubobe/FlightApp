using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.ViewModels
{
    public class UsersInRole
    {
    public List<AppUser> Users { get; set; }
    public string RoleId { get; set; }

    }

}
