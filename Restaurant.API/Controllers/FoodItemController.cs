using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.FoodItemDTO;
using Repositories.FoodItenRepository;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        /// <summary>
        /// DI to the IFoodItemRepository
        /// </summary>
        private readonly IFoodItemRepository _foodItemRepository;
        public FoodItemController(IFoodItemRepository foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
        }
        /// <summary>
        /// API for Add Operation
        /// </summary>
        /// <param name="foodItem"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddNewFoodItem")]
        public async Task<IActionResult> AddNewFoodItem(AddFoodItemDTO foodItem)
        {
            try
            {
               await _foodItemRepository.AddFoodItem(foodItem);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// API for Getall Operation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<GetFoodItemsDTO>> GetAll()
        {
            try
            {
           var result =   await  _foodItemRepository.GetAllItems();
                return (result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// API for Update Operation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateFoodItem")]
        public async Task<IActionResult> UpdateFoodItem(UpdateFooditemDTO item)
        {
            try
            {
                await _foodItemRepository.UpdateFoodItems(item);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        /// <summary>
        /// API for GetById Operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public async Task<GetFoodItemsDTO> GetById(int id)
        {
            try
            {
             var result =  await _foodItemRepository.GetById(id);
                return (result);
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }
    }
}
