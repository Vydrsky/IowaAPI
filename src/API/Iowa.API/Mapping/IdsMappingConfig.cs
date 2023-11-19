using Iowa.Domain.Account.ValueObjects;
using Iowa.Domain.Game.ValueObjects;
using Iowa.Domain.User.ValueObjects;
using Mapster;

namespace Iowa.API.Mapping; 
public class IdsMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        config.NewConfig<UserId, Guid>()
            .MapWith(src => src.Id);
        config.NewConfig<AccountId, Guid>()
            .MapWith(src => src.Id);
        config.NewConfig<GameId, Guid>()
            .MapWith(src => src.Id);
    }
}
