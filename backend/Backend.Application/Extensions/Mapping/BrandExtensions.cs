using Backend.Application.DTOs.Brand;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions.Mapping;

public static class BrandExtensions
{
    public static GetBrandDto ToGetBrandDto(this Brand brand)
    {
        return new GetBrandDto
        {
            Id = brand.Id,
            BrandName = brand.BrandName,
            PhonesCount = brand.Phones.Count
        };
    }
}