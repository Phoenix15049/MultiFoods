using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MultiFoods_Backend.Models;

using System.Linq;
namespace MultiFoods_Backend.Repositories
{


    

    public class MenuItemService
    {
        private readonly MenuItemRepository _menuItemRepository; // Assuming you have a MenuItemRepository

        public MenuItemService(MenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public List<MenuItemDTO> GetMenuItemsByNames(List<string> itemNames)
        {
            // Assuming that you have a repository method to retrieve menu items by names
            var menuItems = _menuItemRepository.GetMenuItemsByNames(itemNames);

            return menuItems.ToList();
        }
    }


}
