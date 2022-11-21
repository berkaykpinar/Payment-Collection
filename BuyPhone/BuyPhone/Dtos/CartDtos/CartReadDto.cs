using BuyPhone.Dtos.ItemDtos;
using BuyPhone.Models;

namespace BuyPhone.Dtos.CartDtos
{
    public class CartReadDto
    {
        public IEnumerable<ItemOrderDto>? Items { get; set; }
        public double? Total { get; set; }
    }
}
