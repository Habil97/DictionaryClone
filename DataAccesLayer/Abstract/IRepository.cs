using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    //Genel repository arayüzü
   public interface IRepository<T>
    {
        //Listeleme işlemi
        List<T> List();

        //Ekleme işlemi
        void Insert(T p);

        //Şartlı Listeleme
        T Get(Expression<Func<T, bool>> filter);

        //Silme işlemi
        void Delete(T p);

        //Güncelleme işlemi
        void Update(T p);

        //Şartlı Listeleme İşlemi
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
