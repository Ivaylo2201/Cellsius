using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class Matrix
{
    public int Id { get; init; }
    public required MatrixType MatrixType { get; init; }
}