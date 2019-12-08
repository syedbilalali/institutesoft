using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using siddhartha_24_11_19.BAL;
using System.Web.Mvc;

namespace siddhartha_24_11_19.Controllers
{   
   
    public class HomeController : Controller
    {
        BranchOperation bo = new BranchOperation();
        DataTable dt = new DataTable();
        public ActionResult Index()
        {
            if (Session["EmailAddress"] != null && Session["Password"] != null)
            {
                dt = bo.getData(Session["EmailAddress"].ToString(), Session["Password"].ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["DirectorName"] = dt.Rows[0]["DirectorName"].ToString();
                    Session["BranchCode"] = dt.Rows[0]["BranchCode"].ToString();
                    Session["EmailAddress"] = dt.Rows[0]["EmailAddress"].ToString();
                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Profile() {
            return View();
        }
    }
}