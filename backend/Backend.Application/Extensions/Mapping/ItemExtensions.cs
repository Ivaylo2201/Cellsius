using Backend.Application.DTOs.Item;
using Backend.Application.DTOs.Phone;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions.Mapping;

public static class ItemExtensions
{
    public static GetItemDto ToGetItemDto(this Item item)
    {
        return new GetItemDto
        {
            Id = item.Id,
            Quantity = item.Quantity,
            Phone = new GetPhoneShortDto
            {
                Id = item.Phone.Id,
                BrandName = item.Phone.Brand.BrandName,
                ModelName = item.Phone.Model.ModelName,
                ImagePath = item.Phone.ImagePath
            },
            Price = item.Quantity * item.Phone.Price
        };
    }
}