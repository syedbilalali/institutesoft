using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace siddhartha_24_11_19.Models
{
    public class Login
    {  
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
       public string EmailAddress { get; set;  }

        [Required(ErrorMessage = "Branch is required")]
        public string BranchCode { get; set;  }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set;  }
    }
}