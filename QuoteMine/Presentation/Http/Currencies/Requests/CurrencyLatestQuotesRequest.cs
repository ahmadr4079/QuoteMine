using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Presentation.Http.Currencies.Requests;

public class CurrencyLatestQuotesRequest
{
    [Required] public string Symbol { get; set; }
}

public class CuurrencyLatestQuotesRequestValidator : AbstractValidator<CurrencyLatestQuotesRequest>
{
    public CuurrencyLatestQuotesRequestValidator()
    {
        RuleFor(x => x.Symbol).NotEmpty();
    }
}