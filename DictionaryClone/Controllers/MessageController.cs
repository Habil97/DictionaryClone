using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace DictionaryClone.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageValidator messageValidator = new MessageValidator();


        public ActionResult MessageReport()
        {
            var messagevalue = messageManager.GetList();
            return View(messagevalue);
        }


        //Gelen Mesajlar
        public ActionResult Inbox(string p)
        {
            var messagevaluein = messageManager.GetListInbox(p);
            return View(messagevaluein);
        }
        //Gönderilen Mesajlar
        public ActionResult Sendbox(string p)
        {
            var messagevaluesend = messageManager.GetListSendbox(p);
            return View(messagevaluesend);
        }

        public ActionResult SendboxMessageDetails(int id)
        {
            var value = messageManager.GetByID(id);
            return View(value);
        }

        public ActionResult InboxMessageDetails(int id)
        {
            var value = messageManager.GetByID(id);
            return View(value);
        }
  
        //Yeni Mesaj Oluşturma İşlemi
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

    }
}