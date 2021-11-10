using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        //Constructor Kullanımı
        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        //Ekleme İşlemi
        public void CategoryAdd(Category category)
        {
            _categorydal.Insert(category);
        }

        //Silme İşlemi
        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        //Güncelleme İşlemi
        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        //ID'ye göre getirme işlemi
        public Category GetByID(int id)
        {
            return _categorydal.Get(x => x.CategoryID == id);
        }

        //Listeleme İşlemi
        public List<Category> GetListCategory()
        {
            return _categorydal.List();
        }
    }
}
