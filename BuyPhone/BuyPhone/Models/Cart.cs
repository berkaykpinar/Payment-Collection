namespace BuyPhone.Models
{
    public class Cart : BaseEntity
    {
       
        public ICollection<Item>? Items { get; set; }
        public int Total;

    }
}
