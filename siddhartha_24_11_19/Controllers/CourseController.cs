using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using siddhartha_24_11_19.Models;
using siddhartha_24_11_19.BAL;

namespace siddhartha_24_11_19.Controllers
{   
   
    public class CourseController : Controller
    {
        // GET: Course
        CourseOperation co = new CourseOperation();
        public ActionResult Index()
        {
            List<Course> courses = co.getAllCourses();
            if (courses.Count > 0)
            {
                ViewData["course"] = courses;
            }
            else {
                ViewData["course"] = null;  
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult addCourses(Course course) {

            int a =  co.addCourse(course);
            if (a > 0)
            {
                ViewBag.Message = "Successfully Add Course.";
            }
            else {
                ViewBag.Message = " Something went wrong while adding course. ";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult IsAlreadyCourse(Course course)
        {
            return Json(IsCourseAvailable(course.CourseName));
        }
        public bool IsCourseAvailable(string groupname)
        {
            List<Course> data = co.getAllCourses();
            var gn = (from u in data
                      where u.CourseName.ToUpper() == groupname.ToUpper()
                      select new { groupname }).FirstOrDefault();
            bool status;
            if (gn != null)
            {
                status = false;
            }
            else
            {
                status = true;
            }
            return status;
        }
        public ActionResult DeleteCourse(int id)
        {
            try
            {
                bool result = co.deleteCourse( new Course() {  Id = id });
                if (result == true)
                {
                    ViewBag.Message = "Course Deleted Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = "Something went wrong !!! ";
                    ModelState.Clear();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }
    }
}