using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccesLayer.EntityFramework;

namespace DictionaryClone.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();

    [Authorize]
        public ActionResult Index()
        {
            var contactvalue = contactManager.GetList();
            return View(contactvalue);
        }
   
        public ActionResult ContactDetails(int id)
        {
            var contactvalue = contactManager.GetByID(id);
            return View(contactvalue);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}