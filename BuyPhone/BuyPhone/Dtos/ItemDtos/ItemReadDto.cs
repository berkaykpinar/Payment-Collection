using BuyPhone.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyPhone.Dtos.ItemDtos
{
    public class ItemReadDto
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? StockNumber { get; set; }
        public string? price { get; set; }
        public int? Quantity { get; set; }
        public int? InCart { get; set; }
        public int? Ordered { get; set; }

    }
}
