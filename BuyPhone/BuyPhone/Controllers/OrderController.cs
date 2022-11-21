using AutoMapper;
using BuyPhone.Contracts;
using BuyPhone.Dtos.CartDtos;
using BuyPhone.Dtos.OrderDtos;
using BuyPhone.Dtos.PaymentDtos;
using BuyPhone.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BuyPhone.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("/order")]
    public class OrderController: ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        public OrderController(IOrderRepository orderRepository, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _paymentRepository=paymentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();

            if (orders == null)
            {
                return NotFound();
            }

            ;
            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orders));

        }

        [HttpPost("/payment")]
        public async Task<ActionResult> CheckPaymentMethod(PaymentReadDto payment)
        {
            var result = await _paymentRepository.CheckCreditCard(_mapper.Map<Payment>(payment));

            if (!result)
            {
                return NotFound("Failed");
            }
            return Ok("Success");
        }

        [HttpPost("/createorder")]
        public async Task<ActionResult> CreateOrder(CartReadDto cart)
        {
            if (cart == null)
            {
                return NoContent();
            }
            await _orderRepository.CreateOrder(cart);

            return Ok();
        }

    }
}
