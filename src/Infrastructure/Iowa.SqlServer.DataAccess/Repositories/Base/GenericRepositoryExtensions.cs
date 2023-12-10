﻿using Iowa.Application.Common.Exceptions;

namespace Iowa.SqlServer.DataAccess.Repositories.Base;

public static class GenericRepositoryExtensions
{
    public static TAggregate EnsureExists<TAggregate>(this TAggregate? aggregate)
    {
        return aggregate is null ? throw new EntityNotFoundException() : aggregate;
    }
}
