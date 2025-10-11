using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class Os
{
    public int Id { get; init; }
    public required OsName OsName { get; init; }
}