using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
   public class ContactValidator :AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Usermail).NotEmpty().WithMessage("Mail adresi boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş olamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapmalısınız");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("En az 3 karakter girişi yapmalısınız");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapmalısınız");
        }
    }
}
