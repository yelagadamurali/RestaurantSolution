using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.FoodItemDTO
{
    public class AddFoodItemDTO
    {
        //public int FoodID { get; set; }
        public decimal Price { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public int FkCustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }     
        
        
    }
}
