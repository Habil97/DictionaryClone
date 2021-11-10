﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Başlık Sınıfının Oluşturulması
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }

        public DateTime HeadingDate { get; set; }

        public bool HeadingStatus { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        //Başlık - İçerik İlişkisinin Oluşturulması
        public ICollection<Content> Contents { get; set; }
    }
}