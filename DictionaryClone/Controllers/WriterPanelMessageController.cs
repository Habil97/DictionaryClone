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
    public class WriterPanelMessageController : Controller
    {

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterLoginDal());

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagevaluein = messageManager.GetListInbox(p);
            return View(messagevaluein);
        }
         
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
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

        public PartialViewResult WriterPanelMessageListMenu()
        {
            return PartialView();
        }
    }
}