using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyPhone.Dtos.ItemDtos
{
    public class ItemCreateDto
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? price { get; set; }
        public int? Quantity { get; set; }
        public int? InCart { get; set; }
        public int? Ordered { get; set; }
    }
}
