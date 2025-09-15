using Backend.Application.DTOs.Order;
using Backend.Application.DTOs.Shipping;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions.Mapping;

public static class OrderExtensions
{
    public static GetOrderDto ToGetOrderDto(this Order order)
    {
        return new GetOrderDto
        {
            Id = order.Id,
            Total = order.Total,
            Items = order.Items.Select(item => item.ToGetItemDto()),
            CreatedAt = order.CreatedAt,
            Shipping = new GetShippingDto
            {
                Type = order.Shipping.Type,
                Cost = order.Shipping.Cost,
                Days = order.Shipping.Days
            }
        };
    }
}