using Backend.Application.DTOs.Shipping;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions.Mapping;

public static class ShippingExtensions
{
    public static GetShippingDto ToGetShippingDto(this Shipping shipping)
    {
        return new GetShippingDto
        {
            Type = shipping.Type,
            Cost = shipping.Cost,
            Days = shipping.Days
        };
    }
}