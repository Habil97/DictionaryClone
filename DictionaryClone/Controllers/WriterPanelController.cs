using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;

namespace DictionaryClone.Controllers
{
    public class WriterPanelController : Controller
    {

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterLoginDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = writerLoginManager.GetList().Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writervalue = writerManager.GetByID(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
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
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
           var writeridinfo = writerLoginManager.GetList().Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
           var headingvalue = headingManager.GetListByWriter(writeridinfo);
            return View(headingvalue);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.GetListCategory()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string d = (string)Session["WriterMail"];
            var writeridinfo = writerLoginManager.GetList().Where(x => x.WriterMail == d).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.d = writeridinfo;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID =writeridinfo;
            p.HeadingStatus = true;
            headingManager.HeadingAdd(p);
            return RedirectToAction("MyHeading","WriterPanel");
        }

        [HttpGet]
        public ActionResult HeadingUpdate(int id)
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.GetListCategory()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vc = valuecategory;
            var headingvalue = headingManager.GetByID(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult HeadingUpdate(Heading p)
        {
            headingManager.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult HeadingStatusUpdate(int id)
        {
            var headingvalue = headingManager.GetByID(id);
            headingManager.HeadingStatusUpdate(headingvalue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p = 1)
        {
            var headings = headingManager.GetList().ToPagedList(p,3);
            return View(headings);
        }
    }
}