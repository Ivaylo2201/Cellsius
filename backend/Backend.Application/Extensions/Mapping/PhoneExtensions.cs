using Backend.Application.DTOs.Phone;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions.Mapping;

public static class PhoneExtensions
{
    public static GetPhoneShortDto ToGetPhoneShortDto(this Phone phone)
    {
        return new GetPhoneShortDto
        {
            Id = phone.Id,
            BrandName = phone.Brand.BrandName,
            ModelName = phone.Model.ModelName,
            ImagePath = phone.ImagePath
        };
    }

    public static GetPhoneLongDto ToGetPhoneLongDto(this Phone phone)
    {
        return new GetPhoneLongDto
        {
            Id = phone.Id,
            BrandName = phone.Brand.BrandName,
            ModelName = phone.Model.ModelName,
            ColorName = phone.Color.ColorName,
            DiscountPercentage = phone.DiscountPercentage,
            Price = new PriceDto
            {
                Initial = phone.InitialPrice,
                Discounted = phone.Price,
            },
            Memory = phone.Memory,
            ImagePath = phone.ImagePath
        };
    }
}