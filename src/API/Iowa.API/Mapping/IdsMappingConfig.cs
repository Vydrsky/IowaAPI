using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;
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
