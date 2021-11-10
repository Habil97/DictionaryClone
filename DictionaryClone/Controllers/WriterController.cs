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
    public class WriterController : Controller
    {
        WriterValidator writerValidator = new WriterValidator();
        WriterManager writermanager = new WriterManager(new EfWriterDal());

        [Authorize]
        public ActionResult Index()
        {
            var writervalue = writermanager.GetList();
            return View(writervalue);
        }
  
        //Yazar Ekleme İşlemi
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }
   
        [HttpPost]
        public ActionResult WriterAdd(Writer p)
        {
            //Yazar Ekleme ve Doğrulama İşlemleri
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                writermanager.WriterAdd(p);
                return RedirectToAction("Index");
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
   
        //Yazar Güncelleme İşlemi
        [HttpGet]
        public ActionResult WriterUpdate(int id)
        {
            var writervalue = writermanager.GetByID(id);
            return View(writervalue);
        }
 
        [HttpPost]
        public ActionResult WriterUpdate(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                writermanager.WriterUpdate(p);
                return RedirectToAction("Index");
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