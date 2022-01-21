using Connvert.Application.Model;
using FluentValidation;

namespace Connvert.Application.Validator
{
    public class NoticiaValidator : AbstractValidator<NoticiasModel>
    {
        public NoticiaValidator()
        {

            RuleFor(qc => qc.Titulo)
                          .Cascade(CascadeMode.Stop)
                          .NotEmpty()
                          .WithMessage("Favor informar o Título da Notícia");


            RuleFor(qc => qc.Texto)
                          .Cascade(CascadeMode.Stop)
                          .NotEmpty()
                          .WithMessage("Favor informar o Texto da Notícia");

            RuleFor(qc => qc.Texto)
                          .Cascade(CascadeMode.Stop)
                          .NotEmpty()
                          .WithMessage("Favor informar o Autor da Notícia");

        }
    }
}
