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
        public string StudentName { get; set; }

        [Required(ErrorMessage = " Select the gender. ")]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Please Enter Father Name. ")]
        public string FatherName { get; set; }
        [Required(ErrorMessage ="Please Enter Mother Name. ")]
        public string MotherName { get; set; }
        public DateTime DOB { get; set; }
        public string Nationality { get; set; }
        public string Occupation { get; set;  }
        public string Category { get; set; }
        public string Caste { get; set; }

        [Required(ErrorMessage = "Contact  is required.")]
        [RegularExpression(@"^(0|\+91)?[789]\d{9}$", ErrorMessage = "Invalid Contact No. ")]
    public string ConactNo1 { get; set; }
        public string ConactNo2 { get; set; }
        public string ConactNo3 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Religion { get; set; }
        public string PassingYears { get; set; }
        public string MaritalStatus { get; set; }
        public string Qualification { get; set; }
        public string Marks { get; set; }
        public string Course { get; set; }
        public string BatchTime { get; set; }
        public string Remarks { get; set; }
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
        public string TotalFees { get; set;  }
        public string Status { get; set;  }
        
    }

}