using Iowa.Application.Game.Commands.AddNewRoundToGame;
using Iowa.Contracts.Game.Requests;

using Mapster;

namespace Iowa.API.Mapping;

public class GameMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddNewRoundToGameRequest, AddNewRoundToGameCommand>()
            .Map(dest => dest, src => src.Card)
            .TwoWays();
    }
}
