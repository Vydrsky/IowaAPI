﻿using Iowa.Domain.Common.Models;

namespace Iowa.Domain.GameAggregate.Events;

public record GameEnded(GameAggregate Game) : IDomainEvent;