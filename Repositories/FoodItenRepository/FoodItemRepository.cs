using EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO.FoodItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repositories.FoodItenRepository
{
    /// <summary>
    /// implements interface methods
    /// </summary>
    public class FoodItemRepository : IFoodItemRepository
    {
        /// <summary>
        /// dependency injection to the DbContext
        /// </summary>
        private readonly ApplicationDbContext _context;
        public FoodItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// impliment Add Method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task AddFoodItem(AddFoodItemDTO item)
        {
            try
            {
                var fooditem = new FoodItem();
                fooditem.Price = item.Price;
                fooditem.ItemCategory = item.ItemCategory;
                fooditem.CreatedBy = item.CreatedBy;
                fooditem.CreatedDate = item.CreatedDate;
                //fooditem.ModifiedDate = item.ModifiedDate;
                //fooditem.Modifiedby = item.Modifiedby;
                fooditem.FkCustomerId = item.FkCustomerId;
                fooditem.IsActive = true;
                fooditem.IsDelete = false;
                await _context.FoodItems.AddAsync(fooditem);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// impliment GetAll Method
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetFoodItemsDTO>> GetAllItems()
        {
            try
            {
                var result = await _context.FoodItems.Include(x => x.Customer).Where(x => x.IsActive && !x.IsDelete).Select(
                    x => new GetFoodItemsDTO
                    {
                        FoodID = x.FoodID,
                        Price = x.Price,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ItemCategory = x.ItemCategory,
                        CustomerName = x.Customer.Name



                    }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// implement GetbyId Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetFoodItemsDTO> GetById(int id)
        {
            try
            {
                var result = await _context.FoodItems.Include(x => x.Customer).Where(x => x.IsActive && !x.IsDelete && x.FoodID == id ).Select(
                    x => new GetFoodItemsDTO
                    {
                        FoodID = x.FoodID,
                        Price = x.Price,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        ItemCategory = x.ItemCategory,
                        CustomerName = x.Customer.Name



                    }).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// implement update method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task UpdateFoodItems(UpdateFooditemDTO item)
        {
            try
            {
                var result = await _context.FoodItems.FirstOrDefaultAsync(x => x.FoodID == item.FoodId);
                if (result != null)
                {
                    result.Price = item.Price;
                    result.ItemCategory = item.ItemCategory;
                    result.CreatedBy = item.CreatedBy;
                    result.CreatedDate = item.CreatedDate;
                    result.FkCustomerId = item.FkCustomerId;
                    result.IsActive = true;
                    result.IsDelete = false;
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
