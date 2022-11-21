using BuyPhone.Dtos.CartDtos;
using BuyPhone.Models;

namespace BuyPhone.Contracts
{
    public interface ICartRepository : IGenericRepository<Cart>
    {

        public Task<CartReadDto> GetAllItemsInTheCart();
        public double? CalculateTotalForCart(CartReadDto cart);
    }
}
