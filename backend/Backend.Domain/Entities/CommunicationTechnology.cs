using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class CommunicationTechnology
{
    public int Id { get; init; }
    public required CommunicationTechnologyType CommunicationTechnologyType { get; init; }
}