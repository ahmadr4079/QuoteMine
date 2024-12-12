using Application.Coins.Models;
using Mapster;
using Presentation.Http.Coins.Requests;

namespace Presentation.Helpers.Mapping;

public class MappingPresentation : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CoinQuotesModel, CoinLatestQuotesResponse>()
            .Map(d => d.Symbol, src => src.Symbol)
            .Map(d => d.Quotes, src => src.Quotes);
    }
}