using Application.Interfaces.Services;
using Core.Interfaces.Repositories;

namespace Infrastructure.Services;

public class OwnershipService(ICartRepository cartRepository) : IOwnershipService
{
    public async Task<bool> HasItemOwnershipAsync(int? cartId, int userId)
    {
        var cart = await cartRepository.GetOneByUserIdAsync(userId);
        return cartId == cart.Value.Id;
    }
}