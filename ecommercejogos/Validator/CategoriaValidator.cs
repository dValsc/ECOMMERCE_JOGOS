using ecommercejogos.Model;
using FluentValidation;

namespace ecommercejogos.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Tipo)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(200);
        }
    }
}
