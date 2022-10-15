using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.Models
{
    public class forgetpasswordVM
    {
        [Required(ErrorMessage ="It is Required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
