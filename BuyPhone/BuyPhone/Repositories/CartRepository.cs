using AutoMapper;
using BuyPhone.Contracts;
using BuyPhone.Data;
using BuyPhone.Dtos.CartDtos;
using BuyPhone.Dtos.ItemDtos;
using BuyPhone.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyPhone.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CartRepository(ApplicationDbContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper=mapper;
        }

        public async Task<CartReadDto> GetAllItemsInTheCart()
        {
            var itemList= await _context.Carts.Include(q=>q.Items).FirstOrDefaultAsync(q=>q.Id==1);
            
            

            if (itemList == null)
            {
                return null;
            }



            return _mapper.Map<CartReadDto>(itemList);
        }

        public double? CalculateTotalForCart(CartReadDto cart)
        {
            double? total = 0;
            foreach (var item in cart.Items)
            {
                total+=item.InCart*item.Price;
            }

            return total;
        }
    }
}
