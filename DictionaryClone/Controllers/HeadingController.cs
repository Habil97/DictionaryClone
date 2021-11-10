using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DictionaryClone.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager (new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        [Authorize]
        public ActionResult Index()
        {
            var headingvalue = headingManager.GetList();
            return View(headingvalue);
          
        }

        public ActionResult HeadingReport()
        {
            var headingvalue = headingManager.GetList();
            return View(headingvalue);
        }
     
        //Başlık Ekleme İşlemi
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            //DropdownList ile Kategori Verisini Çekme İşlemi
            List<SelectListItem> valuecategory = (from x in categoryManager.GetListCategory()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                 
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in writerManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterUser,
                                                      Value = x.WriterID.ToString()

                                                  }).ToList();
            ViewBag.vc = valuecategory;
            ViewBag.vw = valuewriter;
            return View();
        }
      
        [HttpPost]
        public ActionResult HeadingAdd(Heading p)
        {
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(p);
            return RedirectToAction("Index");
        }

     
        //Başlık Güncelleme İşlemi
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
            return RedirectToAction("Index");
        }
 
        public ActionResult HeadingStatusUpdate(int id)
        {
            var headingvalue = headingManager.GetByID(id);
            headingManager.HeadingStatusUpdate(headingvalue);
            return RedirectToAction("Index");
        }
    }
}