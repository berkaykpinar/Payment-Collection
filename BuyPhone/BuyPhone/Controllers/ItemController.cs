using AutoMapper;
using BuyPhone.Contracts;
using BuyPhone.Dtos.ItemDtos;
using BuyPhone.Models;
using BuyPhone.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BuyPhone.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("/item")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemController(IItemRepository repository,IMapper mapper)
        {
            _itemRepository= repository;
            _mapper= mapper;
        }

        [HttpGet("getItem/{id}")]
        public async Task<ActionResult<ItemReadDto>> GetItem(int id)
        {
            var item = await _itemRepository.GetAsync(id);
            if (item==null)
            {
                return NotFound();
            }

            return _mapper.Map<ItemReadDto>(item);

        }
        [HttpPost]
        public async Task<IActionResult> AddItem(ItemCreateDto item)
        {
            var itemModel= _mapper.Map<Item>(item);
            if (item == null)
            {
                return NoContent();
            }

            await _itemRepository.AddAsync(itemModel);
            return Ok();
        }

       
        [HttpPost("AddQuantity")]
        public async Task<IActionResult> AddQuantityToItem(int itemId,int quantity)
        {
            

            await _itemRepository.AddQuantity(itemId,quantity);
            return Ok();
        }

       
        [HttpGet("getallItems")]
        public async Task<IEnumerable<ItemReadDto>> GelAllItems()
        {
            var items=  _mapper.Map<IEnumerable<ItemReadDto>>(await _itemRepository.GetAllAsync());
                 
            if (items == null)
            {
                return null;
            }


            return items;
        }

        [HttpPost("addtocart")]
       
        public async Task<IActionResult> AddItemToCart(int id)
        {
            await _itemRepository.AddItemToCart(id);

            return Ok();
        }
        [HttpPost("/remove")]
        public async Task<IActionResult> RemoveItemFromCart(int id)
        {
            await _itemRepository.RemoveItemFromCart(id);

            return Ok();
        }
    }
}
