using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace siddhartha_24_11_19.Models
{
    public class Branch
    {

        public int Id { get; set;  }

        [Required(ErrorMessage = " Institute Registration No. required. ")]
        public string InstituteRegNo { get; set;  }

        [Required(ErrorMessage = " Institute Name is required.")]
        [StringLength(100)]
        public string InstittuteName { get; set;  }

        [Required(ErrorMessage = " Director Name is required")]
        public string DirectorName { get; set;  }
        public string AccountantName { get; set;  }
        public string Website { get; set;  }

        [Required(ErrorMessage ="Branch Code is required.")]
        [Remote("IsAlreadyCode", "Branch", HttpMethod = "POST", ErrorMessage = "Branch Code already exists.")]
        public string BranchCode { get; set;  }
        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobileNumber { get; set;  }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set;  }
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set;  }
        public string LogoPath { get; set;  }
        public DateTime CreatedAt { get; set;  }

        public HttpPostedFileBase Logo { get; set;  }
    }
}