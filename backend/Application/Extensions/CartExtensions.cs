using Application.DTOs.Cart;
using Core.Entities;

namespace Application.Extensions;

public static class CartExtensions
{
    public static GetCartDto ToDto(this Cart cart)
    {
        return new GetCartDto
        {
            Id = cart.Id,
            Total = cart.Total,
            Items = cart.Items.Select(i => i.ToDto()).ToList()
        };
    }
}