using Microsoft.AspNetCore.Mvc;

namespace MultiFoods_Backend.Controllers
{
    // MenuController.cs

    using Microsoft.AspNetCore.Mvc;
    using MultiFoods_Backend.Models;
    using MultiFoods_Backend.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/menus")]
    public class MenuController : ControllerBase
    {
        private readonly MenuRepository _menuRepository;

        public MenuController(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // CRUD operations for Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenusDto>>> GetAllMenus()
        {
            var menus = await _menuRepository.GetAllMenusAsync();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenusDto>> GetMenuById(int id)
        {
            var menu = await _menuRepository.GetMenuByIdAsync(id);

            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateMenu(MenusDto menu)
        {
            var menuId = await _menuRepository.CreateMenuAsync(menu);
            return Ok(menuId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMenu(int id, MenusDto menu)
        {
            if (id != menu.Menu_ID)
            {
                return BadRequest();
            }

            var success = await _menuRepository.UpdateMenuAsync(menu);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMenu(int id)
        {
            var success = await _menuRepository.DeleteMenuAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // CRUD operations for MenuItems
        [HttpGet("menuitems")]
        public async Task<ActionResult<IEnumerable<MenuItemsDto>>> GetAllMenuItems()
        {
            var menuItems = await _menuRepository.GetAllMenuItemsAsync();
            return Ok(menuItems);
        }

        [HttpGet("menuitems/{id}")]
        public async Task<ActionResult<MenuItemsDto>> GetMenuItemById(int id)
        {
            var menuItem = await _menuRepository.GetMenuItemByIdAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpPost("menuitems")]
        public async Task<ActionResult<int>> CreateMenuItem(MenuItemsDto menuItem)
        {
            var menuItemId = await _menuRepository.CreateMenuItemAsync(menuItem);
            return Ok(menuItemId);
        }

        [HttpDelete("menuitems/{id}")]
        public async Task<ActionResult> DeleteMenuItem(int id)
        {
            var success = await _menuRepository.DeleteMenuItemAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
