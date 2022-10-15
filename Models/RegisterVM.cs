using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.Models
{
    public class RegisterVM
    {
        //[Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="It is not valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }
        [Compare("password", ErrorMessage = "Its not matching")]
        [Required(ErrorMessage = "You Must Confirm Password")]
        public string confirmpassword { get; set; }
    }
}
