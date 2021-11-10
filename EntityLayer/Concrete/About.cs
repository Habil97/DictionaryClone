using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Hakkında Sınıfının Oluşturulması
    public class About
    {
        [Key]
        public int AboutID { get; set; }

        [StringLength(500)]
        public string AboutDetails { get; set; }

        [StringLength(100)]
        public string AboutImage { get; set; }
    }
}
