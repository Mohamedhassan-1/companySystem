using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.Models
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage = "It is not valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }       
        public bool RemberMe { get; set; }

    }
}
