using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterUser).NotEmpty().WithMessage("Yazar adı boş olamaz!");
            RuleFor(x => x.WriterUser).MinimumLength(2).WithMessage("Yazar adı en az 2 karakter olmalıdır!");
            RuleFor(x => x.WriterUser).MaximumLength(50).WithMessage("Yazar adı en fazla 50 karakter olmalıdır!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar maili boş olamaz!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar unvanı boş olamaz!");
            RuleFor(x => x.WriterMail).MinimumLength(3).WithMessage("Yazar unvanı en az 3 karakter olmalıdır!");
            RuleFor(x => x.WriterAdress).NotEmpty().WithMessage("Yazar adresi boş olamaz!");
            RuleFor(x => x.WriterAdress).MinimumLength(10).WithMessage("Yazar adresi en az 10 karakter olmalıdır!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında kısmı boş olamaz!");
            RuleFor(x => x.WriterAbout).MinimumLength(10).WithMessage("Yazar hakkında kısmı en az 10 karakter olmalıdır!");
        }
    }
}
