namespace BuyPhone.Dtos.PaymentDtos
{
    public class PaymentReadDto
    {
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public string Expiry { get; set; }
        public string Cvc { get; set; }
    }
}
