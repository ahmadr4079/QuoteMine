using Application.Currencies.Models;
using Mapster;
using Presentation.Http.Currencies.Responses;

namespace Presentation.Helpers.Mapping;

public class MappingPresentation : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CurrencyQuotesModel, CurrencyLatestQuotesResponse>()
            .Map(d => d.Symbol, src => src.Symbol)
            .Map(d => d.Quotes, src => src.Quotes);
    }
}