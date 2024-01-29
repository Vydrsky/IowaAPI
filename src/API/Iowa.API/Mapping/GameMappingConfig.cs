using Iowa.Application.Game.Commands.AddNewRoundToGame;
using Iowa.Contracts.Game.Requests;
using Iowa.Contracts.Game.Responses;
using Iowa.Domain.GameAggregate.Entities;

using Mapster;

namespace Iowa.API.Mapping;

public class GameMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddNewRoundToGameRequest, AddNewRoundToGameCommand>()
            .Map(dest => dest, src => src.Card)
            .TwoWays();

        config.NewConfig<Round, RoundResponse>()
            .Map(dest => dest.Type, src => src.CardChosen);
    }
}
