using AutoMapper;
using BuyPhone.Contracts;
using BuyPhone.Data;
using BuyPhone.Dtos.CartDtos;
using BuyPhone.Dtos.ItemDtos;
using BuyPhone.Models;

namespace BuyPhone.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        public OrderRepository(ApplicationDbContext context, IItemRepository itemRepository,IMapper mapper) : base(context)
        {
            _context=context;
            _itemRepository = itemRepository;
            _mapper=mapper;
        }

        public async Task CreateOrder(CartReadDto cart)
        {
            if(cart==null) return;

            foreach (var item in cart.Items)
            {
               var orderedItem= await _itemRepository.GetAsync(item?.Id);
               orderedItem.Quantity -= item?.Quantity;
               orderedItem.InCart =0;
               orderedItem.Ordered += item?.Quantity;
               orderedItem.CartId = 2;
               orderedItem.DateModified = DateTime.Today;
               
               await _itemRepository.UpdateAsync(orderedItem);
            }

            Order order = new Order()
            {
                Quantity = cart.Items.Count(),
                TotalAmount = CalculateAmount(cart),
                Tax = 18,
                TaxIncAmount = CalculateAmount(cart) * 1.18,
                DateCreated = DateTime.UtcNow


            };
             //_context.ChangeTracker.Clear();
             await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            //await AddAsync(order);

        }

        public double? CalculateAmount(CartReadDto cart)
        {
            double? total = 0;
            foreach (var item in cart.Items)
            {
                total += ((item.Price)*item.InCart);
            }

            return total;
        }



      
    }
}
