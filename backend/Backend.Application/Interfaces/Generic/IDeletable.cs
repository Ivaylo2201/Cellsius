using Backend.Domain.Abstractions;

namespace Backend.Application.Interfaces.Generic;

public interface IDeletable<in TIdentifier>
{
    Task<Result<bool>> DeleteAsync(TIdentifier id);
}