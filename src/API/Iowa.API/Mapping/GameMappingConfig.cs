using Iowa.Contracts.Game.Responses;
using Iowa.Domain.GameAggregate;
using Iowa.Domain.GameAggregate.Entities;
using Iowa.Domain.GameAggregate.ValueObjects;

using Mapster;

namespace Iowa.API.Mapping;

public class GameMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<Round, RoundResponse>()
        //    .Map(dest => dest, src => src)
        //    .TwoWays();
        //config.NewConfig<Card, CardResponse>()
        //    .Map(dest => dest, src => src)
        //    .TwoWays();
    }
}
