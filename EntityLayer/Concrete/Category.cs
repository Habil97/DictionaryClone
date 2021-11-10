using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Kategori Sınıfının Oluşturulması
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

       
        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; }

        //Kategori - Başlık İlişkisinin Oluşturulması
        public ICollection<Heading> Headings { get; set; }

    }
}
