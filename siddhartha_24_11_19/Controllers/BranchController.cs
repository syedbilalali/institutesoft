using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
using siddhartha_24_11_19.Models;
using siddhartha_24_11_19.BAL;

namespace siddhartha_24_11_19.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        BranchOperation bo = new BranchOperation();
        public ActionResult Index()
        {

            List<Branch> data = bo.getAllBranches();
            ViewData["branch"] = data;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Branch branch) {
            
            if (ModelState.IsValid) {

                string FileName = Path.GetFileNameWithoutExtension(branch.Logo.FileName);

                //To Get File Extension  
                string FileExtension = Path.GetExtension(branch.Logo.FileName);

                //Add Current Date To Attached File Name  
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                //Get Upload path from Web.Config file AppSettings.  
                string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                //Its Create complete path to store in server.  
            
                string fullpath = Server.MapPath(" ") + "\\" + UploadPath + FileName;
                branch.LogoPath = fullpath;
                //To copy and save file into server.  
                branch.Logo.SaveAs(branch.LogoPath);
                bo.addBranch(branch);
            }
            return View();
        }
        [HttpPost]
        public JsonResult IsAlreadyCode(Branch branch)
        {
            return Json(IsCodeAvailable(branch.BranchCode));
        }
        public bool IsCodeAvailable(string groupname)
        {
            List<Branch> data = bo.getAllBranches();
            var gn = (from u in data
                      where u.BranchCode.ToUpper() == groupname.ToUpper()
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
        public ActionResult DeleteBranch(int id)
        {
            try
            {
                bool result = bo.DeleteBranch(id);
                if (result == true)
                {
                    ViewBag.Message = "Customer Deleted Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = "Unsucessfull";
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