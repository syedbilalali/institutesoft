using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace siddhartha_24_11_19.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Course Name is required. ")]
        [Remote("IsAlreadyCourse", "Course", HttpMethod = "POST", ErrorMessage = "Course already exists.")]
        public string CourseName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}