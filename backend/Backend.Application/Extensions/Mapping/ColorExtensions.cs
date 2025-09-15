using Backend.Application.DTOs.Color;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions.Mapping;

public static class ColorExtensions
{
    public static GetColorDto ToGetColorDto(this Color color)
    {
        return new GetColorDto
        {
            Id = color.Id,
            ColorName = color.ColorName
        };
    }
}