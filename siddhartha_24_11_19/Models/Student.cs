using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace siddhartha_24_11_19.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please Enter Aadhaar Card No. ")]
        [RegularExpression(@"^\d{4}\d{4}\d{4}$", ErrorMessage = "Invalid Aadhaar Card No.")]
        [Remote("IsAlreadyAadhaar", "Student", HttpMethod = "POST", ErrorMessage = "Aadhaar Card No already exists.")]
        public string AadhaarCardNo { get; set; }

        [Required(ErrorMessage = " Select Date of Joining. ")]
        public DateTime DateofJoining { get; set; }
        public string BranchCode { get; set; }
        [Required(ErrorMessage ="Please Enter Student Name. ")]
        [MaxLength(50)]
        public string StudentName { get; set; }

        [Required(ErrorMessage = " Select the gender. ")]
        public string Gender { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage ="Please Enter Father Name. ")]
        public string FatherName { get; set; }
    
        public string MotherName { get; set; }

        [Required(ErrorMessage ="Date of Birth is required. ")]
        [DateMinimumAge(18, ErrorMessage = "{0} must be someone at least {1} years of age")]
        public DateTime DOB { get; set; }
        public string Nationality { get; set; }
        public string Occupation { get; set;  }
        public string Category { get; set; }
        public string Caste { get; set; }

        [Required(ErrorMessage = "Contact  is required.")]
        [RegularExpression(@"^(0|\+91)?[789]\d{9}$", ErrorMessage = "Invalid Contact No. ")]
        public string ConactNo1 { get; set; }
        [RegularExpression(@"^(0|\+91)?[789]\d{9}$", ErrorMessage = "Invalid Contact No. ")]
        public string ConactNo2 { get; set; }
        [RegularExpression(@"^(0|\+91)?[789]\d{9}$", ErrorMessage = "Invalid Contact No. ")]
        public string ConactNo3 { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Religion { get; set; }
        public string PassingYears { get; set; }
        public string MaritalStatus { get; set; }
        public string Qualification { get; set; }
        public string Marks { get; set; }

        [Required(ErrorMessage ="Select the course ")]
        public string Course { get; set; }

        [Required(ErrorMessage ="Select the batch time.")]
        public string BatchTime { get; set; }
        public string Remarks { get; set; }
        [Required(ErrorMessage =" Registration No. required. ")]
        // [Remote("ApplicationNoAlreadyExistsAsync", "Student", ErrorMessage = "Application is already exists")]
        [Remote("IsAlreadyApplication", "Student", HttpMethod = "POST", ErrorMessage = "Application No.  already exists.")]
        public string ApplicationNo { get; set; }
        public string MonthofExam { get; set; }
        public HttpPostedFile StudentPic { get; set; }
        public string StudentPicPath { get; set; }
        public HttpPostedFile SignofStudent { get; set; }
        public string SignofStudentPicPath { get; set; }
        public HttpPostedFile ThumbofStudent { get; set; }
        public string ThumbofStudentPath { get; set; }
        public HttpPostedFile CEOofSign { get; set; }
        public string CEOofSignPath { get; set; }
        public bool isIssueBag { get; set;  }
        public bool isIssueBooks { get; set;  }
        public bool isIssueICard { get; set;  }

        [Required(ErrorMessage ="Total Fees is required.")]
        public string TotalFees { get; set;  }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set;  }
        
    }
    public class DateMinimumAgeAttribute : ValidationAttribute
    {
        public DateMinimumAgeAttribute(int minimumAge)
        {
            MinimumAge = minimumAge;
            ErrorMessage = "{0} must be someone at least {1} years of age";
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if ((value != null && DateTime.TryParse(value.ToString(), out date)))
            {
                return date.AddYears(MinimumAge) < DateTime.Now;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, MinimumAge);
        }

        public int MinimumAge { get; }
    }

}