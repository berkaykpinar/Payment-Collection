using System.ComponentModel.DataAnnotations.Schema;

namespace BuyPhone.Models
{
    public class Item : BaseEntity
    {
        
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? StockNumber { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }
        public int? InCart { get; set; }
        public int? Ordered { get; set; }

        [ForeignKey("Cart")]
        public int? CartId { get; set; } = 2;
        public virtual Cart? Cart { get; set; }




    }
}
