using BuyPhone.Contracts;
using BuyPhone.Data;
using BuyPhone.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyPhone.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ICartRepository _cartRepository;
        public ItemRepository(ApplicationDbContext context, ICartRepository cartRepository) : base(context)
        {
            _context = context;
            _cartRepository = cartRepository;
        }

        public async Task AddItemToCart(int id)
        {
            var item = await GetAsync(id);

            if (item == null)
            {
                return;
            }

            item.CartId = 1;
            item.InCart += 1;
            await UpdateAsync(item);

        }

        public async Task AddQuantity(int itemId, int quantity)
        {
            var item = await GetAsync(itemId);
            if (item == null)
            {
                return;
            }

            item.Quantity += quantity;
            await UpdateAsync(item);
        }

        public async Task<Item> GetItemByStockNumber(string stockNumber)
        {
            var item= await _context.Items.FirstOrDefaultAsync(q => q.StockNumber == stockNumber);

            if (item == null)
            {
                return null;
            }

            return item;
        }

        public async Task RemoveItemFromCart(int id)
        {
            var item = await GetAsync(id);

            if (item == null)
            {
                return;
            }
            
            
            if(item.InCart > 1)
            {
                item.InCart -= 1;
            }
            else
            {
                item.InCart = 0;
                item.CartId = 2;
            }

            await UpdateAsync(item);
        }




    }
}
