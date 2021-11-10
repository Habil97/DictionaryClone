using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Yazar Sınıfının Oluşturulması
   public  class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterUser { get; set; }

        [StringLength(500)]
        public string WriterImage { get; set; }

        [StringLength(500)]
        public string WriterAdress { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        [StringLength(1000)]
        public string WriterAbout { get; set; }

        public bool WriterStatus { get; set; }

        [StringLength(50)]
        public string WriterMail { get; set; }

        [StringLength(20)]
        public string WriterPassword { get; set; }

        //Yazar - Başlık İlişkisinin Oluşturulması
        public ICollection<Heading> Headings { get; set; }

        //Yazar - İçerik İlişkisinin Oluşturulması
        public ICollection<Content> Contents { get; set; }
    }
}
