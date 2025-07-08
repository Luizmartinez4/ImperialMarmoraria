using FluentValidation;
using ImperialMarmoraria.Communication.Requests.Orcamento;
using ImperialMarmoraria.Exception;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.Update;
public class UpdateOrcamentoValidator : AbstractValidator<RequestUpdateOrcamentoJson>
{
    public UpdateOrcamentoValidator()
    {
        RuleFor(e => e.Nome).NotEmpty().WithMessage(ResourceErrorMessages.NOME_VAZIO);
        RuleFor(e => e.Celular).NotEmpty().WithMessage(ResourceErrorMessages.CELULAR_VAZIO);
        RuleFor(e => e.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_VAZIO);
        RuleFor(e => e.Descricao).NotEmpty().WithMessage(ResourceErrorMessages.DESCRICAO_VAZIO);
        RuleFor(e => e.Celular).Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$").WithMessage(ResourceErrorMessages.CELULAR_INVALIDO);
        RuleFor(e => e.Email).EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_INVALIDO);
    }
}
