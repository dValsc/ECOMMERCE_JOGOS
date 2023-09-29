using ecommercejogos.Model;
using FluentValidation;

namespace ecommercejogos.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(500);

            RuleFor(p => p.Console)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(p => p.DataLancamento)
                .NotEmpty();

            RuleFor(p => p.Preco)
                .NotEmpty();

            RuleFor(p => p.foto)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(500);
        }
    }
}

