﻿namespace Iowa.Application.Interfaces.Services; 

public interface IDateTimeProvider {
    DateTime UtcNow { get; }
}