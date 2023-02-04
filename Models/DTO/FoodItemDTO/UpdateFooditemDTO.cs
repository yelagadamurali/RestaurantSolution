using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.FoodItemDTO
{
    public class UpdateFooditemDTO
    {
        public int FoodId { get; set; }
        public decimal Price { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public int FkCustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        
    }
}
