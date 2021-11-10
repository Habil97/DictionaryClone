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
   public  class WriterLoginManager : IWriterLoginService
    {
        IWriterLoginDal _writerlogindal;

        public WriterLoginManager(IWriterLoginDal writerlogindal)
        {
            _writerlogindal = writerlogindal;
        }

        public Writer GetByID(int id)
        {
            return _writerlogindal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerlogindal.List();
        }

        public void WrierUpdate(Writer writer)
        {
            _writerlogindal.Update(writer);
        }

        public void WriterAdd(Writer writer)
        {
            _writerlogindal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerlogindal.Delete(writer);
        }
    }
}
