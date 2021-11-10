using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DictionaryClone.Controllers
{
    public class ShowCaseController : Controller
    {
       [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}