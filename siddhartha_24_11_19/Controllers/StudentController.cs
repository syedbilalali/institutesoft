using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using siddhartha_24_11_19.DAL;
using System.IO;
using siddhartha_24_11_19.Models;
using siddhartha_24_11_19.BAL;
using System.Configuration;
using System.Threading.Tasks;

namespace siddhartha_24_11_19.Controllers
{   
 
    public class StudentController : Controller
    {
        // GET: Student
        StudentOperation so = new StudentOperation();
        CourseOperation co = new CourseOperation();
        dynamic model = new System.Dynamic.ExpandoObject();
        public ActionResult Index()
        {
           

            return View();
        }
        public ActionResult Enquiry() {

            return View();
        }
        [HttpPost]
        public ActionResult Enquiry(Student std) {

            if (ModelState.IsValid) {
                
            }
            return RedirectToAction("Index");
        }
        //[AllowAnonymous]
        //public async Task<JsonResult> ApplicationNoAlreadyExistsAsync(string ApplicationNo)
        //{
        //      var result = await true ??  await false;
        //   // var result = "";
        //    return Json(result == null, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult AddStudent() {

            if (Session["BranchCode"] != null)
            {
                ViewBag.BranchCode = Session["BranchCode"].ToString();
                
            }
            var course = co.getAllCourses().Select(i => new SelectListItem()
            {
                Text = i.CourseName,
                Value = i.CourseName
            });
            ViewData["course"] = course;
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student std) {
            if (ModelState.IsValid)
            {   
                std.BranchCode = Session["BranchCode"].ToString();
                std.StudentPicPath = uploadFile(std.StudentPic);
                std.ThumbofStudentPath = uploadFile(std.ThumbofStudent);
                std.SignofStudentPicPath = uploadFile(std.SignofStudent);
                std.CEOofSignPath = uploadFile(std.CEOofSign);
                so.addStudent(std);
                ViewBag.Message = " Sucessfully Registered !!! ";
            }
            else {
                
            }
            return RedirectToAction("AddStudent");
        }
        public ActionResult UpdateStudent()
        {

            return View();
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student std) {

            return RedirectToAction("UpdateStudent");
        }
        public string uploadFile(HttpPostedFile file) {

            string StudentPicPath = "";
            string UploadPath = "";
            try
            {
                if (file != null)
                {
                    string FileName = Path.GetFileNameWithoutExtension(file.FileName);
                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(file.FileName);

                    //Add Current Date To Attached File Name  
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                    //Get Upload path from Web.Config file AppSettings.  
                   UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                    //Its Create complete path to store in server.  
                    StudentPicPath = UploadPath + FileName;

                    //To copy and save file into server.  
                    file.SaveAs(StudentPicPath);
                }
                else {
                    StudentPicPath = UploadPath + "default.jpg";
                }
            }
            catch (Exception e) {
                Console.WriteLine(" Error in FileUpload : " + e);
            }
            return StudentPicPath;
        }
        [HttpPost]
        public JsonResult IsAlreadyApplication(Student std)
        {
            return Json(IsApplicationAvailable(std.ApplicationNo));
        }
        public bool IsApplicationAvailable(string groupname)
        {
            List<Student> data = so.getAllStudents();
            var gn = (from u in data
                      where u.ApplicationNo.ToUpper() == groupname.ToUpper()
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
        [HttpPost]
        public JsonResult IsAlreadyAadhaar(Student std)
        {
            return Json(IsApplicationAvailable(std.AadhaarCardNo));
        }
        public bool IsAadhaarAvailable(string groupname)
        {
            List<Student> data = so.getAllStudents();
            var gn = (from u in data
                      where u.AadhaarCardNo.ToUpper() == groupname.ToUpper()
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

        public ActionResult StudentList() {

           List<Student> std = so.getAllStudents();
            model.student = std;
           return View( model);
        }
    }
}