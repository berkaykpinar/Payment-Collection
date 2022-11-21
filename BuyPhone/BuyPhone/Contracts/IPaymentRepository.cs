using BuyPhone.Models;

namespace BuyPhone.Contracts
{
    public interface IPaymentRepository
    {
        public Task<bool> CheckCreditCard(Payment payment);
    }
}

