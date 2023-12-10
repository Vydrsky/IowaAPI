using Iowa.Domain.AccountAggregate.ValueObjects;
using Iowa.Domain.EvaluationAggregate.ValueObjects;
using Iowa.Domain.GameAggregate.ValueObjects;
using Iowa.Domain.UserAggregate.ValueObjects;

using Mapster;

namespace Iowa.API.Mapping;
public class IdsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserId, Guid>()
            .MapWith(src => src.Value);
        config.NewConfig<AccountId, Guid>()
            .MapWith(src => src.Value);
        config.NewConfig<GameId, Guid>()
            .MapWith(src => src.Value);
        config.NewConfig<RoundId, Guid>()
            .MapWith(src => src.Value);
        config.NewConfig<EvaluationId, Guid>()
            .MapWith(src => src.Value);
        config.NewConfig<AccountId, Guid>()
            .MapWith(src => src.Value);
    }
}
