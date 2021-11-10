using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminLoginDal _adminlogindal;

        public AdminLoginManager(IAdminLoginDal adminlogindal)
        {
            _adminlogindal = adminlogindal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminlogindal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminlogindal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminlogindal.Update(admin);
        }

        public Admin GetByID(int id)
        {
            return _adminlogindal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _adminlogindal.List();
        }
    }
}
