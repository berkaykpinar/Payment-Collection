using BuyPhone.Contracts;
using BuyPhone.Data;
using BuyPhone.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyPhone.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentRepository(ApplicationDbContext dbContext)
        {
            _context=dbContext;
        }
        public async Task<bool> CheckCreditCard(Payment payment)
        {
            var cards = await _context.Payments.ToListAsync();

            foreach (var card in cards)
            {
                if (card.Name == payment.Name && card.CardNumber == payment.CardNumber &&
                    card.Expiry == payment.Expiry && card.Cvc == payment.Cvc)
                {
                    return true;
                }
            }

            return false;
            
        }
    }
}
