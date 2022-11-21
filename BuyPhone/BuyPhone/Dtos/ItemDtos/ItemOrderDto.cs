using BuyPhone.Models;

namespace BuyPhone.Dtos.ItemDtos
{
    public class ItemOrderDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? InCart { get; set; }
        public int? Ordered { get; set; }
    }
}
