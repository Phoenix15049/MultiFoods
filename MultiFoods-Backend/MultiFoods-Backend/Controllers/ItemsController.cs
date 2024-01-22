using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiFoods_Backend.Models;
using MultiFoods_Backend.Repositories;

namespace MultiFoods_Backend.Controllers
{
    // ItemsController.cs

    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsRepository _itemsRepository;

        public ItemsController(ItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemsDto>>> GetAllItems()
        {
            var items = await _itemsRepository.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemsDto>> GetItemById(int id)
        {
            var item = await _itemsRepository.GetItemByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateItem(ItemsDto item)
        {
            var itemId = await _itemsRepository.CreateItemAsync(item);
            return Ok(itemId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, ItemsDto item)
        {
            if (id != item.Item_ID)
            {
                return BadRequest();
            }

            var success = await _itemsRepository.UpdateItemAsync(item);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var success = await _itemsRepository.DeleteItemAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
