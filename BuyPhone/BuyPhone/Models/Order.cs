using System.ComponentModel.DataAnnotations.Schema;
using BuyPhone.Dtos.ItemDtos;

namespace BuyPhone.Models
{
    public class Order : BaseEntity
    {
        
        
        public double? TotalAmount { get; set; }
        public int Quantity { get; set; }
        public double? Tax { get; set; }
        public double? TaxIncAmount { get; set; }

        public string? CreditCardInfo { get; set; }
        

    }
}
