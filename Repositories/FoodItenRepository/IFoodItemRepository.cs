using Models;
using Models.DTO.FoodItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.FoodItenRepository
{
    /// <summary>
    /// declared interface methods
    /// </summary>
    public interface IFoodItemRepository
    {
        Task AddFoodItem(AddFoodItemDTO item);
        Task<List<GetFoodItemsDTO>> GetAllItems();
        Task UpdateFoodItems(UpdateFooditemDTO item);
        Task<GetFoodItemsDTO> GetById(int id);
    }
}
