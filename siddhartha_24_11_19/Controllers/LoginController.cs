using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using siddhartha_24_11_19.BAL;
using siddhartha_24_11_19.Models;

namespace siddhartha_24_11_19.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        BranchOperation bo = new BranchOperation();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login log) {
            if (ModelState.IsValid)
            {
                string Email = log.EmailAddress;
                string BranchCode = log.BranchCode;
                string Password = log.Password;
                bool isValid = bo.Login(Email, Password , BranchCode);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(Email, true);
                    
                    Session["EmailAddress"] = Email;
                    Session["Password"] = Password;
                    Session["BranchCode"] = BranchCode;

                    return RedirectToAction("Index", "Home");
                }
                else {
                    ViewBag.Message = " Authentication Failed !!! ";
                }

            }
           
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}