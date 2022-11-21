using BuyPhone.Dtos.CartDtos;
using BuyPhone.Dtos.ItemDtos;
using BuyPhone.Dtos.OrderDtos;
using BuyPhone.Models;

namespace BuyPhone.Contracts
{
    public interface IOrderRepository: IGenericRepository<Order>
    {

        public Task CreateOrder(CartReadDto items);
     
    }
}
