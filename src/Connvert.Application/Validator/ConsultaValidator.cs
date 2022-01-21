using Connvert.Application.Model;
using FluentValidation;

namespace Connvert.Application.Validator
{
    public class ConsultaValidator : AbstractValidator<ConsultaNoticiasModel>
    {
        public ConsultaValidator()
        {

            When(qc => qc.Titulo != null && qc.Texto != null && qc.Autor != null, () =>
            {
                RuleFor(qc => qc.Titulo)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("Favor informar apenas um campo para consulta na base.");

                RuleFor(qc => qc.Texto)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("Favor informar apenas um campo para consulta na base.");

                RuleFor(qc => qc.Autor)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("Favor informar apenas um campo para consulta na base.");
            });

            When(qc => qc.Titulo != null && qc.Texto != null, () =>
            {
                RuleFor(qc => qc.Titulo)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("Favor informar apenas um campo para consulta na base.");

                RuleFor(qc => qc.Texto)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("Favor informar apenas um campo para consulta na base.");
            });

            When(qc => qc.Titulo != null && qc.Autor != null, () =>
            {
                RuleFor(qc => qc.Titulo)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("Favor informar apenas um campo para consulta na base.");

                RuleFor(qc => qc.Autor)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("Favor informar apenas um campo para consulta na base.");
            });

            When(qc => qc.Texto != null && qc.Autor != null, () =>
            {
                RuleFor(qc => qc.Texto)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("Favor informar apenas um campo para consulta na base.");

                RuleFor(qc => qc.Autor)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("Favor informar apenas um campo para consulta na base.");
            });

        }
    }
}
