using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.ViewModels
{
    public class RoleVM
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }

    }

}
