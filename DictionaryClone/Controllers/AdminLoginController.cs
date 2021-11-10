using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Security;
using DataAccesLayer.Concrete;

namespace DictionaryClone.Controllers
{
     [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        AdminLoginManager adminloginManager = new AdminLoginManager(new EfAdminLoginDal());
      

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminuserinfo = adminloginManager.GetList().FirstOrDefault(x => x.AdminUsername == p.AdminUsername
            && x.AdminPassword == p.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUsername, false);
                Session["AdminUsername"] = adminuserinfo.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
            public ActionResult LogOut()
            {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "HomePage");
            }
        }
    }
