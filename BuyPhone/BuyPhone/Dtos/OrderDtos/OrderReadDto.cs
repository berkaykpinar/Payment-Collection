using BuyPhone.Dtos.ItemDtos;
using BuyPhone.Models;
using System.ComponentModel.DataAnnotations;

namespace BuyPhone.Dtos.OrderDtos
{
    public class OrderReadDto
    {
        public double? TotalAmount { get; set; }
        public int Quantity { get; set; }
        public double? Tax { get; set; }
        public double? TaxIncAmount { get; set; }
        public string? CreditCardInfo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }
    }
}
