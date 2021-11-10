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
    public class AdminCategoryController : Controller
    {
        //Kategori Sınıfının Çağrılması
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

     [Authorize]
        public ActionResult Index()
        {
            //Kategorilerin Listelenmesi
            var categoryvalue = categoryManager.GetListCategory();
            return View(categoryvalue);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category p)
        {
            //Kategori Ekleme ve Doğrulama İşlemleri
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                categoryManager.CategoryAdd(p);
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
        //Kategori Silme İşlemi
        public ActionResult CategoryDelete(int id)
        {
            var categoryvalue = categoryManager.GetByID(id);
            categoryManager.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }

        //Kategori Güncelleme İşlemi
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var categoryvalue = categoryManager.GetByID(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Category p)
        {
            categoryManager.CategoryUpdate(p);
            return RedirectToAction("Index");

        }
    }
}