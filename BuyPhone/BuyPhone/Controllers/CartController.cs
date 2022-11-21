using AutoMapper;
using BuyPhone.Contracts;
using BuyPhone.Dtos.CartDtos;
using BuyPhone.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BuyPhone.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("/cart")]
    public class CartController :ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public CartController(ICartRepository cartRepository,IMapper mapper)
        {
            _cartRepository= cartRepository;
            _mapper= mapper;
        }

        [HttpPost]
        public ActionResult CreateCart(CartCreateDto cart)
        {
            if (cart == null)
            {
                return NoContent();
            }

            _cartRepository.AddAsync(_mapper.Map<Cart>(cart));
            return Ok();
        }

        [HttpGet("/getAll")]
        public async Task<ActionResult<CartReadDto>> GetAllItemsInTheCart()
        {
            var cart = await _cartRepository.GetAllItemsInTheCart();
            cart.Total = _cartRepository.CalculateTotalForCart(cart);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }


    }
}
