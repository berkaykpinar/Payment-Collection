using System.ComponentModel.DataAnnotations;

namespace BuyPhone.Dtos.CartDtos
{
    public class CartCreateDto
    {
        [Key]
        public int Id { get; set; }
    }
}
