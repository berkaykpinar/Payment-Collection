using BuyPhone.Models;

namespace BuyPhone.Contracts
{
    public interface IItemRepository : IGenericRepository<Item>
    {
       public Task<Item> GetItemByStockNumber(string stockNumber);

       public Task AddItemToCart(int id);
       public Task RemoveItemFromCart(int id);
       public Task AddQuantity(int itemId, int quantity);
    }
}
