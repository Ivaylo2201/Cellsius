using Backend.Application.DTOs.Cart;
using Backend.Domain.Entities;

namespace Backend.Application.Extensions.Mapping;

public static class CartExtensions
{
    public static GetCartDto ToGetCartDto(this Cart cart)
    {
        return new GetCartDto
        {
            Items = cart.Items.Select(item => item.ToGetItemDto()),
            Subtotal = cart.Items.Sum(item => item.Price)
        };
    }
}